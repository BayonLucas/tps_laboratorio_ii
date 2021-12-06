using System;
using System.IO;
using Archivos;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Harcodeo Ente, Compras y Ventas 

            Ente consolaTester = new Ente("ConsolaTester", "33789654123", ESitFiscal.Responsable_Inscripto);
            RegistroContable registro = new RegistroContable(consolaTester);


            //Cargar al registro
            Compra c1 = new Compra(new Ente("pepes", "32165498712", ESitFiscal.Consumidor_Final), "23", "32126", DateTime.Today, 13000, 21, consolaTester, EConcepto.Bien_de_uso);
            registro += c1;
            Compra c2 = new Compra(new Ente("Aldanas", "12346167895", ESitFiscal.Monotributista), "456", "8989898", DateTime.Today, 1680, 21, consolaTester, EConcepto.Servicio);
            registro += c2;
            Compra c3 = new Compra(new Ente("Kanon", "66794613852", ESitFiscal.Responsable_Inscripto), "56374", "99985652", DateTime.Today, 156000, 27, consolaTester, EConcepto.Bien_de_consumo);
            registro += c3;

            Factura f1 = new Factura(consolaTester, "99", (Factura.UltimoNroComprobante(registro.Ventas) + 1).ToString(), DateTime.Today, 150000, 21, new Ente("Aldanas", "12346167895", ESitFiscal.Monotributista));
            registro += f1;
            Factura f2 = new Factura(consolaTester, "99", (Factura.UltimoNroComprobante(registro.Ventas) + 1).ToString(), DateTime.Today, 13500, 27, new Ente("Rito", "32165478925", ESitFiscal.Responsable_Inscripto));
            registro += f2;
            Factura f3 = new Factura(consolaTester, "99", (Factura.UltimoNroComprobante(registro.Ventas) + 1).ToString(), DateTime.Today, 35000, 21, new Ente("Aldanas", "221345678952", ESitFiscal.Consumidor_Final));
            registro += f3;

            //Verificar si se cargaron los comprobantes
            Console.WriteLine($"{registro.Usuario}\n");
            Console.WriteLine("\nCompras:\n");
            foreach(Compra item in registro.Compras)
            {
                Console.WriteLine($"{item.MostrarDatos()}");
            }
            Console.WriteLine("\nVentas:\n");
            foreach (Factura item in registro.Ventas)
            {
                Console.WriteLine($"{item.MostrarDatos()}");
            }

            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            //Eliminar un comprobante y una Fc 
            registro -= c2;
            registro -= f2;

            Console.WriteLine($"{registro.Usuario}\n");
            Console.WriteLine("\nCompras:\n");
            foreach (Compra item in registro.Compras)
            {
                Console.WriteLine($"{item.MostrarDatos()}");
            }
            Console.WriteLine("\nVentas:\n");
            foreach (Factura item in registro.Ventas)
            {
                Console.WriteLine($"{item.MostrarDatos()}");
            }

            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();


            // Serializar Json y XML

            try
            {
                foreach (Compra item in registro.Compras)
                {
                    JsonSerial.SerializarJson<Compra>(Ruta.GenerarRuta("TestSerialCompras.Json"), item);
                }
                foreach (Factura item in registro.Ventas)
                {
                    JsonSerial.SerializarJson<Factura>(Ruta.GenerarRuta("TestSerialVentas.Json"), item);
                }
                if(File.Exists("TestSerialCompras.Json") && File.Exists("TestSerialVentas.Json"))
                {
                    Console.WriteLine("Serialización Json Exitosa");
                    Console.WriteLine($"La ruta del Json Compras es: {Path.GetFullPath("TestSerialCompras.Json")}");
                    Console.WriteLine($"La ruta del Json Ventas es: {Path.GetFullPath("TestSerialVentas.Json")}");
                    Console.WriteLine("");
                }
                foreach (Compra item in registro.Compras)
                {
                    XmlSerial.SerializarXml<Compra>(item, "TestSerialCompras.xml");
                }
                foreach (Factura item in registro.Ventas)
                {
                    XmlSerial.SerializarXml<Factura>(item, "TestSerialVentas.xml");
                }
                if (File.Exists("TestSerialCompras.xml") && File.Exists("TestSerialVentas.xml"))
                {
                    Console.WriteLine("Serialización XML Exitosa");
                    Console.WriteLine($"La ruta del xml Compras es: {Path.GetFullPath("TestSerialCompras.xml")}");
                    Console.WriteLine($"La ruta del xml Ventas es: {Path.GetFullPath("TestSerialVentas.xml")}");
                    Console.WriteLine("");
                }
                Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
                Console.ReadKey();
                Console.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
