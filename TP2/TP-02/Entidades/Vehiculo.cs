using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region "Enumerados"
        /// <summary>
        /// Enumera Marcas posibles para la entidad Vehículo.
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        /// <summary>
        /// Enumera tamaño de Vehículo.
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region "Atributos"
        /// <summary>
        /// Atributos por defecto de todos los vehículos.
        /// </summary>
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region "Propiedad"
        /// <summary>
        /// ReadOnly: Retornará el tamaño.
        /// </summary>
        protected abstract ETamanio Tamanio { get;}
        #endregion

        #region "constructor"
        /// <summary>
        /// Constructor de Vehículo.
        /// </summary>
        /// <param name="chasis">Chasis del VFehículo</param>
        /// <param name="marca">Marca del Vehículo</param>
        /// <param name="color">Color del Vehículo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region"Métodos"
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

       /// <summary>
       /// Lista los datos del Vehículo.
       /// </summary>
       /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS:  {p.chasis}\r");
            sb.AppendLine($"MARCA :  {p.marca.ToString()}\r");
            sb.AppendLine($"COLOR :  {p.color.ToString()}\r");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Vehículo 1 a comparar chasis</param>
        /// <param name="v2">Vehículo 2 a comparar chasis</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Vehículo 1 a comparar chasis</param>
        /// <param name="v2">Vehículo 2 a comparar chasis</param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }
        #endregion
    }
}
