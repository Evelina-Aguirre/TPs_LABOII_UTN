using AnalyticsEntidades;
using EstadisticasEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using UserInterfaz;
using Archivos;
using System.Threading.Tasks;
using System.Threading;


namespace Estadísticas
{
    public partial class FrmResultadosEncuestaSueldosIT : Form
    {
        

        int m, mx, my;
        private System.ComponentModel.IContainer components = null;
        System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        public static string consultaActual = string.Empty;

       
        public FrmResultadosEncuestaSueldosIT()
        {
            InitializeComponent();
            ConsultasDB.ceroRegistrosEvento += InformaRegistroCero;
        }

        private void InformaRegistroCero()
        {
            MessageBox.Show("No se encontraron coincidencias con la búsqueda");
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Limpiar();
            CargarComboboxes();
            dgDatos.DataSource = null;
            dgDatos.DataSource = ConexionDB.TraerResultadoEncuestas(); 
        }

        private void lnklbCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void lnklbMinimizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            cmbSeIdentifica.SelectedIndex = 1;
            cmbAniosExperiencia.SelectedIndex = 1;
            cmbEdad.SelectedIndex = 1;
            cmbJornada.SelectedIndex = 1;
            cmbNivelEstudios.SelectedIndex = 1;
            cmbPersonalACargo.SelectedIndex = 1;
            cmbProvincia.SelectedIndex = 1;
            cmbPuesto.SelectedIndex = 1;
            cmbRecomiendaEmpresa.SelectedIndex = 1;
            cmbRubro.SelectedIndex = 1;
            cmbSalarioNeto.SelectedIndex = 1;

        }

        private void Limpiar()
        {
            
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

            dgDatos.DataSource = null;
            dgDatos.DataSource = ConexionDB.TraerResultadoEncuestas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aux = DevuelveStringConsultaDBSegunCheckedBoxesSeleccionados();

            dgDatos.DataSource = null;
            dgDatos.DataSource =  ConexionDB.TraeResultadoEncuestas(ConsultasDB.DevuelveStringConsultaBasicaADB(aux));

            int cantegistrosUltimaConsulta = ConsultasDB.CuentaRegistrosDeUnaConsulta(aux);
            int cantRegistrosTotal= ConsultasDB.CuentaRegistrosDeUnaConsulta();

            float porcentaje = Encuesta.CalculoPorcentaje(cantegistrosUltimaConsulta, cantRegistrosTotal);

            lblTotal.Text = $"{cantRegistrosTotal}";
            int promedioSueldoTotal =(int) ConsultasDB.PromedioSueldoDeLaConsulta();
            lblPromedioTotal.Text = promedioSueldoTotal.ToString();

            lblTotalConsulta.Text = cantegistrosUltimaConsulta.ToString();
            int promedioSueldoConsulta = (int)ConsultasDB.PromedioSueldoDeLaConsulta(aux);
            lblPromedioConsulta.Text = promedioSueldoConsulta.ToString();
            lblPorcentaje.Text = $"{porcentaje}%";

            consultaActual = aux;




        }

        private bool hayAlgoMarcado()
        {
            if (chkSeIdentifica.Checked || chkEdad.Checked || chkProvincia.Checked || chkExperiencia.Checked
                || chkPersonalACargo.Checked || chkNivelEstudios.Checked || chkPuesto.Checked || chkJornada.Checked
                || chkSalario.Checked || chkRubro.Checked || chkRecomienda.Checked)
            {
                return true;
            }
            return false;
        }

        private List<string> quienEstaTildado()
        {
            List<string> auxLista = new List<string>();
            string auxString;

            
                if (chkSeIdentifica.Checked)
                {
                    auxString = "chkSeIdentifica";
                    auxLista.Add(auxString);
                }
                if (chkEdad.Checked)
                {
                    auxString = "chkEdad";
                    auxLista.Add(auxString);
                }

                if (chkProvincia.Checked)
                {
                    auxString = "chkProvincia";
                    auxLista.Add(auxString);
                }

                if (chkExperiencia.Checked)
                {
                    auxString = "chkExperiencia";
                    auxLista.Add(auxString);
                }

                if (chkPersonalACargo.Checked)
                {
                    auxString = "chkPersonalACargo";
                    auxLista.Add(auxString);
                }

                if (chkNivelEstudios.Checked)
                {
                    auxString = "chkNivelEstudios";
                    auxLista.Add(auxString);
                }

                if (chkPuesto.Checked)
                {
                    auxString = "chkPuesto";
                    auxLista.Add(auxString);
                }

                if (chkJornada.Checked)
                {
                    auxString = "chkJornada";
                    auxLista.Add(auxString);
                }

                if (chkSalario.Checked)
                {
                    auxString = "chkSalario";
                    auxLista.Add(auxString);
                }

                if (chkRubro.Checked)
                {
                    auxString = "chkRubro";
                    auxLista.Add(auxString);
                }

                if (chkRecomienda.Checked)
                {
                    auxString = "chkRecomienda";
                    auxLista.Add(auxString);
                }

            
            return auxLista;

        }

