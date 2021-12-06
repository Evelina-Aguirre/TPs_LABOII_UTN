using AnalyticsEntidades;
using Archivos;
using EstadisticasEntidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UserInterfaz;

namespace charts4
{

    public partial class UI_AnalisisEncuestas : Form
    {
        int m, mx, my;
        public int hombres, mujeres, otros;
        Xml auxXml = new Xml();
        public UI_AnalisisEncuestas()
        {
            InitializeComponent();
        }

        private void UI_AnalisisEncuestas_Load(object sender, EventArgs e)
        {
            CalculoEstadistica.listaDatosPedidos = auxXml.LeerDatos();


            hombres = CalculoEstadistica.SalarioPromedio("Hombre", CalculoEstadistica.listaDatosPedidos);
            mujeres = CalculoEstadistica.SalarioPromedio("Mujer", CalculoEstadistica.listaDatosPedidos);
            otros = CalculoEstadistica.SalarioPromedio("Otro", CalculoEstadistica.listaDatosPedidos);

            Limpiar();
            dgDatos.DataSource = null;
            dgDatos.DataSource = CalculoEstadistica.listaDatosPedidos;
            CargarChartBarras(hombres, mujeres, otros);
            CargaChartPie(0, 0);

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

            CalculoEstadistica.auxListaResultadoConsulta = TraerListaSegúnConsultaRealizada();
            int cantRegistrosUltimaConsulta = CalculoEstadistica.auxListaResultadoConsulta.Count;
            int cantRegistrosTotal = CalculoEstadistica.listaDatosPedidos.Count;
            float porcentaje = CalculoEstadistica.CalculoPorcentaje(cantRegistrosUltimaConsulta, cantRegistrosTotal);

            if(cantRegistrosUltimaConsulta == 0)
            {
                MessageBox.Show("No se encontraron resultados coincidentes con esta búsqueda.");
            }

            //carga chart pie
            CargaChartPie(cantRegistrosUltimaConsulta, cantRegistrosTotal);

            //Completa datagrid
            dgDatos.DataSource = null;
            dgDatos.DataSource = CalculoEstadistica.auxListaResultadoConsulta;


            //Calculo total de encuestas
            lblTotal.Text = $"{cantRegistrosTotal}";
            int promedioSueldoTotal = CalculoEstadistica.SalarioPromedio(CalculoEstadistica.listaDatosPedidos);
            lblPromedioTotal.Text = $"${promedioSueldoTotal}";

            //Calculo total por consulta
            lblTotalConsulta.Text = cantRegistrosUltimaConsulta.ToString();
            int promedioSueldoConsulta = CalculoEstadistica.SalarioPromedio(CalculoEstadistica.auxListaResultadoConsulta);
            lblPromedioConsulta.Text = $"${promedioSueldoConsulta}";
            lblPorcentaje.Text = $"{porcentaje}%";

            //Calculo cantidad por genero
            int CantidadMujeres = CalculoEstadistica.CuentaCantidadDeEncuestaPorSexo("Mujer", CalculoEstadistica.auxListaResultadoConsulta);
            int cantidadHombres = CalculoEstadistica.CuentaCantidadDeEncuestaPorSexo("Hombre", CalculoEstadistica.auxListaResultadoConsulta);
            int cantidadOtros = CalculoEstadistica.CuentaCantidadDeEncuestaPorSexo("Otro", CalculoEstadistica.auxListaResultadoConsulta);
            lblCantidadMujeresConsulta.Text = CantidadMujeres.ToString();
            lblCantidadVaronesConsulta.Text = cantidadHombres.ToString();
            lblCantidadOtroConsulta.Text = cantidadOtros.ToString();

            //Calculo porcentaje por genero
            lblPorcentajeMujeres.Text = $"{CalculoEstadistica.CalculoPorcentaje(CantidadMujeres, cantRegistrosTotal)} %";
            lblPorcentajeVarones.Text = $"{CalculoEstadistica.CalculoPorcentaje(cantidadHombres, cantRegistrosTotal)} %";
            lblPorcentajeOtros.Text = $"{CalculoEstadistica.CalculoPorcentaje(cantidadOtros, cantRegistrosTotal)} %";

            //Calculo sueldo promedio por genero
            mujeres = CalculoEstadistica.SalarioPromedio("Mujer", CalculoEstadistica.auxListaResultadoConsulta);
            lblSueldoPromedioMujeres.Text = $"$ {mujeres}";
            hombres = CalculoEstadistica.SalarioPromedio("Hombre", CalculoEstadistica.auxListaResultadoConsulta);
            lblSueldoPromedioVarones.Text = $"$ {hombres}";
            otros = CalculoEstadistica.SalarioPromedio("Otro", CalculoEstadistica.auxListaResultadoConsulta);
            lblSueldoPromedioOtros.Text = $"$ {otros}";

            //Calculo brecha salarial
            string quienGanaMas = CalculoEstadistica.MayorSueldo(hombres, mujeres, otros);
            int diferencia1 = 0;
            int diferencia2 = 0;

            if (quienGanaMas == "Hombres")
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

        }



