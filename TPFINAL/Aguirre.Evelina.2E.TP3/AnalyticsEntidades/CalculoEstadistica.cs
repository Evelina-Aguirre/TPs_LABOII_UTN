using AnalyticsEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasEntidades
{
    public static class CalculoEstadistica
    {
        
        public static List<Encuesta> listaDatosPedidos;

        static CalculoEstadistica()
        {
            
         listaDatosPedidos= new List<Encuesta> ();
        }
    /// <summary>
    /// Busca encuesta por Sexo
    /// </summary>
    /// <param name="listaEncuestas"></param>
    /// <param name="auxString"></param>
    /// <returns>lista nula o cargada con los valores pedidos</returns>
    public static List<Encuesta> Buscar(List<Encuesta> listaEncuestas, string auxString)
        {
            List<Encuesta> listaSolicitada =null;
            listaSolicitada = new List<Encuesta>();

            for (int i = 0; i < listaEncuestas.Count; i++)
            {
                if(auxString == listaEncuestas[i].Se_Identifica 
                   
                    || auxString == listaEncuestas[i].Provincia 
                    || auxString == listaEncuestas[i].Nivel_Estudios
                    || auxString == listaEncuestas[i].Puesto
                    || auxString == listaEncuestas[i].Jornada
                    || auxString == listaEncuestas[i].Rubro
                    
                    )
                {
                    listaSolicitada.Add(listaEncuestas[i]);
                }

            }

            return listaSolicitada;

        }

        /// <summary>
        /// Busca encuestas por Sexo
        /// </summary>
        /// <param name="listaEncuestas"></param>
        /// <param name="auxString"></param>
        /// <returns>lista nula o cargada con los valores pedidos</returns>
        public static List<Encuesta> Buscar(List<Encuesta> listaEncuestas, Enumerados.ESexo sexo)
        {
            List<Encuesta> listaSolicitada = null;
            listaSolicitada = new List<Encuesta>();

            for (int i = 0; i < listaEncuestas.Count; i++)
            {
                if (sexo.ToString() == listaEncuestas[i].Se_Identifica)
                {
                    listaSolicitada.Add(listaEncuestas[i]);
                }

            }

            return listaSolicitada;

        }

        /// <summary>
        /// Busca encuestas por Edad
        /// </summary>
        /// <param name="listaEncuestas"></param>
        /// <param name="auxString"></param>
        /// <returns>lista nula o cargada con los valores pedidos</returns>
        public static List<Encuesta> Buscar(List<Encuesta> listaEncuestas, Enumerados.EEdad edad)
        {
            List<Encuesta> listaSolicitada = null;
            listaSolicitada = new List<Encuesta>();

            for (int i = 0; i < listaEncuestas.Count; i++)
            {
                if (Convert.ToInt32(edad.ToString()) == listaEncuestas[i].Edad)
                {
                    listaSolicitada.Add(listaEncuestas[i]);
                }

            }

            return listaSolicitada;

        }

        /// <summary>
        /// Busca encuestas por provincia
        /// </summary>
        /// <param name="listaEncuestas"></param>
        /// <param name="auxString"></param>
        /// <returns>lista nula o cargada con los valores pedidos</returns>
        public static List<Encuesta> Buscar(List<Encuesta> listaEncuestas, Enumerados.EProvincia provincia)
        {
            List<Encuesta> listaSolicitada = null;
            listaSolicitada = new List<Encuesta>();

            for (int i = 0; i < listaEncuestas.Count; i++)
            {
                if (provincia.ToString() == listaEncuestas[i].Provincia)
                {
                    listaSolicitada.Add(listaEncuestas[i]);
                }

            }

            return listaSolicitada;

        }

        /// <summary>
        /// Busca encuestas por años de experiencia.
        /// </summary>
        /// <param name="listaEncuestas"></param>
        /// <param name="auxString"></param>
        /// <returns>lista nula o cargada con los valores pedidos</returns>
        public static List<Encuesta> Buscar(List<Encuesta> listaEncuestas, Enumerados.EExperiencia experiencia)
        {
            List<Encuesta> listaSolicitada = null;
            listaSolicitada = new List<Encuesta>();

            for (int i = 0; i < listaEncuestas.Count; i++)
            {
                if (Convert.ToInt32(experiencia.ToString()) == listaEncuestas[i].Experiencia)
                {
                    listaSolicitada.Add(listaEncuestas[i]);
                }

            }

            return listaSolicitada;

        }

        /// <summary>
        /// Busca encuesta por Sexo
        /// </summary>
        /// <param name="listaEncuestas"></param>
        /// <param name="auxString"></param>
        /// <returns>lista nula o cargada con los valores pedidos</returns>
        public static List<Encuesta> BuscarPorSexo(List<Encuesta> listaEncuestas, string auxString)
        {
            List<Encuesta> listaSolicitada = null;
            listaSolicitada = new List<Encuesta>();

            for (int i = 0; i < listaEncuestas.Count; i++)
            {
                if (auxString == listaEncuestas[i].Se_Identifica)
                {
                    listaSolicitada.Add(listaEncuestas[i]);
                }

            }

            return listaSolicitada;

        }

        
    }
}
