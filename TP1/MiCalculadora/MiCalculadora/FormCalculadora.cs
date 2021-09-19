using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.lstOperaciones.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private static double Operar(string numero1, string numero2,string operador)
        {
            char.TryParse(operador, out char operadorAChar);
            Operando num1 = new Operando(numero1.Replace('.',','));
            Operando num2 = new Operando (numero2.Replace('.', ','));
            return Calculadora.Operar(num1, num2, operadorAChar);

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;
            if(this.cmbOperador.SelectedItem == "")
            {
                operador = "+";
            }
            else
            {
                operador = this.cmbOperador.SelectedItem.ToString();
            }

            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            this.btnConvertirABinario.Enabled = true;
            this.lstOperaciones.Items.Add((this.txtNumero1.Text + " " + operador + " " + this.txtNumero2.Text + " = " + this.lblResultado.Text + "\n").ToString());

        }


        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroDecimal = new Operando();
            this.lblResultado.Text = numeroDecimal.DecimalBinario(this.lblResultado.Text);
            this.lstOperaciones.Items.Add("Conv. Decimal a Binario:");
            this.lstOperaciones.Items.Add(this.lblResultado.Text);
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = true;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroBinario = new Operando();
            this.lblResultado.Text = numeroBinario.BinarioDecimal(this.lblResultado.Text);
            this.lstOperaciones.Items.Add("Conv. Binario a Decimal:");
            this.lstOperaciones.Items.Add(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
