using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_ADS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool enter = false;
        double result = 0;
        string operador = " ";

        // Numeros
        private void botao(object sender, EventArgs e)
        {
            if (resultado.Text == "0" || enter)
            {
                resultado.Text = "";
                enter = false;
            }
            Button button = (Button)sender;
            if (button.Text == ",")
            {
                if (!resultado.Text.Contains(","))
                {
                    if (resultado.Text == "")
                    {
                        resultado.Text += "0,";
                    }
                    else
                    {
                        resultado.Text += button.Text;
                    }
                }
            }
            else
            {
                resultado.Text += button.Text;
            }

        }

        // Operadores
        private void operadores(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultado.Text == "0" || enter)
            {
                resultado.Text = "0";
                enter = false;
            }
            if (result != 0)
            {
                conta.Text = " = " + resultado.Text + " " + operador + " " + result;
                // \(ㆆ_ㆆ)\  apenas que... busquem conhecimento
                buttonIgual.PerformClick();
                operador = button.Text;
                result = Convert.ToDouble(resultado.Text);
            }
            else
            {
                operador = button.Text;
                result = Convert.ToDouble(resultado.Text);
                conta.Text = operador + " " + result;
                enter = true;
            }
        }

        // Botao C
        private void buttonC_Click(object sender, EventArgs e)
        {
            result = 0;
            resultado.Text = conta.Text = "0";
            enter = false;
        }

        // Botao Igual
        private void buttonIgual_Click(object sender, EventArgs e)
        {
            if (result != 0)
            {
                conta.Text = " = " + resultado.Text + " " + operador + " " + result;
            }
            if (operador == "+")
            {
                resultado.Text = (result + Convert.ToDouble(resultado.Text)).ToString();
            }
            if (operador == "-")
            {
                resultado.Text = (result - Convert.ToDouble(resultado.Text)).ToString();
            }
            if (operador == "*")
            {
                resultado.Text = (result * Convert.ToDouble(resultado.Text)).ToString();
            }
            if (operador == "/")
            {
                if (Convert.ToDouble(resultado.Text) == 0.00)
                {
                    resultado.Text = "ERROR";
                }
                else
                {
                    resultado.Text = (result / Convert.ToDouble(resultado.Text)).ToString();
                }
            }
            enter = true;
        }
    }
}
