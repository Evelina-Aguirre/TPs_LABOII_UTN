using AnalyticsEntidades;
using System;

namespace Archivos
{
    public interface ISerializable <T>
    {
        public T LeerDatos();
        public void GuardarDatos(T listaEncuestas);
    }
}
