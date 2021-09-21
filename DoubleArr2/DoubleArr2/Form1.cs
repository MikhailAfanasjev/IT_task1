using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleArr2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static void Solution(double[,] mass)
        {
            int size = mass.GetLength(0);
            double min = 0;
            double minHelp = 0;
            int num = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0)
                    {
                        min += mass[i, j];
                    }
                    else
                    {
                        minHelp += mass[i, j];
                        if (j == size - 1)
                        {
                            if (minHelp < min)
                            {
                                min = minHelp;
                                num = i;
                            }
                            minHelp = 0;
                        }
                    }
                }
            }    
            min = 0;
            minHelp = 0;
            int num2 = 0;
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    if (j == 0)
                    {
                        min += mass[i, j];
                    }
                    else
                    {
                        minHelp += mass[i, j];
                        if (i == size - 1)
                        {
                            if (minHelp > min)
                            {
                                min = minHelp;
                                num2 = j;
                            }
                            minHelp = 0;
                        }
                    }
                }
            }
            min = mass[0,0];
            minHelp = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (mass[i,j] < min)
                    {
                        min = mass[i,j];
                    }
                }
            }
            double [,] massHelp = new double[1,size];
            for (int i = 0; i < size; i++)
            {
                massHelp[0,i] = (mass[num2,i] - mass[num, i])/min;
            }
            mass = massHelp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            int.TryParse(textBox1.Text, out n);
            Random rand = new Random();
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rand.NextDouble() * 100;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.RowCount;
            double[,] mass = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mass[i, j] = (double)dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            Solution(mass);
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = mass[0,i];
            }
        }
    }
}
