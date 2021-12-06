using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasEntidades
{
    public static class ClaseGenerica<T>
    {
        /// <summary>
        /// Permite obtener un valor random de un enumerado.
        /// </summary>
        /// <typeparam name="T">Enumerado del cual se seleccionaran los valores</typeparam>
        /// <returns>String con un valor ramdom del enumerado</returns>
        public static string ObtenerValorAleatorioEnumerado<T>()
        {
            Random random = new Random();
            Array arrayEnum = Enum.GetValues(typeof(T));
            string aux = arrayEnum.GetValue(random.Next(arrayEnum.Length)).ToString();
            return aux;

        }

    }
}

