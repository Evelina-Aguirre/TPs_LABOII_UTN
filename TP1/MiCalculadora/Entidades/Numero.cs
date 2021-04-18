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

        /// <summary>
        /// Constructor
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// constructor takes a double value
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) : this()
        {
            this.numero = numero;
        }

        /// <summary>
        /// constructor takes a string value
        /// </summary>
        /// <param name="strNumero"></param>
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
                //Pido que devuelva false y termine la función si encuentra que alguno de los valores de la cadena es diferente de 0 o de 1. 
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
 
            }
            return true;
        }

        /// <summary>
        ///  Validate that it is a binary number and then convert it to decimal, if it is not possible, it returns error: "Invalid value".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            int ahoraDecimal = 0;
            int lengthBinario = binario.Length;
            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    lengthBinario--;
                    //Para convertirlo a decimal, elevo la base 2 al índice de las posiciones que contengan 1 y sumo los valores. 
                    if (binario[i] == '1')
                    {
                        ahoraDecimal = (int)Math.Pow(2, lengthBinario) + ahoraDecimal;
                    }
                }

                return ahoraDecimal.ToString();
            }

            return " Valor Inválido2";
        }

        /// <summary>
        /// Converts a number from a decimal base to a binary base.
        /// It validates if it is greater than 0, and takes the integer part to operate.
        /// </summary>
        /// <param name="numero"></param> Receive a decimal base number.
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string ahoraBinario = "";
            int parteEntera = (int)numero;
            int resto;

            if(parteEntera >=0)
            {
                while(parteEntera > 0)
                {
                    resto = parteEntera % 2;
                    parteEntera = parteEntera / 2;
                    ahoraBinario = resto.ToString() + ahoraBinario;
                }
            }
            else
            {
                return "Valor Inválido1";
            }
            return ahoraBinario;
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
            string resultado = "0";
            if (double.TryParse(numero, out esNumero))
            {
                resultado = DecimalBinario(esNumero);
                //Dentro de este método se valida a su vez que el núm. sea mayor a 0 y se toma de este solo la parte entera.
                
            }
            return resultado;

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
