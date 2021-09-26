using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        #region Enumerados
        /// <summary>
        /// Enumerado que limita las opciones de "Marca" del vehículo.
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        /// <summary>
        /// Enumerado que limita las opciones de tamaño del vehículo.
        /// </summary>
        protected enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedades que tendrán todos los vehículos.
        /// </summary>
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor vehículo.
        /// </summary>
        /// <param name="marca">Marca del vehículo</param>
        /// <param name="chasis">Chasis del Vehículo</param>
        /// <param name="color">Color del vehículo</param>
        protected Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Solo lectura. Impone a las clases derivadas sobreescribirlo
        /// permitiendo gettear el tamaño del vehículo.
        /// </summary>
        protected abstract ETamanio Tamanio { get; }
        #endregion

        #region Método
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;  
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Permite Listar las carácterísticas base de un vehículo.
        /// </summary>
        /// <param name="p">Vehículo del cual tomará los datos a listar.</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---------------------");
            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca);
            sb.AppendFormat("COLOR : {0}\r\n", p.color);
            sb.AppendFormat("TAMAÑO : {0}\r", p.Tamanio);
            

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis.
        /// </summary>
        /// <param name="v1">Primer vehículo a comparar.</param>
        /// <param name="v2">Segundo vehículo a comparar.</param>
        /// <returns>true si los chasis comparados son iguales</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distintos.
        /// </summary>
        /// <param name="v1">Primer vehículo a comparar.</param>
        /// <param name="v2">Segundo vehículo a comparar.</param>
        /// <returns>true si los chasis comparados son diferentes.</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
