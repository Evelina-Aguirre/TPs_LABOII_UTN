using AnalyticsEntidades;
using EstadisticasEntidades;
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

            cmbSeIdentifica.SelectedItem = RandomEnumerado<Enumerados.ESexo,string>.CrearArrayDesdeEnum<Enumerados.ESexo>();
            cmbJornada.SelectedItem = RandomEnumerado<Enumerados.EJornada, string>.CrearArrayDesdeEnum<Enumerados.EJornada>();
            cmbAniosExperiencia.SelectedItem = rnd.Next(0,60).ToString();
            cmbEdad.SelectedItem = rnd.Next(18, 65).ToString();
            cmbNivelEstudios.SelectedItem = RandomEnumerado<Enumerados.EEstudios, string>.CrearArrayDesdeEnum<Enumerados.EEstudios>();
            cmbPersonalACargo.SelectedItem = rnd.Next(0, 2000).ToString();
            cmbProvincia.SelectedItem = RandomEnumerado<Enumerados.EProvincia, string>.CrearArrayDesdeEnum<Enumerados.EProvincia>();
            cmbPuesto.SelectedItem = RandomEnumerado<Enumerados.EPuesto, string>.CrearArrayDesdeEnum<Enumerados.EPuesto>();
            cmbRecomiendaEmpresa.SelectedItem = rnd.Next(0, 10).ToString();
            cmbRubro.SelectedItem = RandomEnumerado<Enumerados.ERubro, string>.CrearArrayDesdeEnum<Enumerados.ERubro>();
            cmbSalarioNeto.SelectedItem = rnd.Next(10000, 9999999).ToString();


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

        private void CargarComboboxes()
        {
           
            for (int i = 0; i < 50; i++)
            {
                cmbAniosExperiencia.Items.Add(i);
            }
            cmbAniosExperiencia.SelectedIndex = 1;
            for (int i = 18; i < 65; i++)
            {
                cmbEdad.Items.Add(i);
            }
            cmbEdad.SelectedIndex = 1;
            for (int i = 0; i < 1000; i++)
            {
                cmbPersonalACargo.Items.Add(i);
            }
            cmbPersonalACargo.SelectedIndex = 1;
            for (int i = 0; i < 11; i++)
            {
                cmbRecomiendaEmpresa.Items.Add(i);
            }
            cmbRecomiendaEmpresa.SelectedIndex = 1;
            for (int i = 10000; i <9999999 ; i++)
            {
                cmbSalarioNeto.Items.Add(i);
                i+=20000;
            }
            cmbSalarioNeto.SelectedIndex = 1;
            cmbSeIdentifica.DataSource = Enum.GetNames(typeof(Enumerados.ESexo));
            cmbJornada.DataSource = Enum.GetNames(typeof(Enumerados.EJornada));
            cmbNivelEstudios.DataSource = Enum.GetNames(typeof(Enumerados.EEstudios));
            cmbProvincia.DataSource = Enum.GetNames(typeof(Enumerados.EProvincia));
            cmbPuesto.DataSource = Enum.GetNames(typeof(Enumerados.EPuesto));
            cmbRubro.DataSource = Enum.GetNames(typeof(Enumerados.ERubro));
            

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string identifica = cmbSeIdentifica.SelectedItem.ToString();
            int edad = Convert.ToInt32(cmbEdad.SelectedItem.ToString());

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

            ConexionDB.InsertarRegistro(nuevaEncuesta);
            MessageBox.Show("Se registró la encuesta correctamente!");

        }
    }
}
