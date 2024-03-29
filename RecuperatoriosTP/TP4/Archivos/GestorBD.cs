﻿using System;
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

        /// <summary>
        /// Constructor estático de la Clase GestorBD
        /// </summary>
        static GestorBD()
        {
            conexion = new SqlConnection(@"Server=LAPTOP-BGK4873G\SQLEXPRESS;Database=Bayon.Lucas.2C.TPFinal;Trusted_Connection = True;");
            command = new SqlCommand();
            command.Connection = conexion;
        }
   
        /// <summary>
        /// Controla que la conexion se haya concretado satisfactoriamente
        /// </summary>
        /// <returns></returns>
        public static bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return rta;
        }
        
        /// <summary>
        /// Carga la lista de Usuarios de la base de datos en cuestion
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex); ;
            }
            finally
            {
                conexion.Close();
            }

            return listaUsuarios;
        }
        
        /// <summary>
        /// Genera un usuario a la base de datos
        /// </summary>
        /// <param name="usuario"></param>
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
                catch (Exception ex)
                {
                    throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex); ;
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
        
        /// <summary>
        /// Genera una Tabla de Ventas para un usuario
        /// </summary>
        /// <param name="usuario"></param>
        public static void GenerarTablaVentas(Ente usuario)
        {
            try
            {
                command.CommandText = $"CREATE TABLE [dbo].[{usuario.RazonSocial+ "Ventas"}]([cuitUsuario][varchar](12) NOT NULL,[ptoVenta] " +
                    $"[varchar](5) NOT NULL,[nroComprobante] [int] NOT NULL, [fecha] [datetime] NOT NULL, " +
                    $"[importe] [float] NOT NULL, [alicuota] [float] NOT NULL, [razonSocialReceptor] [varchar](25) NOT NULL, " +
                    $"[cuitReceptor] [varchar](12) NOT NULL, [sitFiscalReceptor] [varchar](20) NOT NULL,[anulado] [bit] NOT NULL) ON[PRIMARY]";
                conexion.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la creación de la tabla del usuario", ex); ;
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Genera una Tabla de Compras para un usuario
        /// </summary>
        /// <param name="usuario"></param>
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
            catch (Exception ex)
            {
                ex = new DataBasesException("Hubo problemas con la creación de la tabla del usuario", ex);
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        
        /// <summary>
        /// Carga todas las compras que se encuentren en la base de datos de un usuario a un List
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static List<Compra> CargarListaCompras(Ente usuario)
        {
            List<Compra> listaCompras = new List<Compra>();
            try
            {
                command.CommandText = $"SELECT RAZONSOCIALEMISOR, CUITEMISOR, sitFiscalEmisor, ptoVenta, NROCOMPROBANTE, FECHA, IMPORTE, ALICUOTA, CONCEPTO " +
                    $"FROM {usuario.RazonSocial}Compras order by fecha";
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
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex); ;
            }
            finally
            {
                conexion.Close();
            }

            return listaCompras;
        }

        /// <summary>
        /// Carga todas las Ventas que se encuentren en la base de datos de un usuario a un List
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static List<Factura> CargarListaVentas(Ente usuario)
        {
            List<Factura> listaVentas = new List<Factura>();
            try
            {
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
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex); ;
            }
            finally
            {
                conexion.Close();
            }

            return listaVentas;
        }
        
        /// <summary>
        /// Busca en la base de datos todas las compras que cumplan con los criterios pasados por parametros y los guarda en un List
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="concepto"></param>
        /// <param name="anio"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static List<Compra> BuscarComprasSegun(Ente usuario, EConcepto concepto, decimal anio, string mes)
        {
            List<Compra> listaCompras = new List<Compra>();
            try
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@concepto", concepto);
                command.Parameters.AddWithValue("@anio", anio);
                command.Parameters.AddWithValue("@mes", mes);
                if (mes == string.Empty)
                {
                    command.CommandText = $"SELECT RAZONSOCIALEMISOR, CUITEMISOR, sitFiscalEmisor, ptoVenta, NROCOMPROBANTE, FECHA, IMPORTE, ALICUOTA, CONCEPTO " +
                        $"FROM {usuario.RazonSocial}Compras WHERE concepto = @concepto AND YEAR(FECHA) = @anio";
                }
                else
                {
                    command.CommandText = $"SELECT RAZONSOCIALEMISOR, CUITEMISOR, sitFiscalEmisor, ptoVenta, NROCOMPROBANTE, FECHA, IMPORTE, ALICUOTA, CONCEPTO " +
                        $"FROM {usuario.RazonSocial}Compras WHERE concepto = @concepto AND YEAR(FECHA) = @anio AND MONTH(FECHA) = @mes";
                }
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
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex); ;
            }
            finally
            {
                conexion.Close();
            }

            return listaCompras;
        }

        /// <summary>
        /// Busca en la base de datos todas las Ventas que cumplan con los criterios pasados por parametros y los guarda en un List
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="anio"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        public static List<Factura> BuscarVentasSegun(Ente usuario, decimal anio, string mes)
        {
            List<Factura> listaVentas = new List<Factura>();
            try
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@anio", anio);
                command.Parameters.AddWithValue("@mes", mes);
                if (mes == string.Empty)
                {
                    command.CommandText = $"SELECT ptoVenta, NROCOMPROBANTE, FECHA, IMPORTE, ALICUOTA, RAZONSOCIALRECEPTOR, CUITRECEPTOR, SITFISCALRECEPTOR, ANULADO " +
                        $"FROM {usuario.RazonSocial}Ventas WHERE YEAR(FECHA) = @anio";
                }
                else
                {
                    command.CommandText = $"SELECT ptoVenta, NROCOMPROBANTE, FECHA, IMPORTE, ALICUOTA, RAZONSOCIALRECEPTOR, CUITRECEPTOR, SITFISCALRECEPTOR, ANULADO " +
                        $"FROM {usuario.RazonSocial}Ventas WHERE YEAR(FECHA) = @anio AND MONTH(FECHA) = @mes";
                }
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
            catch (Exception ex)
            {
                throw new DataBasesException("Hubo problemas con la carga de la lista desde la BD", ex); ;
            }
            finally
            {
                conexion.Close();
            }

            return listaVentas;
        }
        
        /// <summary>
        /// Guarda en la base de datos una venta en la tabla Ventas del usuario correspondiente
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static bool CargarVenta(Factura f)
        {
            bool ret = false;
            try
            {
                conexion.Open();
                command.Parameters.Clear();
                command.CommandText = $"INSERT INTO dbo.{f.Ente.RazonSocial}Ventas (cuitUsuario, ptoVenta, nroComprobante, fecha, importe, alicuota, " +
                    $"razonSocialReceptor, cuitReceptor, sitFiscalReceptor, anulado) VALUES (@cuitUsuario, @ptoVenta, @nroComprobante, @fecha, @importe, " +
                    $"@alicuota, @razonSocialReceptor, @cuitReceptor, @sitFiscalReceptor, @anulado)";
                command.Parameters.AddWithValue("@cuitUsuario", f.Ente.Cuit);
                command.Parameters.AddWithValue("@ptoVenta", f.PtoVenta);
                command.Parameters.AddWithValue("@nroComprobante", f.NroComprobante);
                command.Parameters.AddWithValue("@fecha", f.Fecha.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@importe", f.Importe);
                command.Parameters.AddWithValue("@alicuota", f.Alicuota);
                command.Parameters.AddWithValue("@razonSocialReceptor", f.EnteReceptor.RazonSocial);
                command.Parameters.AddWithValue("@cuitReceptor", f.EnteReceptor.Cuit);
                command.Parameters.AddWithValue("@sitFiscalReceptor", f.EnteReceptor.SitFiscal);
                command.Parameters.AddWithValue("@anulado", f.Anulado);

                if(command.ExecuteNonQuery() == 1)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                conexion.Close();
            }
            return ret;
        }

        /// <summary>
        /// Anula una venta modificandola en la tabla Ventas del usuario correspondiente
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static bool ModificarVenta(Factura f)
        {
            bool ret = false;
            try
            {
                conexion.Open();

                command.CommandText = $"UPDATE dbo.{f.Ente.RazonSocial}Ventas SET anulado = 1 WHERE ptoVenta = {f.PtoVenta} AND nroComprobante = {f.NroComprobante} " +
                    $"AND cuitReceptor = {f.EnteReceptor.Cuit}";

                if (command.ExecuteNonQuery() > 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                conexion.Close();
            }
            return ret;
        }

        /// <summary>
        /// Guarda en la base de datos una Compra en la tabla Compras del usuario correspondiente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool CargarCompra(Compra c)
        {
            bool ret = false;
            try
            {
                conexion.Open();
                command.Parameters.Clear();
                command.CommandText = $"INSERT INTO dbo.{c.EnteReceptor.RazonSocial}Compras (razonSocialEmisor, cuitEmisor, sitFiscalEmisor, ptoVenta, nroComprobante, fecha, " +
                    $"importe, alicuota, concepto, cuitUsuario) VALUES (@razonSocialEmisor, @cuitEmisor, @sitFiscalEmisor, @ptoVenta, @nroComprobante, " +
                    $"@fecha, @importe, @alicuota, @concepto, @cuitUsuario)";
                command.Parameters.AddWithValue("@razonSocialEmisor", c.Ente.RazonSocial);
                command.Parameters.AddWithValue("@cuitEmisor", c.Ente.Cuit);
                command.Parameters.AddWithValue("@sitFiscalEmisor", c.Ente.SitFiscal);
                command.Parameters.AddWithValue("@ptoVenta", c.PtoVenta);
                command.Parameters.AddWithValue("@nroComprobante", c.NroComprobante);
                command.Parameters.AddWithValue("@fecha", c.Fecha.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@importe", c.Importe);
                command.Parameters.AddWithValue("@alicuota", c.Alicuota);
                command.Parameters.AddWithValue("@concepto", c.Concepto);
                command.Parameters.AddWithValue("@cuitUsuario", c.EnteReceptor.Cuit);

                if (command.ExecuteNonQuery() == 1)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                conexion.Close();
            }
            return ret;
        }

        /// <summary>
        /// Elimina en la base de datos una Compra en la tabla Compras del usuario correspondiente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool EliminarCompra(Compra c)
        {
            bool ret = false;
            try
            {
                conexion.Open();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@razonSocialEmisor", c.Ente.RazonSocial);
                command.Parameters.AddWithValue("@cuitEmisor", c.Ente.Cuit);
                command.Parameters.AddWithValue("@sitFiscalEmisor", c.Ente.SitFiscal);
                command.Parameters.AddWithValue("@ptoVenta", c.PtoVenta);
                command.Parameters.AddWithValue("@nroComprobante", c.NroComprobante);
                command.Parameters.AddWithValue("@fecha", c.Fecha.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@importe", c.Importe);
                command.Parameters.AddWithValue("@alicuota", c.Alicuota);
                command.Parameters.AddWithValue("@concepto", c.Concepto);
                command.Parameters.AddWithValue("@cuitUsuario", c.EnteReceptor.Cuit);
                command.CommandText = $"DELETE FROM dbo.{c.EnteReceptor.RazonSocial}Compras WHERE razonSocialEmisor = @razonSocialEmisor AND cuitEmisor = @cuitEmisor AND " +
                    $"sitFiscalEmisor = @sitFiscalEmisor AND ptoVenta = @ptoVenta AND nroComprobante = @nroComprobante AND fecha = @fecha AND importe = @importe AND " +
                    $"alicuota = @alicuota AND concepto = @concepto AND cuitUsuario = @cuitUsuario";

                if(command.ExecuteNonQuery() == 1)
                {
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                conexion.Close();
            }
            return ret;
        }
    
        /// <summary>
        /// Elimina las tablas correspondientes al usuario en cuestion
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static bool EliminarTablas(RegistroContable usuario)
        {
            bool ret1 = false;
            bool ret2 = false;
            bool retFinal = false;
            try
            {
                conexion.Open();
                command.Parameters.Clear();
                command.CommandText = $"DROP TABLE [dbo].[{usuario.Usuario.RazonSocial}Compras]";
                if(command.ExecuteNonQuery() !=0)
                {
                    ret1 = true;
                }
                command.Parameters.Clear();
                command.CommandText = $"DROP TABLE  [dbo].[{usuario.Usuario.RazonSocial}Ventas]";
                if(command.ExecuteNonQuery() != 0)
                {
                    ret2 = true;
                }
                if(ret1 && ret2)
                {
                    retFinal = true;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                conexion.Close();
            }
            return retFinal;
        }
        
        /// <summary>
        /// Elimina al usuario de la tabla Usuarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static bool EliminarUsuario(RegistroContable usuario)
        {
            bool ret = false;
 
            try 
            {
                conexion.Open();
                command.CommandText = $"DELETE FROM dbo.Usuarios WHERE cuit = {usuario.Usuario.Cuit}";
                if (command.ExecuteNonQuery() != 0)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new DataBasesException("Error a la hora de trabajar con Base de Datos", ex);
            }
            finally
            {
                conexion.Close();
            }
            return ret;
        }
    }
}
