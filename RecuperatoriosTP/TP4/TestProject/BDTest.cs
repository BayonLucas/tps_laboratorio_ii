using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Archivos;


namespace TestProject
{
    [TestClass]
    public class BDTest
    {
        Ente enteTest = new Ente("Tester", "99999999999", ESitFiscal.Responsable_Inscripto);


        [TestMethod]
        public void ValidarConexionBaseDatos()
        {
            //Assert
            Assert.IsTrue(GestorBD.ProbarConexion());
        }

        [TestMethod]
        public void CargarVentaTest()
        {
            //Arrange
            bool ret = false;
            Factura fc1 = new Factura(enteTest, "99", "3", System.DateTime.Now, 12500, 21, new Ente("TresHarinasSRL", "33761349825", ESitFiscal.Monotributista), false);
            Factura fc2 = new Factura(enteTest, "99", "4", System.DateTime.Now, 12500, 21, new Ente("TresHarinasSRL", "33761349825", ESitFiscal.Monotributista), false);

            //Assert
            if(GestorBD.CargarVenta(fc1) && GestorBD.CargarVenta(fc2))
            {
                ret = true;
            }
            Assert.IsTrue(ret);
        }
       
    }
}
