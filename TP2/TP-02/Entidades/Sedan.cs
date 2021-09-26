using System;
using System.Text;

namespace Entidades
{
    public class Sedan : Vehiculo
    {

        #region Atributos
        /// <summary>
        /// Atributos que se sumarán a la base dándole carácterísticas 
        /// propias a la clase Sedán.
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor de Sedán.
        /// </summary>
        /// <param name="marca">Marca del Sedán</param>
        /// <param name="chasis">Chasis del Sedán</param>
        /// <param name="color">Color del Sedán</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(marca, chasis, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Constructor de Sedán. Establece por defecto que al menos que se indique lo contrario, 
        /// será de cuatro puertas.
        /// </summary>
        /// <param name="marca">Marca del Sedán</param>
        /// <param name="chasis">Chasis del Sedán</param>
        /// <param name="color">Color del Sedán</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
           : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }
        #endregion


        #region Propiedad
        /// <summary>
        /// Agrega la propiedad a Sedán 'tamaño mediano'.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion


        #region Sobreescritura Método 'Mostrar'
        /// <summary>
        /// Agrega al conjunto de strings que detalla las carácterísticas de la base, 
        /// el tipo de Sedan del que se trata.
        /// </summary>
        /// <returns>Cadena que detallando los datos de Sedán</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); ;
        }
        #endregion

    }
}
