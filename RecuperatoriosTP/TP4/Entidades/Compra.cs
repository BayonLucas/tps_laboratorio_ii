using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compra : Comprobante
    {
        private float alicuota;
        private float importe;
        private float total;
        private Ente enteReceptor;
        private EConcepto concepto;


        public float Alicuota
        {
            get
            {
                return this.alicuota;
            }
            set
            {
                if (value != 21 && value != 10.5 && value != 27)
                {
                    this.alicuota = 0;
                }
                else
                {
                    this.alicuota = value;
                }
            }
        }
        public float Importe
        {
            get
            {
                return this.importe;
            }
            set
            {
                if ((float)value < 0)
                {
                    this.importe = 0;
                }
                else
                {
                    this.importe = value;
                }
            }
        }
        public float CalculoTotal
        {
            get
            {
                float aux = this.Importe;
                return aux.CalcularTotal(this.Alicuota);
            }
        }
        public Ente EnteReceptor
        {
            get
            {
                return this.enteReceptor;
            }
            set
            {
                this.enteReceptor = value;
            }
        }
        public EConcepto Concepto
        {
            get
            {
                return this.concepto;
            }
            set
            {
                this.concepto = value;
            }
        }
        
        public Compra(Ente enteEmisor, string ptoVenta, string nroComprobante, DateTime fecha, float importe, float alicuota, Ente enteRecepto, EConcepto concepto)
            : base(enteEmisor, ptoVenta, nroComprobante, fecha)
        {
            this.Importe = importe;
            this.Alicuota = alicuota;
            this.total = this.CalculoTotal;
            this.EnteReceptor = enteRecepto;
            this.Concepto = concepto;
        }
        public Compra() : this(new Ente(), string.Empty, string.Empty, DateTime.Now, 0, 0, new Ente(), EConcepto.Varios)
        {        }

        /// <summary>
        /// Sobreescritura de MostrarDatos de la clase base. Retorna un stringBuilder con los datos importante de la Compra
        /// </summary>
        /// <returns></returns>
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{base.MostrarDatos()} | ");
            sb.Append($"Total: {this.CalculoTotal} | ");
            sb.Append($"Concepto: {this.Concepto}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del ToString() para el uso de ListBox en Windows Froms
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
