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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        String[] Names = new string[100];
        String[] Apellido = new string[100];
        String[] fechaNacimiento = new string[100];
        String[] Genero = new string[100];
        String[] Departamento = new string[100];
        String[] Consulta = new string[100];
        String[] Alergias = new string[100];

        int currentIndex = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }




        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Paciente pacienteControl = new Paciente();
            if(panel7.Contains(pacienteControl) == false) {
                panel7.Controls.Add(pacienteControl);
                pacienteControl.Dock = DockStyle.Fill;
                pacienteControl.BringToFront();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main MainControl = new Main();
            if (panel7.Contains(MainControl) == false)
            {
                panel7.Controls.Add(MainControl);
                MainControl.Dock = DockStyle.Fill;
                MainControl.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main1_Load(object sender, EventArgs e)
        {

        }
    }

}
