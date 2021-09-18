using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        #region Constructores  
        public Operando()
        { }
        public Operando(double numero) : this()
        {
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        private bool EsBinario(string binario)
        {
            if (!(binario is null))
            {
                foreach (char item in binario)
                {
                    if (item != '1' && item != '0')
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public string BinarioDecimal(string binario) //11011 = 1x2^4+1x2^3+0x2^2+1x2^1+1x2^0
        {
            int exponente = 0;
            int aux;
            double nDec = 0;
            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    aux = (int)binario[i] * 2;
                    nDec += Math.Pow(aux, exponente);
                    exponente++;
                }
                return nDec.ToString();
            }
            return "Valor Inválido";
        }
        public string DecimalBinario(double d)
        {
            string strBinario = "";

            if (!double.IsNaN(d))
            {
                d = Math.Abs(d);
                while (d > 1)
                {
                    if ((int)d % 2 == 0)
                    {
                        strBinario.Insert(0, "0");
                    }
                    else
                    {
                        strBinario.Insert(0, "1");
                    }
                    d = d / 2;
                }
                return strBinario;
            }
            return "Valor Inválido";
        }
        public string DecimalBinario(string s)
        {
            string ret;
            double dec= ValidarOperando(s);
            
            return ret = DecimalBinario(dec);
        }

        #region Sobrecargas
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno;
            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            else
            {
                retorno = double.MinValue;
            }
            return retorno;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        #endregion

        private double ValidarOperando(string strNumero)
        {
            double ret;
            if (!(Double.TryParse(strNumero, out ret)))
            {
                ret = 0;
            }
            return ret;
        }
    }
}