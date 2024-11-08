using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Paciente : UserControl
    {

        String[] Names = new string[100];
        String[] Apellido = new string[100];
        String[] fechaNacimiento = new string[100];
        String[] Genero = new string[100];
        String[] Departamento = new string[100];
        String[] Consulta = new string[100];
        String[] Alergias = new string[100];

        int currentIndex = 0;
        public Paciente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentIndex < Names.Length)
            {
                Names[currentIndex] = textBox1.Text;
                Apellido[currentIndex] = textBox2.Text;
                fechaNacimiento[currentIndex] = textBox3.Text;
                Genero[currentIndex] = textBox4.Text;
                Departamento[currentIndex] = textBox5.Text;
                Consulta[currentIndex] = comboBox1.SelectedItem?.ToString();
                Alergias[currentIndex] = richTextBox1.Text;

                currentIndex++;

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.SelectedIndex = -1;
                richTextBox1.Clear();

                MessageBox.Show("Información guardada correctamente.");
            }
            else
            {
                MessageBox.Show("No hay más espacio para guardar información.");
            }

            LlenarDataGridView();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                richTextBox1.Enabled = true;
            }
            else
            {
                richTextBox1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LlenarDataGridView()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < currentIndex; i++)
            {
                dataGridView1.Rows.Add(Names[i], Apellido[i], fechaNacimiento[i], Genero[i], Departamento[i], Consulta[i], Alergias[i]);
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
