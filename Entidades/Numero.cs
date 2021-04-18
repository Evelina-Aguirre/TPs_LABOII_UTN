using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;


        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero) : this()
        {
            this.numero = numero;
        }

        public Numero(string strNumero) : this()
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// It checks that the received value is numeric, and returns it in double format. Otherwise, it returns 0.
        /// </summary>
        /// <param name="strNumero"></param> string value obtained by parameter.
        /// <returns></returns>
        private static double ValidarNumero(string strNumero)
        {
            double num;
            //Pido que cambie coma por punto antes de validar que se haya ingresado un número ************ PROBAR
            strNumero.Replace(",", ".");

            if (double.TryParse(strNumero, out num))
            {
                return num;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        ///Validates that it is a number format and assigns it to the attribute.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        ///Validate that the character string consists only of characters '0' or '1'.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '0' || binario[i] == '1')
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  Validate that it is a binary number and then convert it to decimal, if it is not possible, it returns error: "Invalid value".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int ahoraDecimal = 0;

                for (int i = 0; i < binario.Length; i++)
                {
                    //Para convertirlo a decimal, elevo la base 2 al índice de las posiciones que contengan 1 y sumo los valores. 
                    if (binario[i] == '1')
                    {
                        ahoraDecimal = (int)Math.Pow(2, i) + ahoraDecimal;
                    }
                }

                return ahoraDecimal.ToString();
            }

            return " Valor Inválido ";
        }

        /// <summary>
        /// Converts a number from a decimal base to a binary base.
        /// It validates if it is greater than 0, and takes the integer part to operate.
        /// </summary>
        /// <param name="numero"></param> Receive a decimal base number.
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            if (numero >= 0)
            {
                string ahoraBinario = "";
                //Utilizo Math.Truncate para tomar sólo la parte entera de un número de punto flotante.
                Math.Truncate(numero);

                while (numero > 0)
                {
                    //Tomo el resto y lo concateno para convertirlo a Binario.
                    ahoraBinario += numero % 2;
                    //Divido para poder tomar el resto de la mitad del número actual en la próxima iteración.
                    numero = numero / 2;
                }
                return ahoraBinario;
            }
            return "Valor Inválido";
        }


        /// <summary>
        /// Converts a number from a decimal base to a binary base from a value given in string format. 
        ///(It previously validates that it is a number, if it is greater than 0, and takes the integer part)
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double esNumero;

            if (double.TryParse(numero, out esNumero))
            {
                DecimalBinario(esNumero);
                //Dentro de este método se valida a su vez que el núm. sea mayor a 0 y se toma de este solo la parte entera.
            }
            return "Valor Inválido";
        }

        /// <summary>
        /// This function returns the sum between two numbers.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// This function returns the subtraction between two numbers.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// This function returns the multiplication between two numbers.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// This function returns the division between two numbers, previously validating that the dividend is different from 0.
        /// In which case it wil return the smallest value that goes into a double parameter.   
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }


    }
}
