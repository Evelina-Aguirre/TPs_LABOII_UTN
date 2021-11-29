using AnalyticsEntidades;
using Archivos;
using charts4;
using Estadísticas;
using EstadisticasEntidades;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaz
{
    
    public partial class FrmExportar : Form
    {
        int m, mx, my;

        public FrmExportar()
        {
            InitializeComponent();
        }

     

        private bool GuardarTodoxml()
        {
            string consultaActual = UI_AnalisisEncuestas.consultaActual;
            Xml xml1 = new Xml();
            xml1.GuardarDatos(ConexionDB.TraerResultadoEncuestas());

            Task.Run(() =>
            {

                if (this.pgbXmlConsultaActual.InvokeRequired)
                {
                    this.pgbXmlConsultaActual.BeginInvoke((MethodInvoker)delegate ()
                    {
                        CargarProgresBarXmlTodosLosRegistros();
                    });
                }

            });
            return true;

        }

        private  void GuardarActualxml()
        {
            string consultaActual = UI_AnalisisEncuestas.consultaActual;

            if (string.IsNullOrEmpty(consultaActual))
            {
                MessageBox.Show("No realizó ninguna consulta.");
            }
            else
            {
                Xml xml = new Xml();
                xml.GuardarDatos(ConexionDB.TraeResultadoEncuestas(ConsultasDB.DevuelveStringConsultaBasicaADB(consultaActual)));

                 Task.Run(() =>
                {

                    if (this.pgbXmlConsultaActual.InvokeRequired)
                    {
                        this.pgbXmlConsultaActual.BeginInvoke((MethodInvoker)delegate ()
                        {
                            CargarProgresBarXmlConsultaActual();
                        });
                    }

                });
            }
        }

        private  void GuardarActualJson()
        {
            string consultaActual = UI_AnalisisEncuestas.consultaActual;
            if (string.IsNullOrEmpty(consultaActual))
            {
                MessageBox.Show("Aun no realizó ninguna consulta.");
            }
            else
            {
                Xml json = new Xml();
                json.GuardarDatos(ConexionDB.TraeResultadoEncuestas(ConsultasDB.DevuelveStringConsultaBasicaADB(consultaActual)));

                 Task.Run(() =>
                {

                    if (this.pgbXmlConsultaActual.InvokeRequired)
                    {
                        this.pgbXmlConsultaActual.BeginInvoke((MethodInvoker)delegate ()
                        {
                            CargarProgresBarJsonConsultaActual();
                        });
                    }

                });

            }


        }

        private  void GuardarTodoJson()
        {
            Json json1 = new Json();
            json1.GuardarDatos(ConexionDB.TraerResultadoEncuestas());

            Task.Run(() =>
            {

                if (this.pgbXmlConsultaActual.InvokeRequired)
                {
                    this.pgbXmlConsultaActual.BeginInvoke((MethodInvoker)delegate ()
                    {
                        CargarProgresBarJsonTodosLosRegistros();
                    });
                }

            });

        }
        

        private void CargarProgresBarXmlConsultaActual()
        {

            pgbXmlConsultaActual.Maximum = 50000;
            pgbXmlConsultaActual.Minimum = 0;
            pgbXmlConsultaActual.Value = 0;
            pgbXmlConsultaActual.Step = 1;
            for (int i = pgbXmlConsultaActual.Minimum; i < pgbXmlConsultaActual.Maximum; i = i + pgbXmlConsultaActual.Step)
            {
                pgbXmlConsultaActual.PerformStep();
            }
        }

        private void CargarProgresBarXmlTodosLosRegistros()
        {

            pgbXmlTodosLosRegistros.Maximum = 900000;
            pgbXmlTodosLosRegistros.Minimum = 0;
            pgbXmlTodosLosRegistros.Value = 0;
            pgbXmlTodosLosRegistros.Step = 1;

            for (int i = pgbXmlTodosLosRegistros.Minimum; i < pgbXmlTodosLosRegistros.Maximum; i = i + pgbXmlTodosLosRegistros.Step)
            {
                pgbXmlTodosLosRegistros.PerformStep();
            }
        }

        private void CargarProgresBarJsonConsultaActual()
        {

            pgbJsonConsultaActual.Maximum = 60000;
            pgbJsonConsultaActual.Minimum = 0;

            pgbJsonConsultaActual.Value = 0;
            pgbJsonConsultaActual.Step = 1;

            for (int i = pgbJsonConsultaActual.Minimum; i < pgbJsonConsultaActual.Maximum; i = i + pgbJsonConsultaActual.Step)
            {
                pgbJsonConsultaActual.PerformStep();
            }
        }

        private void CargarProgresBarJsonTodosLosRegistros()
        {

            pgbJsonTodosLosRegistros.Maximum = 700000;
            pgbJsonTodosLosRegistros.Minimum = 0;

            pgbJsonTodosLosRegistros.Value = 0;
            pgbJsonTodosLosRegistros.Step = 1;


            for (int i = pgbJsonTodosLosRegistros.Minimum; i < pgbJsonTodosLosRegistros.Maximum; i = i + pgbJsonTodosLosRegistros.Step)
            {

                pgbJsonTodosLosRegistros.PerformStep();
            }
        }

        private void FrmExportar_Load(object sender, EventArgs e)
        {


        }


        private void btnExportarXmlConsultaActual_Click(object sender, EventArgs e)
        {
            GuardarActualxml();
           
        }

        private void btnExportarXmlTodasLasConsultas_Click(object sender, EventArgs e)
        {
            
            GuardarTodoxml();

        }

        private void FrmExportar_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuardarActualJson();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            GuardarTodoJson();
        }

        private void lnklbCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Task.WaitAll();
            MessageBox.Show("La ventana se cerrará al finalizar de resguardar los archivos.");
            this.Hide();
        }

        private void btnCancelarOperacion_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            cancellationTokenSource.Cancel();
            MessageBox.Show("Se cancelo el guardado.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           

        }

        private void FrmExportar_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void FrmExportar_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }
        

    }
}


