using System;
using System.Text;

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
            : base(marca, chasis, color)
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


        #region Sobreescritura Método 'Mostrar' 
        /// <summary>
        /// Lista las carácterísticas de Ciclomotor.
        /// </summary>
        /// <returns> Cadena que detalla los datos de Ciclomotor. </returns>
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
