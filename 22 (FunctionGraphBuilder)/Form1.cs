using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22__FunctionGraphBuilder_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void value_TextChanged(object sender, EventArgs e)
        {
            if (operations.Text != "" && value.Text != "")
            {
                createGraph();
            }
        }

        private void operations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(operations.Text != "" && value.Text != "")
            {
                createGraph();
            }
        }

        private void createGraph()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            for (int x = -10; x <= 10; x++)
            {
                Single y = F(operations.Text, x.ToString(), value.Text);

                chart1.Series[0].Points.AddXY(x, 0);
                chart1.Series[1].Points.AddXY(0, y);

                chart1.Series[2].Points.AddXY(x, y);
            }
        }

        private Single F(String operations, String valueX, String valueB)
        {
            Single x = Convert.ToSingle(valueX);
            Single b = Convert.ToSingle(valueB);

            switch (operations)
            {
                case "+":
                    chart1.Series[2].Color = Color.Red;
                    return x + b;
                case "-":
                    chart1.Series[2].Color = Color.Blue;
                    return x - b;
                case "*":
                    chart1.Series[2].Color = Color.Green;
                    return x * b;
                case "/":
                    chart1.Series[2].Color = Color.Brown;
                    return x / b;
                default:
                    chart1.Series[2].Color = Color.BurlyWood;
                    return (float)Math.Pow(x, b);
            }
        }
    }
}
