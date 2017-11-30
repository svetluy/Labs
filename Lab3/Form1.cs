using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        TextBox[,] boxArr = new TextBox[10, 10];
        int[,] arr = new int[10, 10];

        public Form1()
        {
            InitializeComponent();
            CreateTable();
        }

        private void CreateTable()
        {
            Point location = new Point(20, 20);
            Size size = new Size(30, 30);

            foreach (var box in boxArr)
            {
                Controls.Remove(box);
            }

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    boxArr[i, j] = new TextBox
                    {
                        Location = location,
                        Size = size
                    };
                    boxArr[i, j].Click += textBox_Click;
                    Controls.Add(boxArr[i,j]);
                    location.X += 40;
                }
                location.X = 20;
                location.Y += 30;
            }
        }

        private void FillTable()
        {
            Random random = new Random();
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    arr[i, j] = random.Next(101) - 50;
                    boxArr[i, j].Text = $"{arr[i, j]}";
                }
            }
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                for (int j = 0; j < numericUpDown2.Value; j++)
                {
                    if (boxArr[i, j].Equals(sender))
                    {
                        Add(i,j,arr);
                    }
                }
            }
        }

        private void Add(int i, int j, int[,] arr)
        {
            if(arr[i,j] > 0)
                for (int k = 0; k < numericUpDown1.Value; k++)
                {
                    for (int n = 0; n < numericUpDown2.Value; n++)
                    {
                        arr[k, n] += 1;
                        boxArr[k, n].Text = $"{arr[k,n]}"; 
                    }
                }
            else if(arr[i, j] < 0)
                for (int k = 0; k < numericUpDown1.Value; k++)
                {
                    for (int n = 0; n < numericUpDown2.Value; n++)
                    {
                        arr[k, n] -= 1;
                        boxArr[k, n].Text = $"{arr[k, n]}";
                    }
                }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillTable();
        }
    }
}
