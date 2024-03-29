﻿using System;
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
       
        public Factura() : this(new Ente(),string.Empty, string.Empty, DateTime.Now, 0, 0, new Ente())
        {        }
        public Factura(Ente enteEmisor, string ptoVenta, string nroComprobante, DateTime fecha, float importe, float alicuota, Ente enteRecepto)
           : this(enteEmisor, ptoVenta, nroComprobante, fecha, importe, alicuota, enteRecepto, false)
        {        }
        public Factura(Ente enteEmisor, string ptoVenta, string nroComprobante, DateTime fecha, float importe, float alicuota, Ente enteRecepto, bool anulado)
           : base(enteEmisor, ptoVenta, nroComprobante, fecha)
        {
            this.Anulado = anulado;
            this.Importe = importe;
            this.Alicuota = alicuota;
            this.total = this.CalculoTotal;
            this.enteReceptor = enteRecepto;
        }

        /// <summary>
        /// Sobreescritura de MostrarDatos de la clase Base. Retorna un stringBuilder con la inforcion importante de la Factura.
        /// </summary>
        /// <returns></returns>
        public override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{base.MostrarDatos()} | ");
            sb.Append($"{(string)this.EnteReceptor} | ");
            sb.Append($"Importe: {this.Importe} | ");
            sb.Append($"IVA: {this.Alicuota} | ");
            sb.Append($"Total: {this.CalculoTotal} | ");
            sb.Append($"Anulado: {this.Anulado}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura necesaria del Tostring para el uso de listBox en Windows Forms
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{(string)this.EnteReceptor} | ");
            sb.Append($"Importe: {this.Importe} | ");
            sb.Append($"IVA: {this.Alicuota} | ");
            sb.Append($"Total: {this.CalculoTotal} | ");
            sb.Append($"Anulado: {this.Anulado}");

            return sb.ToString();
        }

        /// <summary>
        /// Retorna el nro de Comprobante de la ultima Factura Emitida
        /// </summary>
        /// <param name="listaVentas"></param>
        /// <returns></returns>
        public static int UltimoNroComprobante(List<Factura> listaVentas)
        {
            int aux = 0; ;
            if (listaVentas is not null)
            {
                if (listaVentas.Count > 0)
                {
                    Factura auxFc = listaVentas.Last();
                    if (auxFc is not null)
                        aux = int.Parse(auxFc.NroComprobante);
                }
            }
            return aux;
        }
    }
}
