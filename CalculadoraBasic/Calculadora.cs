using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraBasic
{
    class Calculadora
    {
        private string total;
        private static string condition;

        // testeando
        private double Soma(double p1, double p2)
        {
            return p1 + p2;
        }
        private double Subtracao(double p1, double p2)
        {
            return p1 - p2;
        }
        private double Multiplicacao(double p1, double p2)
        {
            return p1 * p2;
        }
        private double Divisao(double p1, double p2)
        {
            return p1 / p2;
        }
        public string Total
        {
            get { return total; }
            set { total = value; }
        }
        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        public string Calcular(string cond, string p1, string p2)
        {
            try
            {
                if (cond == "+" )
                {
                    Total = Soma(double.Parse(p1), double.Parse(p2)).ToString();
                }
                else if (cond == "-")
                {
                    Total = Subtracao(double.Parse(p2), double.Parse(p1)).ToString();
                }
                else if (cond == "*")
                {
                    Total = Multiplicacao(double.Parse(p2), double.Parse(p1)).ToString();
                }
                else if (cond == "/")
                {
                    Total = Divisao(double.Parse(p2), double.Parse(p1)).ToString();
                }                  
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            return Total;
        }

    }
}
