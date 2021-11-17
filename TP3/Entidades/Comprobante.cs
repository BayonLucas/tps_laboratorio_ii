using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
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

        public Comprobante(Ente enteEmisor, string ptoVenta, string nroComprobante, DateTime fecha)
        {
            this.Fecha = fecha;
            this.enteEmisor = enteEmisor;
            this.PtoVenta = ptoVenta;
            this.NroComprobante = nroComprobante;
        }

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
        public bool CuitCtrl(string cuit)
        {
            bool ret = false;
            if(cuit is not null && cuit.Length == 11)
            {
                foreach(char item in cuit)
                {
                    if(!(char.IsDigit(item)))
                    {
                        return ret;
                    }
                }
                ret = true;
            }
            return ret;
        }

        public virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Fecha.ToString("dd/MM/yy")} | ");
            sb.Append($"{(string)this.Ente} | ");
            sb.Append($"{this.DatosComprobante}");

            return sb.ToString();
        }
        
        public static bool operator ==(Comprobante c1, Comprobante c2)
        {
            return (c1.Equals(c2) && c1.DatosComprobante == c2.DatosComprobante && c1.Ente == c2.Ente);
        }
        public static bool operator !=(Comprobante c1, Comprobante c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }




    }
}
