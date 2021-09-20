using Entidades;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla y 
        /// deshabilita los botones de conversión Binario-Decimal/Decimal-Binario.
        /// </summary>
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

        /// <summary>
        /// Despliega una pantalla solicitando confirmación al usuario antes de cerrar la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (respuesta == DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        /// <summary>
        /// Carga el formulario, con los espacios TextBox, ComboBox y Label en blanco y los botones de converción Binario-Decimal/Decimal-Binario
        /// Deshabilitados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        /// <summary>
        /// Deja en blanco TextBox, ComboBox y Label, y deshabilita los botones que permiten la conversión binario-decimal/decimal-binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Crea dos objetos de la clase "Operando" con los valores obtenidos por parámetro y los 
        /// pasa al método Operar de la clase "Calculadora" para que realice el cálculo devolviendo el valor obtenido.
        /// </summary>
        /// <param name="numero1">Valor en formato string que se usará para contruir el objeto Operando</param>
        /// <param name="numero2">Valor en formato string que se usará para contruir el objeto Operando</param>
        /// <param name="operador">Valor en formato string que se convertirá a char previo a realizar el cálculo</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            char.TryParse(operador, out char operadorAChar);
            Operando num1 = new Operando(numero1.Replace('.', ','));
            Operando num2 = new Operando(numero2.Replace('.', ','));
            return Calculadora.Operar(num1, num2, operadorAChar);

        }

        /// <summary>
        /// Recoge los valores ingresados por los textBoxs y el comboBox, y realiza la operación solicitada,
        /// imprimiendo el resultado obtenido en el label destinado a esto y en el listBox que registra las operaciones realizadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;

            /* Por proligidad se chequea que lo seleccionado en el combobox es o no un espacio vacío con la intención de, en caso de serlo
             imprimir el carácter '+' en el listBox, siendo la operación que se realizará, en vez de quedar un espacio vacio. */
            if (this.cmbOperador.SelectedItem.ToString() == "")
            {
                operador = "+";
            }
            else
            {
                operador = this.cmbOperador.SelectedItem.ToString();
            }

            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
            this.btnConvertirABinario.Enabled = true;
            this.lstOperaciones.Items.Add((this.txtNumero1.Text + " "
                + operador + " "
                + this.txtNumero2.Text + " = "
                + this.lblResultado.Text + "\n").ToString());

        }

        /// <summary>
        /// Convierte el valor que esté en ese momento en el labelResultado a Binario, deshabilitando el botón que permitió esta operación
        /// y habilitando el que permite volver a pasar el número a Decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numeroDecimal = new Operando();
            this.lblResultado.Text = numeroDecimal.DecimalBinario(this.lblResultado.Text);
            this.lstOperaciones.Items.Add("Conv. Decimal a Binario:");
            this.lstOperaciones.Items.Add(this.lblResultado.Text);
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Convierte el valor que esté en ese momento en el labelResultado a Decimal, deshabilitando el botón que permitió esta operación
        /// y habilitando el que permite volver a pasar el número a Binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numeroBinario = new Operando();
            this.lblResultado.Text = numeroBinario.BinarioDecimal(this.lblResultado.Text);
            this.lstOperaciones.Items.Add("Conv. Binario a Decimal:");
            this.lstOperaciones.Items.Add(this.lblResultado.Text);
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
