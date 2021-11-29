using System;

namespace EstadisticasEntidades
{
    public static class RandomEnumerado<T, U>
    { 
        public static string CrearArrayDesdeEnum<T>()
        {
            Random random = new Random();
            Array arrayEnum = Enum.GetValues(typeof(T));
            string aux = arrayEnum.GetValue(random.Next(arrayEnum.Length)).ToString() ;
            return aux;

        }


    }

}

