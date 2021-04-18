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
            this.lblResultado.Text = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperator.Text).ToString();
          
            //Botones para conversiones permanecen deshabilitados en caso de que el texto del labelResultado sea nulo.
            if (this.lblResultado.Text == null)
            {
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = false;
            }
            else
            {
                //Compruebo que el valor del LabelResultado sea mayor a 0 para habilitar el botón de convertir a binario. 
                double resultadoLbl = double.Parse(this.lblResultado.Text);
                
                if (resultadoLbl >0)
                {
                    this.btnConvertirADecimal.Enabled = false;
                    this.btnConvertirABinario.Enabled = true;
                }
                else
                {
                    this.btnConvertirADecimal.Enabled = false;
                    this.btnConvertirABinario.Enabled = false;
                }
                
            }

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
            if(!double.TryParse(lblResultado.Text, out double numeroLblResultado))
            {
                MessageBox.Show("Error.\nPor favor ingrese valores numéricos para seguir operando.");///////////////REVGISAR ESTO/////////////Tengo q controlar la ex. pero no sé en q casos la tomaría.
                this.txtNumero1.Text = "";
                this.txtNumero2.Text = "";
                this.cmbOperator.SelectedIndex = 0;
                this.btnConvertirABinario.Enabled = false;
                this.btnConvertirADecimal.Enabled = false;
                this.lblResultado.Text = "";

            }
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

        
    }
}
