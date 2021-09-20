using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador sea "+, -, / o *".
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador validado. Caso contrario, retorna "+"</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
            {
                operador = '+';
            }
            return operador;
        }
        /// <summary>
        /// Realiza la operacion pasado por parametro entre los numero tambien dados por parametro
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el total de la operacion.</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double total = 0;
            if (!(num1 is null) && (!(num2 is null)))
            {
                switch (ValidarOperador(operador))
                {
                    case '+':
                        total = num1 + num2;
                        break;
                    case '-':
                        total = num1 - num2;
                        break;
                    case '*':
                        total = num1 * num2;
                        break;
                    case '/':
                        total = num1 / num2;
                        break;
                }
            }
            return total;
        }
    }
}
