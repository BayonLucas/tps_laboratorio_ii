using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura : Comprobante
    {
        private bool anulado;
        private float alicuota;
        private float importe;
        private float total;
        private Ente enteReceptor;

        public bool Anulado
        {
            get
            {
                return this.anulado;
            }
            set
            {
                this.anulado = value;
            }
        }
        public float Alicuota
        {
            get 
            {
                return this.alicuota;
            }
            set
            {
                if(value != 21 && value != 10.5 && value != 27)
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
                if((float)value < 0)
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
                return (this.Importe * (this.Alicuota / 100)/* - this.Impuesto*/);
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
        public Factura(Ente enteEmisor, string ptoVenta, string nroComprobante, DateTime fecha, float importe, float alicuota, Ente enteRecepto) 
            : base(enteEmisor, ptoVenta, nroComprobante, fecha)
        {
            this.Anulado = false;
            this.Importe = importe;
            this.Alicuota = alicuota;
            this.total = this.CalculoTotal;
            this.enteReceptor = enteRecepto;
        }
        public Factura(Ente enteEmisor, string ptoVenta, string nroComprobante, DateTime fecha, float importe, float alicuota, Ente enteRecepto, bool anulado)
            : this(enteEmisor, ptoVenta, nroComprobante, fecha, importe, alicuota, enteRecepto)
        {
            this.Anulado = anulado;
        }

        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{base.MostrarDatos()} | ");
            sb.Append($"{(string)this.EnteReceptor} | ");
            sb.Append($"Importe: {this.Importe} | ");
            sb.Append($"IVA: {this.Alicuota} | ");
            sb.Append($"Total: {this.CalculoTotal}");

            return sb.ToString();
        }
    }
}
