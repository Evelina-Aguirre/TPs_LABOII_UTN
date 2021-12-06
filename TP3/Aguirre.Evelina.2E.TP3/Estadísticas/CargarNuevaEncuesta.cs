using AnalyticsEntidades;
using Archivos;
using EstadisticasEntidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaz
{
    public partial class CargarNuevaEncuesta : Form
    {
        int m, mx, my;
        public CargarNuevaEncuesta()
        {
            InitializeComponent();
        }

        private void CargarNuevaEncuesta_Load(object sender, EventArgs e)
        {
            CargarComboboxes();
        }

        private void lnklbCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void lnklbMinimizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            cmbSeIdentifica.Text = ClaseGenerica<Enumerados.ESexo>.ObtenerValorAleatorioEnumerado<Enumerados.ESexo>().ToString();
            cmbJornada.SelectedIndex = rnd.Next(0, 2);
            cmbAniosExperiencia.SelectedIndex = rnd.Next(0, 2);
            cmbEdad.SelectedIndex = rnd.Next(0, 30);
            cmbNivelEstudios.Text = ClaseGenerica<Enumerados.ENivelEstudio>.ObtenerValorAleatorioEnumerado<Enumerados.ENivelEstudio>().ToString();
            cmbPersonalACargo.SelectedIndex = rnd.Next(0, 10);
            cmbProvincia.SelectedIndex = 0;
            cmbPuesto.SelectedIndex = 0;
            cmbRecomiendaEmpresa.SelectedIndex = rnd.Next(0, 10);
            cmbRubro.SelectedIndex = rnd.Next(0, 2);
            cmbSalarioNeto.SelectedIndex = rnd.Next(0, 40);


        }


        private void CargarComboboxes()
        {
           
            for (int i = 0; i < 50; i++)
            {
                cmbAniosExperiencia.Items.Add(i);
            }
            
            for (int i = 18; i < 65; i++)
            {
                cmbEdad.Items.Add(i);
            }

            for (int i = 0; i < 1000; i++)
            {
                cmbPersonalACargo.Items.Add(i);
            }
            
            for (int i = 0; i < 11; i++)
            {
                cmbRecomiendaEmpresa.Items.Add(i);
            }
            
            for (int i = 30000; i <9999999 ; i++)
            {
                cmbSalarioNeto.Items.Add(i);
                i+=20000;
            }
            
            cmbRubro.Items.Add("Otras industrias");
            cmbRubro.Items.Add("Servicios / Consultoría de Software / Digital");
            cmbRubro.Items.Add("Producto basado en Software");

            cmbSeIdentifica.DataSource = Enum.GetNames(typeof(Enumerados.ESexo));
            cmbNivelEstudios.DataSource = Enum.GetNames(typeof(Enumerados.ENivelEstudio));


            cmbJornada.Items.Add("Full-Time");
            cmbJornada.Items.Add("Part-Time");
            cmbJornada.Items.Add("Freelance");

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string identifica = cmbSeIdentifica.SelectedItem.ToString();
            int edad = Convert.ToInt32(cmbEdad.SelectedItem.ToString());

            try
            {


                Encuesta nuevaEncuesta = new Encuesta(cmbSeIdentifica.SelectedItem.ToString(),
                    Convert.ToInt32(cmbEdad.SelectedItem.ToString()),
                    cmbProvincia.SelectedItem.ToString(),
                    Convert.ToInt32(cmbAniosExperiencia.SelectedItem.ToString()),
                    Convert.ToInt32(cmbPersonalACargo.SelectedItem.ToString()),
                    cmbNivelEstudios.SelectedItem.ToString(),
                    "Completado",
                    cmbPuesto.SelectedItem.ToString(),
                    cmbJornada.SelectedItem.ToString(),
                    Convert.ToDouble(cmbSalarioNeto.SelectedItem.ToString()),
                    cmbRubro.SelectedItem.ToString(),
                    Convert.ToInt32(cmbRecomiendaEmpresa.SelectedItem.ToString()));
                
                CalculoEstadistica.listaDatosPedidos.Add(nuevaEncuesta);
                Xml auxXml = new Xml();
                auxXml.GuardarDatos(CalculoEstadistica.listaDatosPedidos);

            }
            catch(DatoInvalido ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ValorFueraDeRangoException ex)
            {
                MessageBox.Show(ex.Message);
            }

           
            MessageBox.Show("Se registró la encuesta correctamente!");

        }
        private void CargarNuevaEncuesta_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void CargarNuevaEncuesta_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void CargarNuevaEncuesta_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
