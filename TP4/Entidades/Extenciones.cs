using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extenciones
    {
        public static float CalcularTotal(this float importe, float alicuota)
        {
            return (importe + (importe * (alicuota / 100)));
        }


    }
}
