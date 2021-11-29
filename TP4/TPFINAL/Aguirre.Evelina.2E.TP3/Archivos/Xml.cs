using AnalyticsEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Archivos
{
    public class Xml : ISerializable<List<Encuesta>> 
    {
        static string path;
        
        static Xml()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Aguirre Evelina 2E Archivos\";
        }

        public List<Encuesta> LeerDatos()
        {
            List<Encuesta> listaEncuestas = null;

            try
            {
                string rutaArchivoPrevioEnPath = string.Empty;
                string ArchivoALeer = string.Empty;

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
                            using (StreamReader reader = new StreamReader(ArchivoALeer))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(List<Encuesta>));
                                listaEncuestas = (List<Encuesta>)serializer.Deserialize(reader);

                            }
                        }
                    }

                }
                return listaEncuestas;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error al intentar leer Archivo : ", ex);
            }
        }


        public void GuardarDatos(List<Encuesta> listaEncuestas)
        {
            string nombre = path + "EncuestasSueldosItArgentina2021_" + DateTime.Now.ToString("HH_mm_ss") + ".xml";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (StreamWriter writer = new StreamWriter(nombre))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Encuesta>));

                    xmlSerializer.Serialize(writer, listaEncuestas);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"No se pudo generar el Archivo : ", ex);
            }
         
        }

       
    }
}
