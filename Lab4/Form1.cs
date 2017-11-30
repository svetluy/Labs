using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        int linesCount;
        int[] population = new int[20];

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)//происходит при открыти файла
        {
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = 0;
            }
            
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "txt files (*.txt)|*.txt";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                string[] lines = null;
                try
                {
                    lines = File.ReadAllLines(OPF.FileName, Encoding.Unicode);
                    linesCount = lines.Length;
                }               //при успешном открытии заполняется массив данными из табшлицы и считается количество строк в файле
                catch (Exception e3)
                {
                    linesCount = 0;
                    MessageBox.Show(e3.Message);    //ошибка смс 
                }

                FillTable(lines); //вызыывается метод заполнения таблицы
            }

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)//при нажатии кнопки сохранить
        {
            SaveFileDialog SVF = new SaveFileDialog();
            SVF.Filter = "txt files (*.txt)|*.txt";
            if (SVF.ShowDialog() == DialogResult.OK)
            {
                string line = "";
                try
                {
                    using (StreamWriter sw = new StreamWriter(SVF.FileName, true, Encoding.Unicode))
                        for (int i = 0; i < linesCount; i++)
                            if (dataGridView1.Rows[i].Visible)//если сторка видимая она записывается файл
                            {
                                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                    try
                                    {
                                        line += (dataGridView1.Rows[i].Cells[j].Value);
                                        if (j!=2)
                                            line += ":";
                                    }
                                    catch (Exception e1)
                                    {
                                        MessageBox.Show(e1.Message);
                                    }
                                sw.WriteLine(line);
                                line = "";
                            }
                }
                catch (Exception e3)//
                {
                    MessageBox.Show(e3.Message);
                }

            }
        }

        private void FillTable(string[] lines)//метод заполнить таблицу
        {
            Clear();
            int sum = 0;

            for (int i = 0; i < linesCount; i++) // Цикл добавления строк
                dataGridView1.Rows.Add();  // добавление строки 

            for (int i = 0; i < linesCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    try
                    {
                        String[] substrings = lines[sum].Split(':');
                        dataGridView1.Rows[i].Cells[j].Value = substrings[j];
                        if(j==1)
                        {
                            population[i] = int.Parse(substrings[j]);
                        }
                    }
                    catch (Exception e1)
                    {
                          MessageBox.Show(e1.Message);
                    }
                sum++;
            }
        }


        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            dataGridView1.Dispose();

            dataGridView1 = new DataGridView
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            };
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
            City,
            Populations,
            Coords
            });
            dataGridView1.GridColor = SystemColors.ControlLightLight;
            dataGridView1.Location = new Point(0, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView1.Size = new System.Drawing.Size(578, 375);
            dataGridView1.TabIndex = 1;

            Controls.Add(dataGridView1);
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < linesCount; i++)
            {
                dataGridView1.Rows[i].Visible = true;
            }

            try
            {
                for (int i = 0; i < linesCount; i++)
                {
                    if (int.Parse(toolStripTextBox2.Text) > population[i])//остаются видимыми только строки, в которых значения совпали
                        dataGridView1.Rows[i].Visible = false;
                }
            }
            catch
            {

            }
        }

        private void заданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Крупные города России: название, численность населения, географические координаты." +
                " Вывести города с численностью выше заданного значения.");
        }
    }
}
