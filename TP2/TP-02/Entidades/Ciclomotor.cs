using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor de Ciclomotor.
        /// </summary>
        /// <param name="marca">Marca de ciclomotor</param>
        /// <param name="chasis">Chasis del ciclomotor</param>
        /// <param name="color">Color del Ciclomotor</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base (marca, chasis, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Agrega la propiedad a Ciclomotor 'tamaño chico'.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Sobreescritura Método 'Mostrar' heredado de Vehículo 
        /// <summary>
        /// Lista las carácterísticas de Ciclomotor.
        /// </summary>
        /// <returns> Cadena que detalla las carácterísticas de Ciclomotor. </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
