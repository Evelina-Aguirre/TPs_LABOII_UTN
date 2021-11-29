using System;

namespace Excepciones
{
    public class DatoInvalido : Exception
    {
        public DatoInvalido()
        {
        }

        public DatoInvalido(string message) : base(message)
        {
        }

    }
}
