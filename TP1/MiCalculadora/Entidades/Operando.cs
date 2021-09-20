using System;
namespace Entidades
{
    public class Operando
    {
        //ATRIBUTO
        private double numero;

        //CONTRUCTORES
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Llama a la propiedad Numero para validar que el string recibido puede ser convertido a formato double antes de intentar asignarlo al atributo.
        /// </summary>
        /// <param name="numero"></param>
        public Operando(string numero) : this()
        {

            this.Numero = numero;

        }


        /// <summary>
        /// Valida que el valor recibido esté en formato numérico antes de asignarlo al atributo.
        /// </summary>
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        ///Trata de convertir la cadena recibida por parámetro a un valor doble, devuelve 0 en caso de no poder hacerlo.
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

        /// <summary>
        /// Valida que la cadena recibida está compuesta en su totalidad de unos y ceros e informa el resultado.
        /// </summary>
        /// <param name="binario">cadena a validar</param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convierte un número Binario en su equivalente decimal.
        /// Informa "Valor Inválido" en caso de que el valor introducido no esté compuesto por unos y ceros. 
        /// </summary>
        /// <param name="binario">Cadena numerica a convertir a binario.</param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            int esDecimal = 0;
            int pocisionB = binario.Length;

            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    pocisionB--;

                    if (binario[i] == '1')
                    {
                        esDecimal = (int)Math.Pow(2, pocisionB) + esDecimal;
                    }
                }
                return esDecimal.ToString();
            }
            return "Valor Inválido";
        }
        /// <summary>
        ///Convierte la parte entera del numero recibido por parámetro en su equivalente binario devolviendolo en formato string.
        ///Valida previamente que el número que recibe no sea negativo, de serlo informa que el valor es inválido.
        /// </summary>
        /// <param name="numero">Número a convertir a binario.</param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            int entero = (int)numero;
            int resto;
            string binario=null;

            if (entero >= 0)
            {
                do
                {
                    resto = entero % 2;
                    entero = entero / 2;
                    binario = resto.ToString() + binario;

                } while (entero > 0);
                return binario;
            }
            return "Valor Inválido";
        }

        /// <summary>
        /// Sobrecarga del método "DecimaBinario" que admite recibir una cadena numérica en formato string
        /// validando que la misma pueda pasarse a formato double. De no poder hacerlo informa "Valor Inválido".
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double esDouble;

            if (double.TryParse(numero, out esDouble))
            {
                return DecimalBinario(esDouble);
            }
            return "Valor Invalido";
        }

        /// <summary>
        /// Sobrecarga el operador '+' para permitirle sumar los atributos numéricos de dos clases "Operando".
        /// </summary>
        /// <param name="n1">Objeto Operando a sumar</param>
        /// <param name="n2">Objeto Operando a sumar</param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador '-' para permitirle restar los atributos numéricos de dos clases "Operando".
        /// </summary>
        /// <param name="n1">Objeto Operando a restar</param>
        /// <param name="n2">Objeto Operando a restar</param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador '*' para permitirle multiplicar los atributos numéricos de dos clases "Operando".
        /// </summary>
        /// <param name="n1">Objeto Operando a multiplicar</param>
        /// <param name="n2">Objeto Operando a multiplicar</param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga el operador '/' para permitirle dividir los atributos numéricos de dos clases "Operando".
        /// Valida que el valor del atributo "numero" del segundo operando sea diferente de 0. De ser el caso devuelve
        /// el mínimo valor posible de un número double.
        /// </summary>
        /// <param name="n1">Objeto Operando a sumar</param>
        /// <param name="n2">Objeto Operando a sumar</param>
        /// <returns></returns>
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
