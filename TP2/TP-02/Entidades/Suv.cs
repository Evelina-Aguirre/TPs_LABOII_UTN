using System;
using System.Text;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region Contructor
        /// <summary>
        /// Constructor de SUV.
        /// </summary>
        /// <param name="marca">Marca del SUV</param>
        /// <param name="chasis">Chasis del SUV</param>
        /// <param name="color">Color del SUV</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(marca, chasis, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Informa que los SUVs serán tamaño grande.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Sobreescritura Método 'Mostrar'
        /// <summary>
        /// Lista las carácterísticas de SUV.
        /// </summary>
        /// <returns>Cadena con los datos del SUV.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
