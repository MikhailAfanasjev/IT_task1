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
            int[] res1 = new int[n];  //массив для хранения сумм строк
            int summ1 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    summ1 += B[i, j];   //суммируем элементы строки
                }
                res1[i] = summ1; //пишем сумму в массив
                summ1 = 0; //обнуляем переменную
            }

            int max = 0;    //индекс строки с максимальной суммой
            for (int j = 1; j < n; j++)
            {
                if (res1[j] > res1[max])   //если есть строка с суммой больше, то пишем в max её индекс
                    max = j;
            }
            Console.WriteLine("Номер строки с максимальной суммой элементов: " + max);
            Console.ReadLine();

            int[] res2 = new int[n];   //то же самое, только для столбцов
            int summ2 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    summ2 += B[j, i];  // индексы меняем местами, чтобы просматривались не строки, а столбцы.
                }
                res2[i] = summ2;
                summ2 = 0;
            }

            int min = 0;
            for (int j = 1; j < n; j++)
            {
                if (res2[j] < res1[min])
                    min = j;
            }

            Console.WriteLine("Номер столбца с минимальной суммой элементов: " + min);
            Console.ReadLine();

        }

        static int MinElement(int[,] mass)
        {
            int minElement = mass[0, 0];
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    if (minElement > mass[i, j])
                    {
                        minElement = mass[i, j];
                    }
                }
            }
            return minElement;
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
            /*int n = dataGridView1.RowCount;
            double[,] mass = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mass[i, j] = (double)dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            Solution(mass);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = mass[i, j];
                }
            }
       */ }
    }
}
