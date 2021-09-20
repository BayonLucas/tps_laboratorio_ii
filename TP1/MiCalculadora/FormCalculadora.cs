using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        int flagBinDec = 0;
        int flagDecBin = 0;



        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento Cierre del Form. Confirma si se desea realizar la accion en cuestion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Eveto click del boton Cerrar. Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Realiza la limpieza de los textBox, del label y del comboBox
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "-";
        }
        /// <summary>
        /// Realiza la operacion de los numeros de tipo string recibidos por parametros en funcion del operador de tipo string
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            char chOperador; 
            char.TryParse(operador, out chOperador);
            return Calculadora.Operar(num1, num2, chOperador);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Evento click del Boton "Operar" donde se realiza la misma luego de validad los textBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e) 
        {
            double resultado;
            if (txtNumero1.Text != "" && txtNumero2.Text != "")
            {
                resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
                if(cmbOperador.Text=="")
                    cmbOperador.SelectedIndex = 1;
                string historial = string.Format("{0} {1} {2} = {3}", txtNumero1.Text, cmbOperador.Text, txtNumero2.Text, resultado.ToString());

                lblResultado.Text = resultado.ToString();
                lstOperaciones.Items.Add(historial);
                flagBinDec = 0;
                flagDecBin = 0;
            }
        }
        /// <summary>
        /// Evento click del boton Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Evento del Boton "Convertir a Decimal" donde se realiza la respectiva conversion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComvertirADecimal_Click(object sender, EventArgs e)
        {
            if(flagBinDec == 0 && lblResultado.Text != "")
            { 
                Operando nDecimal = new Operando();
                lblResultado.Text = nDecimal.BinarioDecimal(lblResultado.Text);
                flagDecBin = 0;
                flagBinDec = 1;
            }
        }
        /// <summary>
        /// Evento del Boton "Convertir a Binario" donde se realiza la respectiva conversion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(flagDecBin == 0 && lblResultado.Text != "")
            {
                Operando nBinario = new Operando();
                lblResultado.Text = nBinario.DecimalBinario(lblResultado.Text);
                flagBinDec = 0;
                flagDecBin = 1;
            }
        }
        /// <summary>
        /// Valida que se ingrese en el TextBox1 unicamente digitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-')  
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Valida que se ingrese en el TextBox1 unicamente digitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
