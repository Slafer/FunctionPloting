using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progaexam
{
    public partial class Form1 : Form
    {
        Calculation eq;
        Ploting plot;

        public Form1()
        {
            InitializeComponent();
            eq = new Calculation(function);
            plot = new Ploting(this.chart1, function);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(this.textBox1.Text);
            double b = double.Parse(this.textBox2.Text);
            double ep = double.Parse(this.textBox3.Text);
            plot.ShowPlot(a, b, ep);
            this.textBox4.Text = eq.FindRoot(a, b, ep).ToString();
        }

        static double function(double x)
        {
            return 8 * Math.Log(x) + (x - 3) * (x - 3) * (x - 3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plot.SavePlot();
            plot.Post();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plot.Get();
        }
    }
}