        private void DehabilitarCheckbox()
        {
            if (chkSeIdentifica.Checked)
            {
                chkSeIdentifica.Enabled = true;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;


            }
            else if (chkEdad.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = true;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;

            }

            else if (chkProvincia.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = true;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;


            }

            else if (chkExperiencia.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = true;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;



            }

            else if (chkPersonalACargo.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = true;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;


            }

            else if (chkNivelEstudios.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = true;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;



            }

            else if (chkPuesto.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = true;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;

            }

            else if (chkJornada.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = true;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;

            }

            else if (chkSalario.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = true;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = false;

            }

            else if (chkRubro.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = true;
                chkRecomienda.Enabled = false;

            }

            else if (chkRecomienda.Checked)
            {

                chkSeIdentifica.Enabled = false;
                chkEdad.Enabled = false;
                chkProvincia.Enabled = false;
                chkExperiencia.Enabled = false;
                chkPersonalACargo.Enabled = false;
                chkNivelEstudios.Enabled = false;
                chkPuesto.Enabled = false;
                chkJornada.Enabled = false;
                chkSalario.Enabled = false;
                chkRubro.Enabled = false;
                chkRecomienda.Enabled = true;


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private string DevuelveStringConsultaDBSegunCheckedBoxesSeleccionados()
        {
            List<string> auxListaTildados = new List<string>();
            List<Encuesta> auxListEncuesttas = ConexionDB.TraerResultadoEncuestas();
           
            auxListaTildados = quienEstaTildado();
            string cadenaResultanteConsultaDB= " ";
            int contador = 0;


            foreach (string item in auxListaTildados)
            {

                if(contador == 0)
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
                        Enumerados.ERecomienda enumAux = (Enumerados.ERecomienda)Enum.Parse(typeof(Enumerados.ERecomienda), cmbRecomiendaEmpresa.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux);

                        break;
                    case "chkRubro":

                        Enumerados.ERubro enumAux1 = (Enumerados.ERubro)Enum.Parse(typeof(Enumerados.ERubro), cmbRubro.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux1);

                        break;
                    case "chkSalario":

                        Enumerados.ESalario enumAux2 = (Enumerados.ESalario)Enum.Parse(typeof(Enumerados.ESalario), cmbSalarioNeto.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux2);

                        break;
                    case "chkJornada":
                        Enumerados.EJornada enumAux3 = (Enumerados.EJornada)Enum.Parse(typeof(Enumerados.EJornada), cmbJornada.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux3);
                        break;

                    case "chkPuesto":

                        Enumerados.EPuesto enumAux4 = (Enumerados.EPuesto)Enum.Parse(typeof(Enumerados.EPuesto), cmbPuesto.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux4);

                        break;

                    case "chkNivelEstudios":
                        Enumerados.EEstudios enumAux5 = (Enumerados.EEstudios)Enum.Parse(typeof(Enumerados.EEstudios), cmbNivelEstudios.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux5);
                        break;

                    case "chkPersonalACargo":
                        Enumerados.EPersonasaACargo enumAux6 = (Enumerados.EPersonasaACargo)Enum.Parse(typeof(Enumerados.EPersonasaACargo), cmbPersonalACargo.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux6);
                        break;

                    case "chkExperiencia":
                        Enumerados.EExperiencia enumAux7 = (Enumerados.EExperiencia)Enum.Parse(typeof(Enumerados.EExperiencia), cmbAniosExperiencia.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux7);
                        break;

                    case "chkProvincia":
                        Enumerados.EProvincia enumAux8 = (Enumerados.EProvincia)Enum.Parse(typeof(Enumerados.EProvincia), cmbProvincia.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux8);

                        break;

                    case "chkEdad":
                        Enumerados.EEdad enumAux9 = (Enumerados.EEdad)Enum.Parse(typeof(Enumerados.EEdad), cmbEdad.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux9);

                        break;

                    case "chkSeIdentifica":
                        Enumerados.ESexo enumAux10 = (Enumerados.ESexo)Enum.Parse(typeof(Enumerados.ESexo), cmbSeIdentifica.SelectedItem.ToString());
                        cadenaResultanteConsultaDB += ConsultasDB.OpcionElegida(enumAux10);
                        break;
                }
                

            }
            return cadenaResultanteConsultaDB;
        }

        private void FrmResultadosEncuestaSueldosIT_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void FrmResultadosEncuestaSueldosIT_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void FrmResultadosEncuestaSueldosIT_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarNuevaEncuesta nuevaEncuesta = new CargarNuevaEncuesta();
            nuevaEncuesta.ShowDialog();
        }

        private async  void btnExportar_Click(object sender, EventArgs e)
        {
            FrmExportar frmExportar = new FrmExportar();
            await Task.Run(() =>
           {
               frmExportar.ShowDialog();
           });
        }
    }


}