        private void UI_AnalisisEncuestas_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            FrmExportar frmExportar = new FrmExportar();
            frmExportar.ShowDialog();
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

        }

        private void chkSeIdentifica_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private List<Encuesta> TraerListaSegúnConsultaRealizada()
        {
            List<string> auxListaTildados = new List<string>();
            List<Encuesta> auxListBusqueda = CalculoEstadistica.listaDatosPedidos;

            auxListaTildados = quienEstaTildado();

            foreach (string item in auxListaTildados)
            {
                switch (item)
                {
                    case "chkRecomienda":
                        if (!string.IsNullOrEmpty(cmbRecomiendaEmpresa.Text.ToString()))
                        {
                            if (cmbRecomiendaEmpresa.SelectedItem.ToString().Contains("De 0 a 3"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(0, 3, "Recomienda", auxListBusqueda);
                            }
                            else if (cmbRecomiendaEmpresa.SelectedItem.ToString().Contains("De 3 a 7"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(3, 7, "Recomienda", auxListBusqueda);
                            }
                            else
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(7, 10, "Recomienda", auxListBusqueda);
                            }
                        }
                        break;
                    case "chkRubro":
                        if (!string.IsNullOrEmpty(cmbRubro.Text.ToString()))
                        {
                            auxListBusqueda = CalculoEstadistica.Buscar(cmbRubro.Text.ToString(), auxListBusqueda);
                        }
                        break;
                    case "chkSalario":

                        if (!string.IsNullOrEmpty(cmbSalarioNeto.Text.ToString()))
                        {

                            if (cmbSalarioNeto.SelectedItem.ToString().Contains("Hasta 50.000"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(0, 50000, "Sueldo", auxListBusqueda);
                            }
                            else if (cmbSalarioNeto.SelectedItem.ToString().Contains("De 50.000 a 150.000"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(50000, 150000, "Sueldo", auxListBusqueda);
                            }
                            else
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(150000, 99999999, "Sueldo", auxListBusqueda);
                            }

                        }
                        break;

                    case "chkJornada":
                        if (!string.IsNullOrEmpty(cmbJornada.Text.ToString()))
                        {
                            auxListBusqueda = CalculoEstadistica.Buscar(cmbJornada.Text.ToString(), auxListBusqueda);
                        }
                        break;

                    case "chkNivelEstudios":
                        if (!string.IsNullOrEmpty(cmbNivelEstudios.Text.ToString()))
                        {
                            auxListBusqueda = CalculoEstadistica.Buscar(cmbNivelEstudios.Text.ToString(), auxListBusqueda);
                        }
                        break;

                    case "chkPersonalACargo":

                        if (!string.IsNullOrEmpty(cmbPersonalACargo.Text.ToString()))
                        {

                            if (cmbPersonalACargo.SelectedItem.ToString().Contains("Hasta 10"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(1, 10, "Personal", auxListBusqueda);
                            }
                            else if (cmbPersonalACargo.SelectedItem.ToString().Contains("Más de 10"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(10, 99999999, "Personal", auxListBusqueda);
                            }
                            else
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(0, 0, "Personal", auxListBusqueda);
                            }


                        }
                        break;

                    case "chkExperiencia":

                        if (!string.IsNullOrEmpty(cmbAniosExperiencia.Text.ToString()))
                        {
                            if (cmbAniosExperiencia.SelectedItem.ToString().Contains("0"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(0, 0, "Experiencia", auxListBusqueda);
                            }
                            else if (cmbAniosExperiencia.SelectedItem.ToString().Contains("Hasta 10"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(1, 10, "Experiencia", auxListBusqueda);
                            }
                            else
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(10, 200, "Experiencia", auxListBusqueda);
                            }
                        }
                        break;

                    case "chkEdad":

                        if (!string.IsNullOrEmpty(cmbEdad.Text.ToString()))
                        {
                            string aux = cmbEdad.SelectedItem.ToString();
                            if (cmbEdad.SelectedItem.ToString().Contains("Hasta 30 años"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(0, 30, "Edad", auxListBusqueda);
                            }
                            else if (cmbEdad.SelectedItem.ToString().Contains("Entre 30 y 50"))
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(30, 50, "Edad", auxListBusqueda);
                            }
                            else
                            {
                                auxListBusqueda = CalculoEstadistica.Buscar(50, 200, "Edad", auxListBusqueda);
                            }
                        }
                        break;

                    case "chkSeIdentifica":

                        if (!string.IsNullOrEmpty(cmbSeIdentifica.Text.ToString()))
                        {
                            auxListBusqueda = CalculoEstadistica.Buscar(cmbSeIdentifica.SelectedItem.ToString(), auxListBusqueda);
                        }
                        break;
                }

            }
            return auxListBusqueda;
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

            if (value1 != value2)
            {
                chart2.Series[seriesname].Points.AddXY("Población Seleccionada", value1);
                chart2.Series[seriesname].Points.AddXY("Resto", value2);
            }
            else
            {
                chart2.Series[seriesname].Points.AddXY("Población Seleccionada", 100);

            }


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
            lblSueldoPromedioVarones.Text = String.Empty;
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
            dgDatos.DataSource = CalculoEstadistica.listaDatosPedidos;
        }

        private void CargarComboboxes()
        {


            cmbRubro.Items.Add("Otras industrias");
            cmbRubro.Items.Add("Servicios / Consultoría de Software / Digital");
            cmbRubro.Items.Add("Producto basado en Software");

            cmbSeIdentifica.Items.Add("Hombre");
            cmbSeIdentifica.Items.Add("Mujer");
            cmbSeIdentifica.Items.Add("Otro");

            cmbNivelEstudios.Items.Add("Doctorado");
            cmbNivelEstudios.Items.Add("Posdoctorado");
            cmbNivelEstudios.Items.Add("Posgrado");
            cmbNivelEstudios.Items.Add("Primario");
            cmbNivelEstudios.Items.Add("Secundario");
            cmbNivelEstudios.Items.Add("Terciario");

            cmbJornada.Items.Add("Full-Time");
            cmbJornada.Items.Add("Part-Time");
            cmbJornada.Items.Add("Freelance");

            cmbRecomiendaEmpresa.Items.Add("De 0 a 3");
            cmbRecomiendaEmpresa.Items.Add("De 3 a 7");
            cmbRecomiendaEmpresa.Items.Add("Más de 7");

            cmbSalarioNeto.Items.Add("Hasta 50.000");
            cmbSalarioNeto.Items.Add("De 50.000 a 150.000");
            cmbSalarioNeto.Items.Add("Más de 150.000");

            cmbAniosExperiencia.Items.Add("0");
            cmbAniosExperiencia.Items.Add("Hasta 10");
            cmbAniosExperiencia.Items.Add("Más de 10");

            cmbEdad.Items.Add("Hasta 30 años");
            cmbEdad.Items.Add("Entre 30 y 50");
            cmbEdad.Items.Add("Más de 50");

            cmbPersonalACargo.Items.Add("0");
            cmbPersonalACargo.Items.Add("Hasta 10");
            cmbPersonalACargo.Items.Add("Más de 10");

            cmbPuesto.Items.Add("Help Desk");
            cmbProvincia.Items.Add("Ciudad Autónoma de Buenos Aires");

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

    }
}
