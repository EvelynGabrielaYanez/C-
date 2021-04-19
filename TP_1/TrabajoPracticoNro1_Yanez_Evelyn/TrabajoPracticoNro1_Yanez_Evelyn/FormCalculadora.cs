using Entidades;
using System;
using System.Windows.Forms;

namespace TrabajoPracticoNro1_Yanez_Evelyn
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        ///     Llamara al metodo Limpiar(), encargado de limpiar los textbox, label y combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        ///     Metodo que limpiara el txtNumero1, txtNumero2,lblResultado y cmbOperador
        /// </summary>
        private void Limpiar()
        {
            //Limpio la caja de texto del numero 1
            this.txtNumero1.Clear();
            //Limpio la caja de texto del numero 2
            this.txtNumero2.Clear();
            //Limpio el label del resultado
            this.lblResultado.Text = "";
            //Limpio el combo box de seleccion de operador
            this.cmbOperador.Text = "";
        }
        /// <summary>
        ///     Metodo que validara que los numeros pasados como parametro sean validos
        ///     En caso serlo llamara al metodo Operar de la clase Calculadora pasandole 
        ///     los numeros y el operador.Y retornara el resultado de dicho caluclo.
        ///     En caso de no ser vlaidos retornara 0.
        /// </summary>
        /// <param name="numero1">string primer numero a operar</param>
        /// <param name="numero2">string segundo numero a operar</param>
        /// <param name="operador">string operador con la operaciona realizar</param>
        /// <returns>resultado de la operacion (en caso de no ser validos los parametros retorna 0)</returns>
        static double Operar(string numero1, string numero2, string operador)
        {
            double retorno = 0;
            double auxNumero1;
            double auxNumero2;
            if (double.TryParse(numero1, out auxNumero1) && double.TryParse(numero2, out auxNumero2))
            {
                retorno = Calculadora.Operar(new Numero(auxNumero1), new Numero(auxNumero2), operador);
            }
            return retorno;
        }
        /// <summary>
        ///     Llamara a la funcion operar y asignara a lblResultado el resultado de la msima
        ///     Pasandole los valores de txtNumero1,txtNumero2 y cmbOperador como parametro
        ///     Encaso de ser cmbOperador distitno de +,/,*,- le asigara a cmbOperador el valor +
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string operador = cmbOperador.Text;

                double resultado = FormCalculadora.Operar(numero1, numero2, operador);
                lblResultado.Text = resultado.ToString();
                if (operador != "+" && operador != "-" && operador != "/" && operador != "*")
                {
                    cmbOperador.Text = "+";
                }
        }
        /// <summary>
        ///     Le pedira confiramcion al usuario y en caso de que este acepte cerrara el forumario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }
        /// <summary>
        ///     Realizara la converesion de binario a decimal y le asignara el
        ///     resultado de la misma a lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero = lblResultado.Text;
            lblResultado.Text = Numero.DecimalBinario(numero);

        }
        /// <summary>
        ///     Realizara la converesion de decimal a binario y le asignara el
        ///     resultado de la misma a lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroBin = lblResultado.Text;
            lblResultado.Text = Numero.BinarioDecimal(numeroBin);
        }
    }
}
