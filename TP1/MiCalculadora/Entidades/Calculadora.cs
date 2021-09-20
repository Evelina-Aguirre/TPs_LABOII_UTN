namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el char recibido sea: "+,-,*,/", en cualquier otro caso devuelve "+".
        /// </summary>
        /// <param name="operador">Operador en formato char a validar. </param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '/' || operador == '*')
                return operador;
            else
                return '+';
        }


        /// <summary>
        /// Realiza el cálculo entre los operandos recibidos, validando previamente que el operador a utilizar sea  
        /// +,-,*,/. Utilizará '+' en caso de que se haya ingresado cualquier otro valor a través del parámetro char.
        /// </summary>
        /// <param name="num1">Operando uno</param>
        /// <param name="num2">Operando dos</param>
        /// <param name="operador">Operador</param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            char operadorValidado = ValidarOperador(operador);
            double resultado = 0;

            switch (operadorValidado)
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
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }



    }
}
