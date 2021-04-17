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
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
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
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string operador = cmbOperador.Text;
            if (numero1 != "" && numero2!="")
            {
                double resultado = FormCalculadora.Operar(numero1, numero2, operador);
                lblResultado.Text = resultado.ToString();
                if (operador != "+" && operador != "-" && operador != "/" && operador != "*")
                {
                    cmbOperador.Text = "+";
                }
            }else
            {
                MessageBox.Show("Es necesario ingresar ambos números para operar", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero = lblResultado.Text;
            lblResultado.Text = Numero.DecimalBinario(numero);

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numeroBin = lblResultado.Text;
            lblResultado.Text = Numero.BinarioDecimal(numeroBin);
        }
    }
}
