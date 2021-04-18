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

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperator.SelectedIndex = 0;
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = false;
        }
        private static double Operar (string numero1, string numero2, string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            resultado = Calculadora.Operar(num1, num2, operador);
            return resultado;

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperator.Text).ToString();
            //VER VALIDACIONES, COMO PARA PROBAR.
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperator.SelectedIndex = 0;
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
            this.lblResultado.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            this.lblResultado.Text = num.DecimalBinario(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = true;
            this.btnConvertirABinario.Enabled = false;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            this.lblResultado.Text = num.BinarioDecimal(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = true;
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
