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
            Factura fc1 = new Factura(enteTest, "99", "1", System.DateTime.Now, 12500, 21, new Ente("TresHarinasSRL", "33761349825", ESitFiscal.Monotributista), false);
            Factura fc2 = new Factura(enteTest, "99", "2", System.DateTime.Now, 12500, 21, new Ente("TresHarinasSRL", "33761349825", ESitFiscal.Monotributista), false);

            //Assert
            if(GestorBD.CargarVenta(fc1) && GestorBD.CargarVenta(fc2))
            {
                ret = true;
            }
            Assert.IsTrue(ret);
        }
        [TestMethod]
        public void AnularVenta()
        {
            Factura fc = new Factura(enteTest, "99", "1", System.DateTime.Now, 12500, 21, new Ente("TresHarinasSRL", "33761349825", ESitFiscal.Monotributista), false);

            Assert.IsTrue(GestorBD.ModificarVenta(fc));
        }
        [TestMethod]
        public void CargarCompraTest()
        {
            //Arrange
            bool ret = false;
            Compra c1 = new Compra(new Ente("Ezkiel", "23456783215321", ESitFiscal.Consumidor_Final), "11212", "5555", System.DateTime.Now, 300, 27, enteTest, EConcepto.Bien_de_consumo);
            Compra c2 = new Compra(new Ente("Las", "12365498456", ESitFiscal.Monotributista), "199", "6546", System.DateTime.Now, 79800, 21, enteTest, EConcepto.Servicio);
            //Assert
            if (GestorBD.CargarCompra(c1) && GestorBD.CargarCompra(c2))
            {
                ret = true;
            }
            Assert.IsTrue(ret);

        }


    }
}
