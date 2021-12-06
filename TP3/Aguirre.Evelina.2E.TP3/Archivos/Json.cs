using AnalyticsEntidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Archivos
{
    public class Json : ISerializable<List<Encuesta>>
    {
        static string path;

        static Json()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Aguirre Evelina 2E Archivos\";
        }

        /// <summary>
        /// Serializa datos en formato Json.
        /// </summary>
        /// <param name="listaEncuestas"></param>
        public void GuardarDatos(List<Encuesta> listaEncuestas)
        {
            string nombre = path + "EncuestasSueldosItArgentina2021_" + DateTime.Now.ToString("HH_mm_ss") + ".js";

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.WriteAllText(nombre, JsonSerializer.Serialize(listaEncuestas));
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo generar el Archivo : ", ex);
            }



        }

        /// <summary>
        /// Deserializa un archivo en formato json.
        /// </summary>
        /// <returns></returns>
        public List<Encuesta> LeerDatos()
        {
            string rutaArchivoPrevioEnPath = string.Empty;
            string ArchivoALeer = string.Empty;
            List<Encuesta> auxLista = null;

            try
            {
                if (Directory.Exists(path))
                {
                    string[] archivosPreviosEnEsePath = Directory.GetFiles(path);
                    foreach (string path in archivosPreviosEnEsePath)
                    {
                        if (path.Contains("EncuestasSueldosItArgentina2021_"))
                        {
                            ArchivoALeer = path;
                            break;
                        }

                        if (ArchivoALeer != null)
                        {
                            auxLista = JsonSerializer.Deserialize<List<Encuesta>>(File.ReadAllText(ArchivoALeer));
                        }
                    }
                   
                }
                return auxLista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar leer Archivo : ", ex);
            }





        }





    }
}
