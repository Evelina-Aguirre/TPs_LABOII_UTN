using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;




namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IntentaConecionABaseDeDatos()
        {
            ConexionDB.TraerDatos()
        }
    }
}
