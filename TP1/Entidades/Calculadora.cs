using System;

namespace Entidades
{
    public static class Calculadora
    {
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
            {
                operador = '+';
            }
            return operador;
        }
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
