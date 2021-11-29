using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Factura))]
    [XmlInclude(typeof(Compra))]
    public abstract class Comprobante
    {
        protected Ente enteEmisor;
        protected string ptoVenta;
        protected string nroComprobante;
        protected DateTime fecha;

        public string PtoVenta
        {
            get
            {
                return this.ptoVenta;
            }
            set
            {
                if (PtoVentaCtrl(value))
                {
                    while (value.Length != 5)
                    {
                        value = "0" + value;
                    }
                    this.ptoVenta = value;
                }
                else
                {
                    this.ptoVenta = "00000";
                }
            }
        }
        public string NroComprobante
        {
            get
            {
                return this.nroComprobante;
            }
            set
            {
                if (nroCompCtrl(value))
                {
                    while (value.Length != 8)
                    {
                        value = "0" + value;
                    }
                    this.nroComprobante = value;
                }
                else
                {
                    this.nroComprobante = "00000000";
                }
            }
        }
        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }
        public Ente Ente
        {
            get
            {
                return this.enteEmisor;
            }
            set
            {
                this.enteEmisor = value;
            }
        }
        public string DatosComprobante
        {
            get
            {
                string aux = String.Format(this.PtoVenta + "-" + this.NroComprobante);
                return aux;
            }
        }

        public Comprobante() : this(new Ente(), string.Empty, string.Empty, DateTime.Now)
        {        }
        public Comprobante(Ente enteEmisor, string ptoVenta, string nroComprobante, DateTime fecha)
        {
            this.Fecha = fecha;
            this.enteEmisor = enteEmisor;
            this.PtoVenta = ptoVenta;
            this.NroComprobante = nroComprobante;
        }

        /// <summary>
        /// Controla que el string pasado por parametro seran digitos y no supere los 5 caracteres
        /// </summary>
        /// <param name="ptoV"></param>
        /// <returns></returns>
        public bool PtoVentaCtrl(string ptoV)
        {
            bool ret = false;

            if (ptoV is not null && ptoV.Length <= 5)
            {
                foreach (char item in ptoV)
                {
                    if (!(char.IsDigit(item)))
                    {
                        return ret;
                    }
                }
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Controla que el string pasado por parametro seran digitos y no supere los 8 caracteres
        /// </summary>
        /// <param name="nroComp"></param>
        /// <returns></returns>
        public bool nroCompCtrl(string nroComp)
        {
            bool ret = false;

            if (nroComp is not null && nroComp.Length <= 8)
            {
                foreach (char item in nroComp)
                {
                    if (!(char.IsDigit(item)))
                    {
                        return ret;
                    }
                }
                ret = true;
            }
            return ret;
        }
       
        /// <summary>
        /// Muestra los datos importante del Comprobante
        /// </summary>
        /// <returns></returns>
        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Fecha.ToString("dd/MM/yyyy")} | ");
            sb.Append($"{(string)this.Ente} | ");
            sb.Append($"{this.DatosComprobante}");

            return sb.ToString();
        }
        
        /// <summary>
        /// Compara el ptoVenta, nroComprobante y datos del ente en cuestion para determinar si dos comprobantes son iguales
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Comprobante c1, Comprobante c2)
        {
            return (c1.Equals(c2) && c1.DatosComprobante == c2.DatosComprobante && c1.Ente == c2.Ente);
        }

        /// <summary>
        /// Compara el ptoVenta, nroComprobante y datos del ente en cuestion para determinar si dos comprobantes son distintos
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator !=(Comprobante c1, Comprobante c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Sobreescritura del Equals. Compara el tipo de dos objetos
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }




    }
}
