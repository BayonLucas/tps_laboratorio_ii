using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Ente
    {
        private string razonSocial;
        private string cuit;
        private ESitFiscal sitFiscal;

        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }
            set
            {   
                if(!(string.IsNullOrWhiteSpace(value)))
                {
                    //Aca deberia de extraer un max de 20 caracteres.
                    this.razonSocial = value.ToUpper();
                }
            }
        }
        public string Cuit
        {
            get
            {
                return this.cuit;
            }
            set
            {
                if (CuitCtrl(value))
                {
                    this.cuit = value;
                }
                else
                {
                    this.cuit = "99999999999";
                }
            }
        }
        public ESitFiscal SitFiscal
        {
            get
            {
                return this.sitFiscal;
            }
            set
            {
                this.sitFiscal = value;
            }
        }

        public Ente(string razonSocial, string cuit, ESitFiscal sitFiscal)
        {
            this.RazonSocial = razonSocial;
            this.Cuit = cuit;
            this.SitFiscal = sitFiscal;
        }

        public static explicit operator string(Ente e)
        {
            StringBuilder sb = new StringBuilder();
            if (e is not null)
            {
                sb.Append($"{e.RazonSocial} | ");
                sb.Append($"{e.Cuit} | ");
                sb.Append($"{e.SitFiscal} | ");
            }

            return sb.ToString();
        }
        //public static explicit operator Ente(string e)
        //{
        //    string auxRazonSocial = "aaaaaaaaaaaaaaaaaaaa";
        //    string auxCuit = "99999999999";
        //    ESitFiscal auxSitFiscal = ESitFiscal.ResponsableInscripto;

        //    if (string.IsNullOrWhiteSpace(e)) //Lo que recibo string = Pitulo | 201234567789 | ResponsableInscripto
        //    {
        //        string buffer = "";
        //        int contador = 0;

        //        for(int i  = 0; i<e.Length;i++)
        //        {
        //            if (e.ElementAt(i) != '|') 
        //            {
        //                buffer = buffer + e.ElementAt(i);
        //            }
        //            else if (contador == 0)
        //            {
        //                i++;
        //                auxRazonSocial = buffer;
        //                contador++;
        //                buffer = "";
        //            }
        //            else if (contador == 1)
        //            {
        //                i++;
        //                auxCuit = buffer;
        //                contador++;
        //                buffer = "";
        //            }
        //            else
        //            {
        //                switch(buffer)
        //                {
        //                    case "ResponsableInscripto ":
        //                        auxSitFiscal = ESitFiscal.ResponsableInscripto;
        //                        break;
        //                    case "Monotributista ":
        //                        auxSitFiscal = ESitFiscal.Monotributista;
        //                        break;
        //                    case "ConsumidorFinal ":
        //                        auxSitFiscal = ESitFiscal.ConsumidorFinal;
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    return new Ente(auxRazonSocial, auxCuit, auxSitFiscal);
        //} //Revisar bien
        public static bool operator ==(Ente e1, Ente e2)
        {
            return (e1.Cuit == e2.Cuit);
        }
        public static bool operator !=(Ente e1, Ente e2)
        {
            return !(e1 == e2);
        }

        public bool CuitCtrl(string cuit)
        {
            bool ret = false;
            if (cuit is not null && cuit.Length == 11)
            {
                foreach (char item in cuit)
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





    }
}
