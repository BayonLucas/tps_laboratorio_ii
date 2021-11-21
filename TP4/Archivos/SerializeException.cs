using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class SerializeException : Exception
    {

        public SerializeException(string message) : this(message, null)
        {
        }

        public SerializeException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
