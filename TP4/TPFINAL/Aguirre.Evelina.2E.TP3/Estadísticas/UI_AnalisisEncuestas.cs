using AnalyticsEntidades;
using EstadisticasEntidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UserInterfaz;

namespace charts4
{

    public partial class UI_AnalisisEncuestas : Form
    {
        int m, mx, my;
        public static string consultaActual = string.Empty;
        public int hombres, mujeres, otros;
        public UI_AnalisisEncuestas()
        {
            InitializeComponent();
            ConsultasDB.ceroRegistrosEvento += InformaRegistroCero;
           
        }

        private void UI_AnalisisEncuestas_Load(object sender, EventArgs e)
        {
            hombres = (int)ConsultasDB.PromedioSueldoDeLaConsulta("" + "SE_IDENTIFICA LIKE 'Hombre'");
            mujeres = (int)ConsultasDB.PromedioSueldoDeLaConsulta("" + "SE_IDENTIFICA LIKE 'Mujer'");
            otros = (int)ConsultasDB.PromedioSueldoDeLaConsulta("" + "SE_IDENTIFICA LIKE 'Otro'");

            Limpiar();
            CargarComboboxes();
            dgDatos.DataSource = null;
            dgDatos.DataSource = ConexionDB.TraerResultadoEncuestas();
            CargarChartBarras(hombres, mujeres, otros);
            CargaChartPie(0, 100);


        }

