using System;
namespace Entidades
{
    public class Operando
    {

        private double numero;

        public Operando()
        {
            this.numero = 0;
        }

        public Operando(double numero):this()
        {
            this.numero = numero;
        }

        public Operando(string numero) : this()
        {
            
                this.Numero = numero;

        }

        /// <summary>
        /// "Number" Property, validates that the number we are trying to assign to the attribute is in numeric format.
        /// </summary>
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Try to convert the string representation of a number to a double value, returns 0 in case of not being able to do it.  
        /// </summary>
        /// <param name="strNumero">String value obtained by parameter</param>
        /// <returns></returns>
        private static double ValidarOperando(string strNumero)
        {
           
            if (double.TryParse(strNumero, out double numero))
                return numero;
            else
                return 0;
        }

        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if(binario[i] != '0' && binario[i]!= '1')
                {
                    return false;
                }
            }
            return true;
        }

        public string BinarioDecimal(string binario)
        {
            int esDecimal = 0;
            int pocisionB = binario.Length;

            if(EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    pocisionB--;

                    if(binario[i] == '1')
                    {
                        esDecimal = (int)Math.Pow(2, pocisionB) + esDecimal; 
                    }
                }
                return esDecimal.ToString();
            }
            return "Valor Inválido";
        }

        public string DecimalBinario(string numero)
        {
            double esDouble;
            
            if(double.TryParse(numero, out esDouble))
            {
                return DecimalBinario(esDouble);
            }
            return "Valor Invalido";
            //Retorna "valor inválido" en caso de que los datos que lleguen por parámetro no sean un valor numérico, al llamar 
            //a su sobrecarga, valida asimismo que sea <= a 0 y que esté compuesto sólo por unos y ceros.

        }

        public string DecimalBinario(double numero)
        {
            int entero = (int)numero;
            int resto;
            string binario = null;

            if(entero >= 0)
            {
                do
                {
                    resto = entero % 2;
                    entero = entero / 2;
                    binario = resto.ToString() + binario;

                } while (entero > 0);
            }
            return binario;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            return double.MinValue;
        }

    }
}
