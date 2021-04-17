using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        public string SetNumero
        {
            set{
                this.numero = ValidarNumero(value);
            }
        }
        private double numero;
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        public Numero(double numero) :this(numero.ToString())
        {
        }
        static double ValidarNumero(string strNumero)
        {
            double retorno;
            if (!double.TryParse(strNumero, out retorno))
            {
                retorno = 0;
            }
            return retorno;
        }


        private static bool EsBinario(string binario)
        {
            bool retorno = true;

            foreach(char caracter in binario)
            {
                if (!caracter.Equals('0') && !caracter.Equals('1'))
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
        public static string DecimalBinario(double numero)
        {
            string retorno = "";
            int div = (int)Math.Floor(Math.Abs(numero));
            while (div >= 2)
            {
                retorno = (div % 2).ToString() + retorno;
                div = (div - div % 2) / 2;
            }
            retorno = div + retorno;
            if (retorno[0].Equals( '-'))
            {
                retorno = "Valor inválido";
            }
            return retorno;
        }
        public static string DecimalBinario(string numero)
        {
            string retorno;
            double auxNumero;

            if (double.TryParse(numero, out auxNumero))
            {
                retorno = Numero.DecimalBinario(auxNumero);
            }
            else
            {
                 retorno = "Valor inválido";
            }
            return retorno;
        }
        public static string BinarioDecimal(string binario)
        {
            int numDecimal = 0;
            string retorno;
            int bit;
            int i = 0;
            if (Numero.EsBinario(binario))
            {
                foreach (char c in binario)
                {
                    bit = int.Parse(c.ToString());
                    numDecimal += bit * (int)(Math.Pow(2, (binario.Length - 1) - i));
                    i++;
                }
                retorno = numDecimal.ToString();
            }
            else
            {
                retorno = "Valor inválido";
            }
            return retorno;
        }
        public static double operator +(Numero n1,Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double numeroRetorno;
            if (n2.numero == 0)
            {
                numeroRetorno = double.MinValue;
            }
            else
            {
                numeroRetorno = n1.numero / n2.numero;
            }
            return numeroRetorno;
        }
    }

}
