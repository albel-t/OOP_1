using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace OOP_1
{
    public partial class Form1 : Form
    {
        Random random;
        public Form1()
        {
            int a = 0, b = 0, c = 0;
            double ad = 0, bd = 0, cd = 0;
            InitializeComponent();

            this.buttonСalculate.Click += new System.EventHandler(this.buttonСalculate_Click);
            
            random = new Random();

            rand(ref a, ref b, ref c);
            richTextBox1.AppendText($"{a}-{b}-{c} = {a - b - c}\n");
            rand(ref a, ref b, ref c);
            richTextBox1.AppendText($"{a}*{b}*{c} = {a * b * c}\n");
            rand(ref a, ref b, ref c);
            richTextBox1.AppendText($"{a}+{b}+{c} = {a + b + c}\n");

            rand(ref ad, ref bd, ref cd);
            richTextBox1.AppendText($"{ad}-{bd}-{cd} = {ad - bd - cd}\n");
            rand(ref ad, ref bd, ref cd);
            richTextBox1.AppendText($"{ad}*{bd}*{cd} = {ad * bd * cd}\n");
            rand(ref ad, ref bd, ref cd);
            richTextBox1.AppendText($"{ad}+{bd}+{cd} = {ad + bd + cd}\n");

            rand(ref a, ref b, ref c);
            rand(ref ad, ref bd, ref cd);
            if(b != 0)
               richTextBox1.AppendText($"{a}/{b} = {(1.0*a) / b}\n");  
            else
                richTextBox1.AppendText($"{a}/{b} = +INF\n");

            if (b != 0)
                richTextBox1.AppendText($"{ad}/{bd} = {ad / bd}\n");
            else
                richTextBox1.AppendText($"{ad}/{bd} = +INF\n");
        }
        private double CalculateU(double x = -4.5, double y = 0.000075, double z = 84.5)
        {
            double absXY = Math.Abs(x - y);
            double cubeRoot = Math.Pow(8 + Math.Pow(absXY, 2) + 1, 1.0 / 3.0);
            double denominator = Math.Pow(x, 2) + Math.Pow(y, 2) + 2;
            double firstPart = cubeRoot / denominator;

            double secondPart = Math.Exp(absXY) * Math.Pow(Math.Pow(Math.Tan(z), 2) + 1, x);

            return firstPart - secondPart;
        }
        private int rand()
        {
             return random.Next(1, 101);
        }
        private void rand(ref int a_, ref int b_, ref int c_)
        {
            a_ = random.Next(0, 101);
            b_ = random.Next(0, 101);
            c_ = random.Next(0, 101);
        }
        private void rand(ref double a_, ref double b_, ref double c_)
        {
            a_ = random.Next(0, 101) / 10.0 + 0.05;
            b_ = random.Next(0, 101) / 10.0 + 0.05;
            c_ = random.Next(0, 101) / 10.0 + 0.05;
        }
        private void buttonСalculate_Click(object sender, EventArgs e)
        {
            string xValue = textBoxX.Text;
            string yValue = textBoxY.Text;
            string zValue = textBoxZ.Text;

            if (string.IsNullOrEmpty(xValue) ||
                    string.IsNullOrEmpty(yValue) ||
                    string.IsNullOrEmpty(zValue))
            {
                textBox1.Text = CalculateU().ToString();
                textBoxX.Text = "-4.5";
                textBoxY.Text = "0.000075"; 
                textBoxZ.Text = "84.5";
            }
            else
            {
                double x = Convert.ToDouble(xValue), y = Convert.ToDouble(yValue), z = Convert.ToDouble(zValue);
                textBox1.Text = CalculateU(x, y, z).ToString();
            }



            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}