        private void chart2_Click(object sender, EventArgs e)
        {
            string[] seriesArray = { "Categoria 1", "Categoria 2", "Categoria 3" };
            int[] pointsArray = { 2, 3, 10 };
            
            this.chart1.Palette = ChartColorPalette.None;
           
            this.chart1.Titles.Add("Categorias");
           
            for (int i = 0; i < seriesArray.Length; i++)
            {
                
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void UI_AnalisisEncuestas_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void btnCargarNuevaEncuesta_Click(object sender, EventArgs e)
        {

            CargarNuevaEncuesta nuevaEncuesta = new CargarNuevaEncuesta();
            nuevaEncuesta.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void UI_AnalisisEncuestas_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //Consulta que se hará a la DB
            string aux = DevuelveStringConsultaDBSegunCheckedBoxesSeleccionados();

            //variables auxiliares 
            int cantegistrosUltimaConsulta = ConsultasDB.CuentaRegistrosDeUnaConsulta(aux);
            int cantRegistrosTotal = ConsultasDB.CuentaRegistrosDeUnaConsulta();
            float porcentaje = Encuesta.CalculoPorcentaje(cantegistrosUltimaConsulta, cantRegistrosTotal);
            
            //carga chart pie
            CargaChartPie(cantegistrosUltimaConsulta, cantRegistrosTotal);

            //Completa datagrid
            dgDatos.DataSource = null;
            dgDatos.DataSource = ConexionDB.TraeResultadoEncuestas(ConsultasDB.DevuelveStringConsultaBasicaADB(aux));


            //Calculo total de encuestas
            lblTotal.Text = $"{cantRegistrosTotal}";
            int promedioSueldoTotal = (int)ConsultasDB.PromedioSueldoDeLaConsulta();
            lblPromedioTotal.Text = $"${promedioSueldoTotal.ToString()}";

            //Calculo total por consulta
            lblTotalConsulta.Text = cantegistrosUltimaConsulta.ToString();
            int promedioSueldoConsulta = (int)ConsultasDB.PromedioSueldoDeLaConsulta(aux);
            lblPromedioConsulta.Text = $"${promedioSueldoConsulta.ToString()}";
            lblPorcentaje.Text = $"{porcentaje}%";

            //Calculo cantidad por genero
            lblCantidadMujeresConsulta.Text = ConsultasDB.CuentaRegistrosDeUnaConsulta(aux," and SE_IDENTIFICA LIKE 'Mujer'").ToString();
            lblCantidadVaronesConsulta.Text = ConsultasDB.CuentaRegistrosDeUnaConsulta(aux, "and SE_IDENTIFICA LIKE 'Hombre'").ToString();
            lblCantidadOtroConsulta.Text = ConsultasDB.CuentaRegistrosDeUnaConsulta(aux, "and SE_IDENTIFICA LIKE 'Otro'").ToString();

            //Calculo porcentaje por genero
            lblPorcentajeMujeres.Text = $"{Encuesta.CalculoPorcentaje(ConsultasDB.CuentaRegistrosDeUnaConsulta(aux, " and SE_IDENTIFICA LIKE 'Mujer'"), cantRegistrosTotal).ToString()} %";
            lblPorcentajeVarones.Text = $"{Encuesta.CalculoPorcentaje(ConsultasDB.CuentaRegistrosDeUnaConsulta(aux, " and SE_IDENTIFICA LIKE 'Hombre'"), cantRegistrosTotal).ToString()} %";
            lblPorcentajeOtros.Text = $"{Encuesta.CalculoPorcentaje(ConsultasDB.CuentaRegistrosDeUnaConsulta(aux, " and SE_IDENTIFICA LIKE 'Otro'"), cantRegistrosTotal).ToString()} %";
            
            //Calculo sueldo promedio por genero
            mujeres = (int)ConsultasDB.PromedioSueldoDeLaConsulta(aux + " and SE_IDENTIFICA LIKE 'Mujer'");
            lblSueldoPromedioMujeres.Text = $"$ {mujeres}";
            hombres = (int)ConsultasDB.PromedioSueldoDeLaConsulta(aux + " and SE_IDENTIFICA LIKE 'Hombre'");
            lblSueldoPromedioVarones.Text = $"$ {hombres}";
            otros = (int)ConsultasDB.PromedioSueldoDeLaConsulta(aux + " and SE_IDENTIFICA LIKE 'Otro'");
            lblSueldoPromedioOtros.Text = $"$ {otros}";

            //Calculo brecha salarial
            string quienGanaMas = CalculoEstadistica.MayorSueldo(hombres, mujeres, otros);
            int diferencia1=0;
            int diferencia2=0;

            if(quienGanaMas == "Hombres")
            {
                diferencia1 = CalculoEstadistica.CalculoDiferenciaDeMontos(hombres, mujeres);
                diferencia2 = CalculoEstadistica.CalculoDiferenciaDeMontos(hombres, otros);
                lblBrechaSalarial.Text = $"En este caso los varones ganan en promedio  $ {diferencia1} más que las mujeres y $ {diferencia2} más que quienes se identifican con otro género.";
            }

            else if (quienGanaMas == "Mujeres")
            {
                diferencia1 = CalculoEstadistica.CalculoDiferenciaDeMontos(mujeres, hombres);
                diferencia2 = CalculoEstadistica.CalculoDiferenciaDeMontos(mujeres, otros);
                lblBrechaSalarial.Text = $"En este caso las mujeres ganan en promedio  $ {diferencia1} más que los varones y $ {diferencia2} más que quienes se identifican con otro género.";
            }

            else if (quienGanaMas == "Otros")
            {
                diferencia1 = CalculoEstadistica.CalculoDiferenciaDeMontos(otros, hombres);
                diferencia2 = CalculoEstadistica.CalculoDiferenciaDeMontos(otros, mujeres);
                lblBrechaSalarial.Text = $"En este caso quienes se identifican con otro genero ganan $ {diferencia1} más que los varones y $ {diferencia2} que las mujeres.";
            }
            CargarChartBarras(hombres, mujeres, otros);

            consultaActual = aux;
        }

     

        private void UI_AnalisisEncuestas_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }


        private async void btnExportar_Click(object sender, EventArgs e)
        {
            FrmExportar frmExportar = new FrmExportar();
            await Task.Run(() =>
            {
                frmExportar.ShowDialog();
            });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UI_AnalisisEncuestas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string aux = DevuelveStringConsultaDBSegunCheckedBoxesSeleccionados();

                dgDatos.DataSource = null;
                dgDatos.DataSource = ConexionDB.TraeResultadoEncuestas(ConsultasDB.DevuelveStringConsultaBasicaADB(aux));

                int cantegistrosUltimaConsulta = ConsultasDB.CuentaRegistrosDeUnaConsulta(aux);
                int cantRegistrosTotal = ConsultasDB.CuentaRegistrosDeUnaConsulta();

                float porcentaje = Encuesta.CalculoPorcentaje(cantegistrosUltimaConsulta, cantRegistrosTotal);

                lblTotal.Text = $"{cantRegistrosTotal}";
                int promedioSueldoTotal = (int)ConsultasDB.PromedioSueldoDeLaConsulta();
                lblPromedioTotal.Text = promedioSueldoTotal.ToString();

                lblTotalConsulta.Text = cantegistrosUltimaConsulta.ToString();
                int promedioSueldoConsulta = (int)ConsultasDB.PromedioSueldoDeLaConsulta(aux);
                lblPromedioConsulta.Text = promedioSueldoConsulta.ToString();
                lblPorcentaje.Text = $"{porcentaje}%";

                consultaActual = aux;
            }
        }

