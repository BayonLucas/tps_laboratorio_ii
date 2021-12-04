using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class XmlSerial
    {
        /// <summary>
        /// Serializa un objeto a formato XML.
        /// </summary>
        /// <param name="objeto">Objeto a serializar.</param>
        /// <param name="ruta">Ruta donde se creará el archivo de serialización.</param>
        public static void SerializarXml<T>(T objeto, string ruta)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(ruta, Encoding.UTF8);
                writer.Formatting = Formatting.Indented; 
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objeto);
            }
            catch (ArgumentException ex)
            {
                throw new SerializeException("Error: Argumentos erroneos.", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new SerializeException("Error: Directorio no encontrado.", ex);
            }
            catch (Exception ex)
            {
                throw new SerializeException("Error a la hora del manejo de archivos XML", ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Deserializa el archivo en la ruta indicada de XML al tipo genérico T.
        /// </summary>
        /// <param name="ruta">Ruta del archivo a deserializar.</param>
        /// <returns></returns>
        public static T DeserializarXml<T>(string ruta)
        {
            XmlTextReader reader = null;
            T objeto = default(T);
            try
            {
                reader = new XmlTextReader(ruta);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                objeto = (T)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                throw new SerializeException("Error al tratar de deserializar el archivo XML.", ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return objeto;
        }
    }
}
