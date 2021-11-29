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
        /// Valida que no se intente convertir un valor nulo a alguno de otro tipo.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>El valor que se está intentando convertir de no ser nulo o un valor de la clase que espera el objeto</returns>
        public static T ValidarDatoNoNulloDB<T>(object objeto)
        {
            if (objeto == null || objeto == DBNull.Value)
            {
                return default(T); 
            }
            else
            {
                return (T)objeto;
            }
        }
        /// <summary>
        /// Permite obtener un valor random de un enumerados.
        /// </summary>
        /// <typeparam name="T">Enumerado del cual se seleccionaran los valores</typeparam>
        /// <returns>String con un valor ramdom del enumerado</returns>
        public static string CrearArrayDesdeEnum<T>()
        {
            Random random = new Random();
            Array arrayEnum = Enum.GetValues(typeof(T));
            string aux = arrayEnum.GetValue(random.Next(arrayEnum.Length)).ToString();
            return aux;

        }

    }
}