        private void chkSeIdentifica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string aux = DevuelveStringConsultaDBSegunCheckedBoxesSeleccionados();

                dgDatos.DataSource = null;
                dgDatos.DataSource = ConexionDB.TraeResultadoEncuestas(ConsultasDB.DevuelveStringConsultaBasicaADB(aux));

                int cantegistrosUltimaConsulta = ConsultasDB.CuentaRegistrosDeUnaConsulta(aux);
                int cantRegistrosTotal = ConsultasDB.CuentaRegistrosDeUnaConsulta();

                float porcentaje = Encuesta.CalculoPorcentaje(cantegistrosUltimaConsulta, cantRegistrosTotal);

                lblTotal.Text = $"{cantRegistrosTotal}";
                int promedioSueldoTotal = (int)ConsultasDB.PromedioSueldoDeLaConsulta();
                lblPromedioTotal.Text = promedioSueldoTotal.ToString();

                lblTotalConsulta.Text = cantegistrosUltimaConsulta.ToString();
                int promedioSueldoConsulta = (int)ConsultasDB.PromedioSueldoDeLaConsulta(aux);
                lblPromedioConsulta.Text = promedioSueldoConsulta.ToString();
                lblPorcentaje.Text = $"{porcentaje}%";

                consultaActual = aux;
            }
        }

        private string DevuelveStringConsultaDBSegunCheckedBoxesSeleccionados()
        {
            List<string> auxListaTildados = new List<string>();
            List<Encuesta> auxListEncuesttas = ConexionDB.TraerResultadoEncuestas();

            auxListaTildados = quienEstaTildado();
            string cadenaResultanteConsultaDB = " ";
            int contador = 0;


            foreach (string item in auxListaTildados)
            {

                if (contador == 0 || string.IsNullOrEmpty(item))
                {
                    cadenaResultanteConsultaDB = "";
                }
                else
                {
                    cadenaResultanteConsultaDB += " and ";
                }

                contador++;



                switch (item)
                {
                    case "chkRecomienda":
                        if (!string.IsNullOrEmpty(cmbRecomiendaEmpresa.Text.ToString()))
                        {
                            Enumerados.ERecomienda enumAux = (Enumerados.ERecomienda)Enum.Parse(typeof(Enumerados.ERecomienda), cmbRecomiendaEmpresa.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux);
                        }
                        break;
                    case "chkRubro":
                        if (!string.IsNullOrEmpty(cmbRubro.Text.ToString()))
                        {
                            Enumerados.ERubro enumAux1 = (Enumerados.ERubro)Enum.Parse(typeof(Enumerados.ERubro), cmbRubro.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux1);
                        }
                        break;
                    case "chkSalario":
                        if (!string.IsNullOrEmpty(cmbSalarioNeto.Text.ToString()))
                        {
                            Enumerados.ESalario enumAux2 = (Enumerados.ESalario)Enum.Parse(typeof(Enumerados.ESalario), cmbSalarioNeto.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux2);
                        }
                        break;
                    case "chkJornada":
                        if (!string.IsNullOrEmpty(cmbJornada.Text.ToString()))
                        {
                            Enumerados.EJornada enumAux3 = (Enumerados.EJornada)Enum.Parse(typeof(Enumerados.EJornada), cmbJornada.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux3);
                        }
                        break;

                    case "chkPuesto":
                        if (!string.IsNullOrEmpty(cmbPuesto.Text.ToString()))
                        {
                            Enumerados.EPuesto enumAux4 = (Enumerados.EPuesto)Enum.Parse(typeof(Enumerados.EPuesto), cmbPuesto.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux4);
                        }

                        break;

                    case "chkNivelEstudios":
                        if (!string.IsNullOrEmpty(cmbNivelEstudios.Text.ToString()))
                        {
                            Enumerados.EEstudios enumAux5 = (Enumerados.EEstudios)Enum.Parse(typeof(Enumerados.EEstudios), cmbNivelEstudios.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux5);
                        }
                        break;

                    case "chkPersonalACargo":

                        if (!string.IsNullOrEmpty(cmbPersonalACargo.Text.ToString()))
                        {
                            Enumerados.EPersonasaACargo enumAux6 = (Enumerados.EPersonasaACargo)Enum.Parse(typeof(Enumerados.EPersonasaACargo), cmbPersonalACargo.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux6);
                        }
                        break;

                    case "chkExperiencia":
                        if (!string.IsNullOrEmpty(cmbAniosExperiencia.Text.ToString()))
                        {
                            Enumerados.EExperiencia enumAux7 = (Enumerados.EExperiencia)Enum.Parse(typeof(Enumerados.EExperiencia), cmbAniosExperiencia.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux7);
                        }
                        break;

                    case "chkProvincia":
                        if (!string.IsNullOrEmpty(cmbProvincia.Text.ToString()))
                        {
                            Enumerados.EProvincia enumAux8 = (Enumerados.EProvincia)Enum.Parse(typeof(Enumerados.EProvincia), cmbProvincia.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux8);
                        }
                        break;

                    case "chkEdad":
                        if (!string.IsNullOrEmpty(cmbEdad.Text.ToString()))
                        {
                            Enumerados.EEdad enumAux9 = (Enumerados.EEdad)Enum.Parse(typeof(Enumerados.EEdad), cmbEdad.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux9);
                        }
                        break;

                    case "chkSeIdentifica":

                        if (!string.IsNullOrEmpty(cmbSeIdentifica.Text.ToString()))
                        {
                            Enumerados.ESexo enumAux10 = (Enumerados.ESexo)Enum.Parse(typeof(Enumerados.ESexo), cmbSeIdentifica.SelectedItem.ToString());
                            cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux10);
                        }
                        break;
                }



            }
            return cadenaResultanteConsultaDB;
        }

        private List<string> quienEstaTildado()
        {
            List<string> auxLista = new List<string>();
            string auxString;


            if (chkSeIdentifica.Checked)
            {
                if (!string.IsNullOrEmpty(cmbSeIdentifica.Text.ToString()))
                {
                    auxString = "chkSeIdentifica";
                    auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }
            if (chkEdad.Checked)
            {
                if (!string.IsNullOrEmpty(cmbEdad.Text.ToString()))
                {
                    auxString = "chkEdad";
                    auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }

            if (chkProvincia.Checked)
            {
                if (!string.IsNullOrEmpty(cmbProvincia.Text.ToString()))
                {
                    auxString = "chkProvincia";
                    auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }

            if (chkExperiencia.Checked)
            {
                if (!string.IsNullOrEmpty(cmbAniosExperiencia.Text.ToString()))
                {
                    auxString = "chkExperiencia";
                    auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }

            if (chkPersonalACargo.Checked)
            {
                if (!string.IsNullOrEmpty(cmbPersonalACargo.Text.ToString()))
                {
                    auxString = "chkPersonalACargo";
                auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }

            if (chkNivelEstudios.Checked)
            {
                if (!string.IsNullOrEmpty(cmbNivelEstudios.Text.ToString()))
                {
                    auxString = "chkNivelEstudios";
                auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }

            if (chkPuesto.Checked)
            {
                if (!string.IsNullOrEmpty(cmbPuesto.Text.ToString()))
                {
                    auxString = "chkPuesto";
                auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }

            if (chkJornada.Checked)
            {
                if (!string.IsNullOrEmpty(cmbJornada.Text.ToString()))
                {
                    auxString = "chkJornada";
                auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }

            if (chkSalario.Checked)
            {
                if (!string.IsNullOrEmpty(cmbSalarioNeto.Text.ToString()))
                {
                    auxString = "chkSalario";
                    auxLista.Add(auxString);
                }
                else
                    auxString = null;
                }

            if (chkRubro.Checked)
            {
                if (!string.IsNullOrEmpty(cmbRubro.Text.ToString()))
                {
                    auxString = "chkRubro";
                auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }

            if (chkRecomienda.Checked)
            {
                if (!string.IsNullOrEmpty(cmbRecomiendaEmpresa.Text.ToString()))
                {
                    auxString = "chkRecomienda";
                auxLista.Add(auxString);
                }
                else
                    auxString = null;
            }


            return auxLista;

        }

        private void CargaChartPie(int value1, int value2)
        {

            chart2.Series.Clear();
            chart2.Legends.Clear();


            chart2.Legends.Add("Según tu selección:");
            chart2.Legends[0].LegendStyle = LegendStyle.Table;
            chart2.Legends[0].Docking = Docking.Bottom;
            chart2.Legends[0].Alignment = StringAlignment.Center;
            chart2.Legends[0].Title = "Total:";
            chart2.Legends[0].BorderColor = Color.Black;


            string seriesname = "Etiquetas";
            chart2.Series.Add(seriesname);

            chart2.Series[seriesname].ChartType = SeriesChartType.Pie;


            chart2.Series[seriesname].Points.AddXY("Población Seleccionada", value1);
            chart2.Series[seriesname].Points.AddXY("Resto", value2);

        }

        private void CargarChartBarras(int hombres, int mujeres, int otros)
        {
            chart1.Titles.Clear();
            chart1.Series.Clear();

            string[] seriesArray = { "Varones", "Mujeres", "Otros" };
            int[] pointsArray = { hombres, mujeres, otros };

            this.chart1.Palette = ChartColorPalette.SemiTransparent;

            this.chart1.Titles.Add("Salario");

            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        private void Limpiar()
        {
            lblCantidadMujeresConsulta.Text = String.Empty;
            lblCantidadVaronesConsulta.Text = String.Empty;
            lblCantidadOtroConsulta.Text = String.Empty;

         
            lblPorcentajeMujeres.Text = String.Empty;
            lblPorcentajeVarones.Text = String.Empty;
            lblPorcentajeOtros.Text = String.Empty;


            lblSueldoPromedioMujeres.Text = String.Empty;
            lblSueldoPromedioVarones.Text= String.Empty;
            lblSueldoPromedioOtros.Text = String.Empty;

            lblBrechaSalarial.Text = String.Empty;

            chkSeIdentifica.Enabled = true;
            chkEdad.Enabled = true;
            chkProvincia.Enabled = true;
            chkExperiencia.Enabled = true;
            chkPersonalACargo.Enabled = true;
            chkNivelEstudios.Enabled = true;
            chkPuesto.Enabled = true;
            chkJornada.Enabled = true;
            chkSalario.Enabled = true;
            chkRubro.Enabled = true;
            chkRecomienda.Enabled = true;

            chkSeIdentifica.Checked = false;
            chkEdad.Checked = false;
            chkProvincia.Checked = false;
            chkExperiencia.Checked = false;
            chkPersonalACargo.Checked = false;
            chkNivelEstudios.Checked = false;
            chkPuesto.Checked = false;
            chkJornada.Checked = false;
            chkSalario.Checked = false;
            chkRubro.Checked = false;
            chkRecomienda.Checked = false;

            lblPorcentaje.Text = String.Empty;
            lblPromedioConsulta.Text = String.Empty;
            lblPromedioTotal.Text = String.Empty;
            lblTotal.Text = String.Empty;
            lblTotalConsulta.Text = String.Empty;

            CargarComboboxes();

            dgDatos.DataSource = null;
            dgDatos.DataSource = ConexionDB.TraerResultadoEncuestas();
        }

        private void CargarComboboxes()
        {
            cmbSeIdentifica.DataSource = Enum.GetNames(typeof(Enumerados.ESexo));
            cmbAniosExperiencia.DataSource = Enum.GetNames(typeof(Enumerados.EExperiencia));
            cmbEdad.DataSource = Enum.GetNames(typeof(Enumerados.EEdad));
            cmbJornada.DataSource = Enum.GetNames(typeof(Enumerados.EJornada));
            cmbNivelEstudios.DataSource = Enum.GetNames(typeof(Enumerados.EEstudios));
            cmbPersonalACargo.DataSource = Enum.GetNames(typeof(Enumerados.EPersonasaACargo));
            cmbProvincia.DataSource = Enum.GetNames(typeof(Enumerados.EProvincia));
            cmbPuesto.DataSource = Enum.GetNames(typeof(Enumerados.EPuesto));
            cmbRecomiendaEmpresa.DataSource = Enum.GetNames(typeof(Enumerados.ERecomienda));
            cmbRubro.DataSource = Enum.GetNames(typeof(Enumerados.ERubro));
            cmbSalarioNeto.DataSource = Enum.GetNames(typeof(Enumerados.ESalario));
            cmbSeIdentifica.SelectedIndex = -1;
            cmbAniosExperiencia.SelectedIndex = -1;
            cmbEdad.SelectedIndex = -1;
            cmbJornada.SelectedIndex = -1;
            cmbNivelEstudios.SelectedIndex = -1;
            cmbPersonalACargo.SelectedIndex = -1;
            cmbProvincia.SelectedIndex = -1;
            cmbPuesto.SelectedIndex = -1;
            cmbRecomiendaEmpresa.SelectedIndex = -1;
            cmbRubro.SelectedIndex = -1;
            cmbSalarioNeto.SelectedIndex = -1;

        }

        private void InformaRegistroCero()
        {
            MessageBox.Show("No se encontraron coincidencias con la búsqueda");
        }

    }
}
