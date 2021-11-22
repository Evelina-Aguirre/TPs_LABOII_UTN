using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class ErrorConsultaABaseException :Exception 
    {
        public ErrorConsultaABaseException()
        {
                
        }

        public ErrorConsultaABaseException(string message) : base(message)
        {
                
        }   
    }
}
