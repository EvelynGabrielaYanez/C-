using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        /// <summary>
        ///     Propiedad SetNumero que calida el numero y lo setea
        /// </summary>
        public string SetNumero
        {
            set{
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        ///     Propiedad numero que contiene el valor numerico del Numero
        /// </summary>
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
        /// <summary>
        ///    Valida si el string pasado por parametro es un numero, 
        ///    caso contrario considera que este es un cero.
        ///    Finalmente lo retorna como double
        /// </summary>
        /// <param name="strNumero">cadena de caracteres que contiene el numero</param>
        /// <returns>double retorno del numero correspondiente al string</returns>
        static double ValidarNumero(string strNumero)
        {
            double retorno;
            if (!double.TryParse(strNumero, out retorno))
            {
                retorno = 0;
            }
            return retorno;
        }
        /// <summary>
        ///     Valida si es binario el parametro pasado como string y retorna true o false
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>bool retorno de la validacion true = es binario false = no es binario</returns>
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
        /// <summary>
        ///     Realiza el pasaje de decimal a binario.
        ///     La conversion se realiza sobre la parte entera y el valor absoluto del numero recibido
        /// </summary>
        /// <param name="numero">double Numero que se desea converitr a binario</param>
        /// <returns>
        ///     string Retorna la conversion del numero pasado por parametros binario.
        ///            En caso de no ser valida la conversion (porque exedio 
        ///            la dimension del double)  retorna"Valor inválido"  
        /// </returns>
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
            //Si se excedio la dimension del double y por lo tanto este arrojo el valor por defecto (negativo)
            //se retornara "Valor invalido"
            if (retorno[0].Equals( '-'))
            {
                retorno = "Valor inválido";
            }
            return retorno;
        }
        /// <summary>
        ///     Realiza el pasaje de decimal a binario.
        ///     La conversion se realiza sobre la parte entera y el valor absoluto del numero recibido
        /// </summary>
        /// <param name="numero">string Cadena con el numero que se desea convertir a vinario</param>
        /// <returns>string 
        ///         Si la cadena pasada por parametros no es un numero o la conversion a binario
        ///         excede las dimensiones del double se retornara  "Valor inválido".
        ///         Caso contrario se retornara la cadena con el binario correspondiente.
        /// </returns>
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
        /// <summary>
        ///     Realiza el pasaje de binario a decimal.
        ///     La conversion se realiza sobre la parte entera y el valor absoluto del numero recibido  
        /// </summary>
        /// <param name="binario">string cadena de caracteres con el numero binario a converir</param>
        /// <returns>string Si el parametro pasado como string no era un vinario 
        ///                 se retorna "Valor invalido". Caso contrario se retorna 
        ///                 el decimal corespondiente a la conversion.
        /// </returns>
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
        /// <summary>
        ///     Realiza la sobrcarga del operador + 
        ///     Esta realizara la suma de las propedades numero de los Numeros
        ///     y retornara el resultado de la misma.
        /// </summary>
        /// <param name="n1">Numero Primer numero a sumar</param>
        /// <param name="n2">Numero Segundo numero a sumar</param>
        /// <returns>double resultado de la suma de las propiedades numero</returns>
        public static double operator +(Numero n1,Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        ///     Realiza la sobrcarga del operador -
        ///     Esta realizara la resta de las propedades numero de los Numeros
        ///     y retornara el resultado de la misma.
        /// </summary>
        /// <param name="n1">Numero Primer numero a restar</param>
        /// <param name="n2">Numero Segundo numero a restar</param>
        /// <returns>double resultado de la resta de las propiedades numero</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        ///     Realiza la sobrcarga del operador *
        ///     Esta realizara del producto de las propedades numero de los Numeros
        ///     y retornara el resultado del mismo.
        /// </summary>
        /// <param name="n1">Numero Primer numero a multiplicar</param>
        /// <param name="n2">Numero Segundo numero a multiplicar</param>
        /// <returns>double resultado del producto de las propiedades numero</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        ///     Realiza la sobrcarga del operador /
        ///     Esta realizara de la division de las propedades numero de los Numeros
        ///     y retornara el resultado de la misma.
        /// </summary>
        /// <param name="n1">Numero Dividendo</param>
        /// <param name="n2">Numero Divisor</param>
        /// <returns>
        ///     double resultado de la division de las propiedades numero.
        ///            Si el divisor es 0 retorna el valor de double.MinValue
        /// </returns>
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
