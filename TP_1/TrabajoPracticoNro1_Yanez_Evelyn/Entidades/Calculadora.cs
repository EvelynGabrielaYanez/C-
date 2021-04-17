using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            string cadena;
            switch (operador)
            {
                case '+':
                case '-':
                case '/':
                case '*':
                    cadena = operador.ToString();
                    break;
                default:
                    cadena = "+";
                    break;
            }
            return cadena;
        }
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            char auxOperador;
            double retorno = 0;
            if(!char.TryParse(operador, out auxOperador))
            {
                auxOperador = ' ';
            }
             operador = ValidarOperador(auxOperador);
             switch (operador)
             {
                case "+":
                    retorno = numero1 + numero2;
                    break;
                case "-":
                    retorno = numero1 - numero2;
                    break;
                case "/":
                    retorno = numero1 / numero2;
                    break;
                case "*":
                    retorno = numero1 * numero2;
                    break;
             }
            return retorno;
        }
    }
}
