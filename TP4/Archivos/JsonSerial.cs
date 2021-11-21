using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Archivos
{
    public class JsonSerial
    {
        /// <summary>
        /// Genera un archivo Json
        /// </summary>
        /// <typeparam name="T">objeto generico</typeparam>
        /// <param name="ruta">donde va a ir el archivo</param>
        /// <param name="obj">el objeto a serializar</param>
        public static void SerializarJson<T>(string path, T obj) where T : class
        {
            try
            {
                if (obj is null)
                {
                    throw new Exception("objeto nulo");
                }
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
                jsonSerializerOptions.WriteIndented = true;

                string objetoJson = JsonSerializer.Serialize(obj, jsonSerializerOptions);

                File.WriteAllText(path, objetoJson);
            }
            catch (Exception ex)
            {
                throw new SerializeException("Error a la hora del manejo de archivos Json", ex);
            }
        }
        /// <summary>
        /// Deserealiza un archivo Json
        /// </summary>
        /// <typeparam name="T">objeto generico</typeparam>
        /// <param name="ruta">desde donde se lee el archivo</param>
        /// <returns>El objeto deserealizado</returns>
        public static T DeserealizarJson<T>(string ruta) where T : class
        {
            try
            {
                string objetoJson = File.ReadAllText(ruta);
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
                {
                    Converters =
                    { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                };
                jsonSerializerOptions.WriteIndented = true;

                T objetoDeserealizado = JsonSerializer.Deserialize<T>(objetoJson, jsonSerializerOptions);

                return objetoDeserealizado;
            }
            catch (Exception ex)
            {
                throw new SerializeException("Error a la hora del manejo de archivos Json", ex);
            }
        }





    }
}
