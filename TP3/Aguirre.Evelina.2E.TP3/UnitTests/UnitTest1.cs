using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EstadisticasEntidades;
using AnalyticsEntidades;
using Archivos;
using Excepciones;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CargarListaDesdeArchivoXml()
        {
            Xml auxXml = new Xml();
            List<Encuesta> auxList = new List<Encuesta>();
            auxList = auxXml.LeerDatos();
            Assert.IsNotNull(auxList);
        }

       
        [TestMethod]
        [ExpectedException(typeof(DatoInvalido))]
        public void PruebaQueOcurraExcepcionEnCasoDeStringQueNoSeaSoloLetras()
        {
            Encuesta aux = new Encuesta();
            aux.ValidarStringAlfabetico("A11");

        }

        [TestMethod]
        [ExpectedException(typeof(ValorFueraDeRangoException))]
        public void PruebaQueOcurraExcepcionEnCasoDeNumeroInvalido()
        {
            Encuesta aux = new Encuesta();
            aux.ValidaNumeroDelUnoAlDiez(11);

        }
  

    }
}
