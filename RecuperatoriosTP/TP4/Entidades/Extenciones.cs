using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extenciones
    {
        /// <summary>
        /// Extencion de la clase float. Calcula el total de un comprobante realizando los calculos necesarios entre el importe base y la alicuota del mismo.
        /// </summary>
        /// <param name="importe"></param>
        /// <param name="alicuota"></param>
        /// <returns></returns>
        public static float CalcularTotal(this float importe, float alicuota)
        {
            return (importe + (importe * (alicuota / 100)));
        }


    }
}
