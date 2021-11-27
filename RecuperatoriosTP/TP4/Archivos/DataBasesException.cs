using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class DataBasesException : Exception
    {
        public DataBasesException(string message) : this(message, null)
        {
        }

        public DataBasesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
