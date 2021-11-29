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
                    string aux;
                    aux = EmprolijarString(value);
                    aux = aux.Replace(" ", "");
                    while(aux.Length<24)
                    {
                        aux += " ";
                    }
                    this.razonSocial = aux;
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

        public Ente() : this (string.Empty, string.Empty, ESitFiscal.Consumidor_Final)
        {        }
        public Ente(string razonSocial, string cuit, ESitFiscal sitFiscal)
        {
            this.razonSocial = razonSocial;
            this.Cuit = cuit;
            this.SitFiscal = sitFiscal;
        }

        /// <summary>
        /// Sobrecarga explicita para el casteo de Ente a string
        /// </summary>
        /// <param name="e"></param>
        public static explicit operator string(Ente e)
        {
            StringBuilder sb = new StringBuilder();
            if (e is not null)
            {
                sb.Append($"{e.RazonSocial} | ");
                sb.Append($"{e.Cuit} | ");
                sb.Append($"{e.SitFiscal}");
            }

            return sb.ToString();
        }
      
        /// <summary>
        /// Compara si dos Entes son iguales si comparten el mismo cuit
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator ==(Ente e1, Ente e2)
        {
            return (e1.Cuit == e2.Cuit);
        }

        /// <summary>
        /// Compara si dos Entes son no iguales si difieren sus cuits
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator !=(Ente e1, Ente e2)
        {
            return !(e1 == e2);
        }

        /// <summary>
        /// Controla que el string ingresado por parametro este formado solo por 11 digitos
        /// </summary>
        /// <param name="cuit"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sobreescritura necesaria para windows Forms
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.RazonSocial} - {this.Cuit}";
        }

        /// <summary>
        /// Le da un formato mas agradable a la vista a la razon Social del ente
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EmprolijarString(string str)
        {
            char[] strChar = null;
            if (!string.IsNullOrEmpty(str))
            {
                str = str.ToLower();
                strChar = str.ToCharArray();
                for(int i = 0; i<str.Length; i++)
                {
                    if(i == 0 || strChar[i-1] == ' ')
                    {
                        strChar[i] = char.ToUpper(strChar[i]);
                    }
                }
            }
            string aux = null;
            for (int i = 0; i < strChar.Length; i++)
            {
                aux = aux + strChar[i];
            }
            return aux;
        }

    }
}
