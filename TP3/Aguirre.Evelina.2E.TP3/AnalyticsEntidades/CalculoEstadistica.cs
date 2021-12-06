using AnalyticsEntidades;
using System.Collections.Generic;
using Excepciones;
using System;

namespace EstadisticasEntidades
{
    public static class CalculoEstadistica
    {

        public static List<Encuesta> listaDatosPedidos;
        public static List<Encuesta> auxListaResultadoConsulta;

        static CalculoEstadistica()
        {

            listaDatosPedidos = new List<Encuesta>();
            auxListaResultadoConsulta = new List<Encuesta>();
        }


        /// <summary>
        /// Suma los sueldos por género y devuelve el promedio;
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="auxlista"></param>
        /// <returns></returns>
        public static int SalarioPromedio(string sexo, List<Encuesta> auxlista)
        {
            double sumaSueldos = 0;
            int contador = 0;
            float promedio=0;

            foreach (Encuesta item in auxlista)
            {
                if (item.Se_Identifica == sexo)
                {
                    sumaSueldos += item.Salario_Bruto;
                    contador++;
                }

            }

            if(contador != 0)
            {
                promedio = (int)sumaSueldos / contador;
            }
           

            return (int)promedio;
        }
        /// <summary>
        /// Calcula el sueldo promedio de un conjunto de encuestas.
        /// </summary>
        /// <param name="auxlista"></param>
        /// <returns></returns>
        public static int SalarioPromedio(List<Encuesta> auxlista)
        {
            double sumaSueldos = 0;
            int contador = 0;
            float promedio=0;

            foreach (Encuesta item in auxlista)
            {
                sumaSueldos += item.Salario_Bruto;
                contador++;
            }
            if (contador != 0)
            {
                promedio = (int)sumaSueldos / contador;
            }


            return (int)promedio;
        }

        public static int CuentaCantidadDeEncuestaPorSexo(string sexo, List<Encuesta> auxlista)
        {
            
            int contador = 0;

            foreach (Encuesta item in auxlista)
            {
                if (item.Se_Identifica == sexo)
                {
                    contador++;
                }

            }
            return contador;
        }

        /// <summary>
        /// Calcula porcentaje que representa un valor comparado con el total.
        /// </summary>
        /// <param name="cantidadConsulta"></param>
        /// <param name="cantidadTotal"></param>
        /// <returns></returns>
        public static float CalculoPorcentaje(int cantidadConsulta, int cantidadTotal)
        {
            return (cantidadConsulta * 100) / cantidadTotal;
        }

        /// <summary>
        /// Busca encuesta por parámetro que coincide.
        /// </summary>
        /// <param name="listaEncuestas"></param>
        /// <param name="auxString"></param>
        /// <returns>lista nula o cargada con los valores pedidos</returns>
        public static List<Encuesta> Buscar(string aux, List<Encuesta> auxLista)
        {
            List<Encuesta> listaSolicitada = new List<Encuesta>();

            for (int i = 0; i < auxLista.Count; i++)
            {
                if (aux == auxLista[i].Se_Identifica
                    || aux == auxLista[i].Nivel_Estudios
                    || aux == auxLista[i].Jornada
                    || aux == auxLista[i].Rubro
                    )
                {
                    listaSolicitada.Add(listaDatosPedidos[i]);
                }

            }

            return listaSolicitada;

        }

        /// <summary>
        /// Permite buscar por rango numérico en las propiedades de la entidad Encuesta 
        /// que no manejan carácteres alfabéticos.
        /// </summary>
        /// <param name="auxDesde"></param>
        /// <param name="auxHasta"></param>
        /// <param name="queBusca"></param>
        /// <returns>Lista de Encuestas que coinciden con la búsqueda</returns>
        public static List<Encuesta> Buscar(int auxDesde, int auxHasta, string queBusca, List<Encuesta> auxLista)
        {
            List<Encuesta> listaSolicitada = new List<Encuesta>();
            switch (queBusca)
            {
                case "Edad":
                    foreach (var item in auxLista)
                    {
                        if (item.Edad >= auxDesde && item.Edad <= auxHasta)
                            listaSolicitada.Add(item);
                    }
                    break;
                case "Sueldo":
                    foreach (var item in auxLista)
                    {
                        if (item.Salario_Bruto >= auxDesde && item.Salario_Bruto <= auxHasta)
                            listaSolicitada.Add(item);
                    }
                    break;
                case "Recomienda":
                    foreach (var item in auxLista)
                    {
                        if (item.Recomienda_Empresa >= auxDesde && item.Recomienda_Empresa <= auxHasta)
                            listaSolicitada.Add(item);
                    }
                    break;
                case "Experiencia":
                    foreach (var item in auxLista)
                    {
                        if (item.Experiencia >= auxDesde && item.Experiencia <= auxHasta)
                            listaSolicitada.Add(item);
                    }
                    break;

                case "Personal":
                    foreach (var item in auxLista)
                    {
                        if (item.Personal_a_Cargo >= auxDesde && item.Personal_a_Cargo <= auxHasta)
                            listaSolicitada.Add(item);
                    }
                    break;
                default:
                    listaSolicitada = null;
                    break;
            }

            return listaSolicitada;

        }


        /// <summary>
        /// Calcula diferencia de montos.
        /// </summary>
        /// <param name="auxHombre"></param>
        /// <param name="auxMujer"></param>
        /// <param name="auxOtro"></param>
        /// <returns></returns>
        public static int CalculoDiferenciaDeMontos(int aux1, int aux2)
        {
            int diferencia = 0;
            if (aux1 > aux2)
            {
                diferencia = aux1 - aux2;
            }
            else
            {
                diferencia = aux2 - aux1;
            }
            return diferencia;

        }

        /// <summary>
        /// Informa que genero tiene mayor sueldo.
        /// </summary>
        /// <param name="auxHombre">Sueldo hombres</param>
        /// <param name="auxMujer">Sueldo mujeres</param>
        /// <param name="auxOtro">Sueldo otros</param>
        /// <returns></returns>
        public static string MayorSueldo(int auxHombre, int auxMujer, int auxOtro)
        {
            string aux = "";
            if (auxHombre > auxMujer && auxHombre > auxOtro)
            {
                return "Hombres";
            }
            else if (auxMujer > auxHombre && auxMujer > auxOtro)
            {
                return "Mujeres";
            }
            else
            {
                return "Otros";
            }
            

        }



    }
}
