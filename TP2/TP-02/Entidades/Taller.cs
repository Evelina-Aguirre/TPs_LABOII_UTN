using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public sealed class Taller
    {
        #region Propiedades
        /// <summary>
        /// Porpiedades de taller.
        /// </summary>
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        #endregion


        #region Enumerado
        /// <summary>
        /// Enumerado de taller que limita las posibilidades de tipo.
        /// </summary>
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion


        #region "Constructores"
        /// <summary>
        /// Contructor de taller. Inicializa lista de vehículos.
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor de taller.
        /// </summary>
        /// <param name="espacioDisponible">numero entero determinará espacio disponible en taller</param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion


        #region "Sobrecarga"
        /// <summary>
        /// Muestro el estacionamiento y todos los vehículos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion


        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// Sólo del tipo requerido.
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Cadena detallando los datos del vehículo solicitado</returns>
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles\n", t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in t.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                            sb.AppendLine(v.Mostrar());
                        break;

                    case ETipo.Sedan:
                        if (v is Sedan)
                            sb.AppendLine(v.Mostrar());
                        break;

                    case ETipo.SUV:
                        if (v is Suv)
                            sb.AppendLine(v.Mostrar());
                        break;

                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion


        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista.
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento.</param>
        /// <param name="vehiculo">Objeto a agregar.</param>
        /// <returns></returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            if (t.vehiculos.Count < t.espacioDisponible)
            {
                foreach (Vehiculo v in t.vehiculos)
                {
                    if (v == vehiculo)
                        return t;
                }
                t.vehiculos.Add(vehiculo);
            }

            return t;
        }

        /// <summary>
        /// Quitará un elemento de la lista.
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento.</param>
        /// <param name="vehiculo">Objeto a quitar.</param>
        /// <returns></returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            if (t.vehiculos.Count > 0)
            {
                foreach (Vehiculo v in t.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        t.vehiculos.Remove(vehiculo);
                        break;
                    }
                }
            }
            return t;
        }
        #endregion
    }
}
