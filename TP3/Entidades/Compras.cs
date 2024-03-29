﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compras : Comprobante
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
                return (this.importe + (this.Importe * (this.Alicuota / 100)));
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
        
        public Compras(Ente enteEmisor, string ptoVenta, string nroComprobante, DateTime fecha, float importe, float alicuota, Ente enteRecepto, EConcepto concepto)
            : base(enteEmisor, ptoVenta, nroComprobante, fecha)
        {
            this.Importe = importe;
            this.Alicuota = alicuota;
            this.total = this.CalculoTotal;
            this.EnteReceptor = enteRecepto;
            this.Concepto = concepto;
        }

        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{base.MostrarDatos()} | ");
            //sb.Append($"{(string)this.EnteReceptor} | ");
            //sb.Append($"Importe: {this.Importe} | ");
            //sb.Append($"IVA: {this.Alicuota} | ");
            sb.Append($"Total: {this.CalculoTotal} | ");
            sb.Append($"Concepto: {this.Concepto}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

    }
}
