using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Validate that the received operator is +, -, / or *. Otherwise it returns "+";
        /// </summary>
        /// <param name="operador"></param> 
        /// <returns></returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                return operador.ToString();
            }
            return "+";
        }

        /// <summary>
        /// Validate the input and calculate addition, subtraction, multiplication and division between two numbers; 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>Íf operator isn´t correct ir returns '0' and it will return 'double.MinValue' in 'dividendo 0' case.
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            char operadorChar;
            string operadorValidado;
            
            //Lo paso a char para poder validarlo con el método generado anteriormente.
            if (char.TryParse(operador, out operadorChar))
            {
                //Valido que el caracter ingresado es alguno de los 4 operandos admitidos y lo guardo en la variable operadorValido.
                operadorValidado = ValidarOperador(operadorChar);

                switch (operadorValidado)
                {
                    case "+":
                        return num1 + num2;
                        break;
                    case "-":
                        return num1 - num2;
                        break;
                    case "*":
                        return num1 * num2;
                        break;
                    case "/":
                        if (num2 != null)
                        {
                            return num1 / num2;
                        }
                        break;

                }

            }
            return 0;

        }

    }
}
