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
        public void CargarListaConConsultaADB()
        {
            List<Encuesta> auxList = new List<Encuesta>();
            auxList = ConexionDB.TraerResultadoEncuestas();
            Assert.IsNotNull(auxList);
        }

        [TestMethod]
        public void ContarElementosDeUnaConsulta()
        {

            int aux = ConsultasDB.CuentaRegistrosDeUnaConsulta("SE_IDENTIFICA like 'Otro'");
            Assert.IsNotNull(aux);
        }

        [TestMethod]
        [ExpectedException(typeof(DatoInvalido))]
        public void DniInvalidoTesMethod()
        {
            Encuesta aux = new Encuesta();
            aux.ValidaNumeroDelUnoAlDiez(11);


        }

    }
}
