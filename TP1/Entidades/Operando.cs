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
        /// <summary>
        /// Propiedad. Settea el atributo "número" Validando que el mismo recibido no sea Null
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        /// <summary>
        /// Valida que el string recibido sea un numero binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna true en casi de ser binario. Caso opuesto, retorna false</returns>
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
        /// <summary>
        /// Transforma el string binario recibido a un numero decimal de tipo double.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>De lograr la convercion, returna el numero decimal de tipo double. Caso contrario, retorna "Valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            int exponente = 0;
            double nDec = 0;
            
            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    int.TryParse(binario[i].ToString(), out int auxIntChar);
                    nDec += auxIntChar * (Math.Pow(2, exponente));
                    exponente++;
                }
                return nDec.ToString();
            }
            return "Valor Inválido";
        }
        /// <summary>
        /// Transforma el double decimal recibido a un numero en binario de tipo string.
        /// </summary>
        /// <param name="d"></param>
        /// <returns>De lograr la convercion, returna el numero binario de tipo string. Caso contrario, retorna "Valor invalido"</returns>
        public string DecimalBinario(double d)
        {
            StringBuilder sb = new StringBuilder();
            if (!double.IsNaN(d))
            {
                d = Math.Abs(d);
                while (d >= 1)
                {
                    if ((int)d % 2 == 0)
                    {
                        sb.Insert(0,'0');
                    }
                    else
                    {
                        sb.Insert(0, '1');
                    }
                    d = d / 2;
                }
                return sb.ToString();
            }
            return "Valor Inválido";
        }
        /// <summary>
        /// Devuelve un string decimal a binario,posta validacion del mismo.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Retorna el numero binario de tipo string. Caso contrario retorna "Valor Invalido"</returns>
        public string DecimalBinario(string s)
        {
            double dec = ValidarOperando(s);
            
            return DecimalBinario(dec);
        }

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del Operador de suma entre Objetos Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobrecarga del Operador de resta entre Objetos Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga del Operador de Division entre Objetos Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Sobrecarga del Operador de Multiplicacion entre Objetos Operando
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        #endregion
        /// <summary>
        /// Valida que el string ingresado por parametro sea un numero
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el numero en el tipo double en caso de ser true. Caso opuesto, retorna 0</returns>
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