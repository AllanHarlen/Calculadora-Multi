using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CalculadoraBasic
{
    public partial class Form1 : Form
    {

        Calculadora continha = new Calculadora();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Verifica se contém , para não colocar 2 vezes
            if (!textBox1.Text.Contains(",") && textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text + ",";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {        
            ExecuteCalculo("+");           
        }
                
        private void button18_Click(object sender, EventArgs e)
        {
            continha.Total = "0";
            textBox1.Text = "";
            textBox2.Text = "0";
            button12.Focus();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            continha.Condition = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ExecuteCalculo("-");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ExecuteCalculo("*");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ExecuteCalculo("/");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExecuteEnter();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        // função para executar a condição do enter e gerar o valor total.
        private void ExecuteEnter()
        {
            if (continha.Condition != null)
            {
                ExecuteCalculo(continha.Condition);
                textBox2.Text = continha.Total;
                textBox1.Text = continha.Total;
                continha.Condition = "Enter";
                Focus();
            } 
        }

        // função para executar o calculo.
        private void ExecuteCalculo(string condition)
        {
            // Verifica se as condição de execução do código.          
            if (condition == "+" || condition == "-" || condition == "/" || condition == "*")
            { 
                // Se o valor total for 0 e apertar enter, ele assumir a numeração.
                if (textBox2.Text == "0" && !string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox2.Text = textBox1.Text;
                    textBox1.Text = "";
                }
                else
                {
                    // Verifica para não executar o calculo com o campo vazio.
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        // Mudança de operação exemplo: 5+5-value, calcular o 5+5=10-value
                        if (continha.Condition != condition && continha.Condition != "")
                        {
                            continha.Calcular(continha.Condition, textBox1.Text, textBox2.Text);
                        }
                        else
                        {
                            continha.Calcular(condition, textBox1.Text, textBox2.Text);
                        }
                        textBox2.Text = continha.Total;
                        textBox1.Text = "";
                    }
                }
                
                continha.Condition = condition;  
            }           
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = e.KeyChar;

            // se a tecla for backspack excluir
            if (tecla == 8 && !string.IsNullOrEmpty(textBox1.Text))
            {
                string txt = textBox1.Text;
                txt = txt.Substring(0, txt.Length - 1);
                textBox1.Text = txt;
                continha.Condition = "";
            }

            // Verifica se é numero ou teclas como enter, +, -;
            if (char.IsNumber(e.KeyChar) || tecla == 8 || tecla == 44 || tecla == 43 || tecla == 45 || tecla == 42 || tecla == 47 || tecla == 13)
            {
                // Verifica se contém , para não colocar 2 vezes
                if ((textBox1.Text.Contains(",") || string.IsNullOrEmpty(textBox1.Text)) && e.KeyChar == 44)
                {
                    e.Handled = true;
                }
                else
                {
                    // verificar se a tecla é enter para executar o enter.
                    if (tecla == 13)
                    {
                        e.Handled = true;
                        ExecuteEnter();
                    }
                    else
                    {
                        // verifica aqui se as teclas são as de operações para executar o calculo.
                        if (tecla == 43 || tecla == 45 || tecla == 42 || tecla == 47 || (continha.Condition == "" & tecla == 8))
                        {
                            e.Handled = true;
                            ExecuteCalculo(e.KeyChar.ToString());
                        }
                        // se as teclas for numero vai adicionar ao textbox1
                        else
                        {
                            // não adicionar a tecla backspace
                            if (tecla != 8)
                            {
                                e.Handled = true;
                                textBox1.Text = textBox1.Text + e.KeyChar.ToString(); 
                            }                  
                        }
                    }
                }                               
            }
            // se não for numero ou as teclas exclusivas, não fazer nada.
            else
            {
                e.Handled = true;
            }
        }
    }
}
