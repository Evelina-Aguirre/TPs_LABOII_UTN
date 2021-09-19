namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Validates thar the recived char is "+,-,*,/", in any other case it retuns "+".
        /// </summary>
        /// <param name="operador"> Operator in char format to be validated </param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            if (!char.IsWhiteSpace(operador))
            {
                if (operador == '-' || operador == '/' || operador == '*')
                    return operador;
            }
            return '+';
        }

        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorValidado = ValidarOperador(operador);
            double resultado = 0;

            switch(operadorValidado)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    if(num2 != null)
                    {
                        resultado =  num1 / num2;
                    }
                    break;
            }

            return resultado;
        }



    }
}
