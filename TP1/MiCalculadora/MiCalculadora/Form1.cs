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
    {   /// <summary>
        ///Initializes the components. 
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On Load the aplication set combo operator in null and disables Converts buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperator.SelectedIndex = 0;
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = false;
        }
        /// <summary>
        ///Recives two values and an operator and returns the result between the required operation.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar (string numero1, string numero2, string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            resultado = Calculadora.Operar(num1, num2, operador);
            return resultado;

        }
        /// <summary>
        ///Performs the requested calculation between two numbers and enables conversion 
        ///buttons between bases if the result of this operation is a value greater than 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                double resultadoLbl;
                if (double.TryParse(this.lblResultado.Text, out resultadoLbl))
                {
                    if (resultadoLbl > 0)
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

        }
        /// <summary>
        /// It enables the button to clear, empty, result boxes and entered values ​​in addition to disabling conversion buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperator.SelectedIndex = 0;
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
            this.lblResultado.Text = "";
        }
        /// <summary>
        /// Close app window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// It takes the value of lblResult and converts it to Binary. Disable Decimal to Binary conversion button and enable Binary to Decimal button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            this.lblResultado.Text = num.DecimalBinario(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = true;
            this.btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// It takes the value of lblResult and converts it to Binary. Disable Binary to Decimal conversion button and enable  Decimal to Binary button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            this.lblResultado.Text = num.BinarioDecimal(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = true;
        }

       
    }
}
