using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida si el operador es +,-,/ o * y retorna el mismo en modo de string
        /// En caso de no ser ninguno de los tres retorna "+"
        /// </summary>
        /// <param name="operador">Caracter del operador</param>
        /// <returns>Cadena de caracteres con el operador +,/,*,- según corresponda</returns>
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
        /// <summary>
        ///     Realiza la operacion correspondente al operador pasado por paramentro
        ///     y retorna el resultado de la misma. 
        /// </summary>
        /// <param name="numero1">Primer numero del tipo Numero con el que se va a operar</param>
        /// <param name="numero2">Segundo numero del tipo Numero con el que se va a operar</param>
        /// <param name="operador">Operador que representa la operaicon que se desea realizar</param>
        /// <returns>Resultado de la operacion realizada</returns>
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
