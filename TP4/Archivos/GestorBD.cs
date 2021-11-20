using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Archivos
{

    

    public static class GestorBD 
    {
        private static SqlConnection conexion;
        private static SqlCommand command;

        static GestorBD()
        {
            conexion = new SqlConnection(@"Server=LAPTOP-BGK4873G\SQLEXPRESS;Database=Bayon.Lucas.2C.TPFinal;Trusted_Connection = True;");
            command = new SqlCommand();
            command.Connection = conexion;
        }


        public static List<Ente> CargarListaUsuarios()
        {
            List<Ente> listaUsuarios = new List<Ente>();

            try
            {
                command.CommandText = "SELECT RAZONSOCIAL, CUIT, SITUACIONFISCAL FROM dbo.Usuarios";
                conexion.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string auxRazonSocial = reader["RAZONSOCIAL"].ToString();
                    string auxCuit = reader["CUIT"].ToString();
                    string auxSituacionFiscal = reader["SituacionFiscal"].ToString();

                    Ente auxUsuario = new Ente(auxRazonSocial, auxCuit, (ESitFiscal)Enum.Parse(typeof(ESitFiscal),auxSituacionFiscal));
                    if (!(auxUsuario is null))
                    {
                        listaUsuarios.Add(auxUsuario);
                    }
                }
            }
            catch (DataBasesException ex)
            {
                ex = new DataBasesException("Hubo problemas con la carga de la lista desde la BD", null);
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return listaUsuarios;
        }
        public static void GenerarUsuario(Ente usuario)
        {
            if(usuario is not null)
            {
                try
                {
                    conexion.Open();

                    command.CommandText = "INSERT INTO dbo.Usuarios (RAZONSOCIAL, CUIT, SITUACIONFISCAL) VALUES (@razonSocial, @cuit, @situacionFiscal)";
                    command.Parameters.AddWithValue("@razonSocial", usuario.RazonSocial);
                    command.Parameters.AddWithValue("@cuit", usuario.Cuit);
                    command.Parameters.AddWithValue("@situacionFiscal", usuario.SitFiscal.ToString());

                    command.ExecuteNonQuery();
                }
                catch (DataBasesException ex)
                {
                    ex = new DataBasesException("Hubo problemas con la carga de la lista desde la BD", null);
                    throw ex;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        public static void GenerarTablaVentas(Ente usuario)
        {
            try
            {
                command.CommandText = $"CREATE TABLE [dbo].[{usuario.RazonSocial+ "Ventas"}]([cuitUsuario][varchar](12) NOT NULL,[ptoVenta] " +
                    $"[varchar](5) NOT NULL,[nroComprobante] [int] IDENTITY(1, 1) NOT NULL, [fecha] [datetime] NOT NULL, " +
                    $"[importe] [float] NOT NULL, [alicuota] [float] NOT NULL, [razonSocialReceptor] [varchar](25) NOT NULL, " +
                    $"[cuitReceptor] [varchar](12) NOT NULL, [sitFiscalReceptor] [varchar](20) NOT NULL,[anulado] [bit] NOT NULL) ON[PRIMARY]";
                conexion.Open();
                command.ExecuteNonQuery();

            }
            catch (DataBasesException ex)
            {
                ex = new DataBasesException("Hubo problemas con la creación de la tabla del usuario", null);
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public static void GenerarTablaCompras(Ente usuario)
        {
            try
            {
                command.CommandText = $"CREATE TABLE [dbo].[{usuario.RazonSocial+ "Compras"}]( [razonSocialEmisor][varchar](25) NOT NULL, [cuitEmisor] [varchar](12) NOT NULL, " +
                    $"[sitFiscalEmisor] [varchar](20) NOT NULL, [ptoVenta] [varchar](5) NOT NULL, [nroComprobante] [int] NOT NULL, [fecha] [datetime] NOT NULL, " +
                    $"[importe] [float] NOT NULL, [alicuota] [float] NOT NULL, [concepto] [varchar](50) NOT NULL, [cuitUsuario] [varchar](12) NOT NULL) ON[PRIMARY]";
                conexion.Open();
                command.ExecuteNonQuery();

            }
            catch (DataBasesException ex)
            {
                ex = new DataBasesException("Hubo problemas con la creación de la tabla del usuario", null);
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public static List<Compra> CargarListaCompras(Ente usuario)
        {
            List<Compra> listaCompras = new List<Compra>();
            try
            {
                command.CommandText = $"SELECT RAZONSOCIALEMISOR, CUITEMISOR, sitFiscalEmisor, ptoVenta, NROCOMPROBANTE, FECHA, IMPORTE, ALICUOTA, CONCEPTO " +
                    $"FROM {usuario.RazonSocial}Compras";
                conexion.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ente auxEnteEmisor = new Ente(reader["RAZONSOCIALEMISOR"].ToString(), reader["CUITEMISOR"].ToString(), 
                        (ESitFiscal)Enum.Parse(typeof(ESitFiscal), reader["sitFiscalEmisor"].ToString()));
                    string auxPtoVenta = reader["ptoVenta"].ToString();
                    string auxNroComprobante = reader["NROCOMPROBANTE"].ToString();
                    DateTime auxFecha = DateTime.Parse(reader["FECHA"].ToString());
                    float auxImporte = float.Parse(reader["IMPORTE"].ToString());
                    float auxAlicuota = float.Parse(reader["ALICUOTA"].ToString());
                    string auxConcepto = reader["CONCEPTO"].ToString();

                    Compra auxCompra = new Compra(auxEnteEmisor, auxPtoVenta, auxNroComprobante, auxFecha, auxImporte, auxAlicuota, usuario, 
                        (EConcepto)Enum.Parse(typeof(EConcepto), auxConcepto));
                    if (!(auxCompra is null))
                    {
                        listaCompras.Add(auxCompra);
                    }
                }
            }
            catch (DataBasesException ex)
            {
                ex = new DataBasesException("Hubo problemas con la carga de la lista desde la BD", null);
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return listaCompras;
        }
        public static List<Factura> CargarListaVentas(Ente usuario)
        {
            List<Factura> listaVentas = new List<Factura>();
            try
            {
                //command.CommandText = $"SELECT * FROM dbo.{usuario.RazonSocial + ".Ventas"}";
                command.CommandText = $"SELECT ptoVenta, NROCOMPROBANTE, FECHA, IMPORTE, ALICUOTA, RAZONSOCIALRECEPTOR, CUITRECEPTOR, SITFISCALRECEPTOR, ANULADO " +
                    $"FROM {usuario.RazonSocial}Ventas";
                conexion.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string auxPtoVenta = reader["ptoVenta"].ToString();
                    string auxNroComprobante = reader["NROCOMPROBANTE"].ToString();
                    DateTime auxFecha = DateTime.Parse(reader["FECHA"].ToString());
                    float auxImporte = float.Parse(reader["IMPORTE"].ToString());
                    float auxAlicuota = float.Parse(reader["ALICUOTA"].ToString());
                    Ente auxEnteReceptor = new Ente(reader["RAZONSOCIALRECEPTOR"].ToString(), reader["CUITRECEPTOR"].ToString(),
                        (ESitFiscal)Enum.Parse(typeof(ESitFiscal), reader["SITFISCALRECEPTOR"].ToString()));
                    bool auxAnulado = bool.Parse(reader["ANULADO"].ToString());

                    Factura auxFactura = new Factura(usuario, auxPtoVenta, auxNroComprobante, auxFecha, auxImporte, auxAlicuota, auxEnteReceptor, auxAnulado);
                    if (!(auxFactura is null))
                    {
                        listaVentas.Add(auxFactura);
                    }
                }
            }
            catch (DataBasesException ex)
            {
                ex = new DataBasesException("Hubo problemas con la carga de la lista desde la BD", null);
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return listaVentas;
        }


        /*
        public static List<T> CargarListaComprobantes()
        {
            List<T> listaProductos = new List<T>();

            try
            {
                command.CommandText = "SELECT RAZONSOCIAL, CUIT, SITUACIONFISCAL FROM USUARIOS";
                conexion.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string auxRazonSocial = reader["RAZONSOCIAL"].ToString();
                    int auxCuit = int.Parse(reader["CUIT"].ToString());
                    string auxSituacionFiscal = reader["DESCRIPCION"].ToString();

                    Producto auxP = new Producto(auxCodigo, auxDescripcion, auxStock, auxPrecio);
                    if (!(auxP is null))
                    {
                        listaProductos.Add(auxP);
                    }
                }
            }
            catch (ComiqueriaException)
            {
                ComiqueriaException ex = new ComiqueriaException("Hubo problemas con la carga de la lista desde la BD", null);
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return listaProductos;
        }
*/
        /*
        public static void CargarProducto(string nuevaDescripcion, double nuevoPrecio, int nuevoStock)
        {
            try
            {
                conexion.Open();

                command.CommandText = "INSERT INTO PRODUCTOS (DESCRIPCION, PRECIO, STOCK) VALUES (@descripcion, @precio, @stock)";
                command.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                command.Parameters.AddWithValue("@precio", nuevoPrecio);
                command.Parameters.AddWithValue("@stock", nuevoStock);

                command.ExecuteNonQuery();
            }
            catch (ComiqueriaException)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
*/

    }
}
