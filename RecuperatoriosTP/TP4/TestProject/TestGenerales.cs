using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Archivos;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class TestGenerales
    {
        Ente enteTest = new Ente("Tester", "99999999999", ESitFiscal.Responsable_Inscripto);

        [TestMethod]
        public void ValidarConexionBaseDatos_OK()
        {
            //Assert
            Assert.IsTrue(GestorBD.ProbarConexion());
        }

        [TestMethod]
        public void CargarVentaTest_OK()
        {
            //Arrange
            bool ret = false;
            Factura fc1 = new Factura(enteTest, "99", "3", DateTime.Now, 12500, 21, new Ente("TresHarinasSRL", "33761349825", ESitFiscal.Monotributista), false);
            Factura fc2 = new Factura(enteTest, "99", "4", DateTime.Now, 12500, 21, new Ente("TresHarinasSRL", "33761349825", ESitFiscal.Monotributista), false);

            //Assert
            if(GestorBD.CargarVenta(fc1) && GestorBD.CargarVenta(fc2))
            {
                ret = true;
            }
            Assert.IsTrue(ret);
        }
        
        [TestMethod]
        public void CargarCompraTest_OK()
        {
            //Arrange
            bool ret = false;
            Compra c1 = new Compra(new Ente("pepes", "32165498712", ESitFiscal.Consumidor_Final), "23", "32126", DateTime.Today, 13000, 21, enteTest, EConcepto.Bien_de_uso);
            Compra c3 = new Compra(new Ente("Kanon", "66794613852", ESitFiscal.Responsable_Inscripto), "56374", "99985652", DateTime.Today, 156000, 27, enteTest, EConcepto.Bien_de_consumo);

            //Assert
            if (GestorBD.CargarCompra(c1) && GestorBD.CargarCompra(c3))
            {
                ret = true;
            }
            Assert.IsTrue(ret);
        }
        
        [TestMethod]
        [ExpectedException(typeof(DataBasesException))]
        public void ExcepcionCargaVentaEnBaseDeDatos_Ok()
        {
            Factura fc2 = new Factura(enteTest, "99", "4", System.DateTime.Now, 12500, 21, null, false);
            GestorBD.CargarVenta(fc2);
        }

        [TestMethod]
        public void ComparacionDeComprobantes_OK()
        {
            Factura f1 = new Factura(enteTest, "99", "33", DateTime.Today, 150000, 21, new Ente("Aldanas", "12346167895", ESitFiscal.Monotributista));
            Factura f2 = new Factura(enteTest, "99", "33", DateTime.Today, 150000, 21, new Ente("Aldanas", "12346167895", ESitFiscal.Monotributista));

            Assert.IsTrue(f1 == f2);
        }
       
        [TestMethod]
        public void EliminarComrpobanteDeLista_OK()
        {
            RegistroContable registro = new RegistroContable(enteTest);
            bool ret = false;

            Compra c1 = new Compra(new Ente("pepes", "32165498712", ESitFiscal.Consumidor_Final), "23", "32126", DateTime.Today, 13000, 21, enteTest, EConcepto.Bien_de_uso);
            Compra c2 = new Compra(new Ente("Aldanas", "12346167895", ESitFiscal.Monotributista), "456", "8989898", DateTime.Today, 1680, 21, enteTest, EConcepto.Servicio);
            Compra c3 = new Compra(new Ente("Kanon", "66794613852", ESitFiscal.Responsable_Inscripto), "56374", "99985652", DateTime.Today, 156000, 27, enteTest, EConcepto.Bien_de_consumo);

            registro += c1;
            registro += c2;
            registro += c3;

            foreach(Compra item in registro.Compras)
            {
                if(item == c2)
                {
                    registro -= item;
                    ret = true;
                    break;
                }
            }

            Assert.IsTrue(ret);
        }

        [TestMethod]
        public void SerializarComprasAJson_OK()
        {
            List<Compra> listaCompras = new List<Compra>();
            List<Compra> listaComprasDeserializada = new List<Compra>();
            string nombreJsonTest = "SerializeTest.Json";

            Compra c1 = new Compra(new Ente("pepes", "32165498712", ESitFiscal.Consumidor_Final), "23", "32126", DateTime.Today, 13000, 21, enteTest, EConcepto.Bien_de_uso);
            Compra c2 = new Compra(new Ente("Aldanas", "12346167895", ESitFiscal.Monotributista), "456", "8989898", DateTime.Today, 1680, 21, enteTest, EConcepto.Servicio);
            Compra c3 = new Compra(new Ente("Kanon", "66794613852", ESitFiscal.Responsable_Inscripto), "56374", "99985652", DateTime.Today, 156000, 27, enteTest, EConcepto.Bien_de_consumo);

            listaCompras.Add(c1);
            listaCompras.Add(c2);
            listaCompras.Add(c3);
            foreach(Compra item in listaCompras)
            {
                JsonSerial.SerializarJson<Compra>(nombreJsonTest, item);
            }

            Assert.IsTrue(File.Exists(nombreJsonTest));
        }

    }
}
