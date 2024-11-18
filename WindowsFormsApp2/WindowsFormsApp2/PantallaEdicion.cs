using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    public partial class PantallaEdicion : UserControl
    {
        private List<Perro> CargarPerrosDesdeArchivo()
        {
            List<Perro> perros = new List<Perro>();
            try
            {
                using (StreamReader reader = new StreamReader("perros.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var datos = line.Split(',');
                        perros.Add(new Perro
                        {
                            ID = int.Parse(datos[0]),
                            Nombre = datos[1],
                            Raza = datos[2],
                            Dueño = datos[3],
                            Telefono = datos[4],
                            Fecha_De_Nacimiento = datos[5],
                            Nota = datos[6]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return perros;
        }

        public PantallaEdicion()
        {
            InitializeComponent();
        }

        public class Perro
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Raza { get; set; }
            public string Dueño { get; set; }
            public string Telefono { get; set; }
            public string Fecha_De_Nacimiento { get; set; }
            public string Nota { get; set; }
        }



        public void CargarDatos(WindowsFormsApp2.Listar.Perro perroListar)
        {
            var perroPantallaEdicion = new Perro
            {
                ID = perroListar.ID,
                Nombre = perroListar.Nombre,
                Raza = perroListar.Raza,
                Dueño = perroListar.Dueño,
                Telefono = perroListar.Telefono,
                Fecha_De_Nacimiento = perroListar.Fecha_De_Nacimiento,
                Nota = perroListar.Nota
            };

            label4.Text = $"ID:        {perroPantallaEdicion.ID}";
            textBox1.Text = perroPantallaEdicion.Nombre;
            textBox4.Text = perroPantallaEdicion.Raza;
            textBox2.Text = perroPantallaEdicion.Dueño;
            textBox5.Text = perroPantallaEdicion.Telefono;
            richTextBox1.Text = perroPantallaEdicion.Nota;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label4.Text.Split(':')[1].Trim()); 

            List<Perro> perros = CargarPerrosDesdeArchivo();

            Perro perro = perros.FirstOrDefault(p => p.ID == id);

            if (perro != null)
            {
                perros.Remove(perro);
                GuardarPerrosEnArchivo(perros);
                MessageBox.Show("Perro eliminado con éxito.");
            }
            else
            {
                MessageBox.Show("Perro no encontrado.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label4.Text.Split(':')[1].Trim()); 
            string nuevoNombre = textBox1.Text;
            string nuevaRaza = textBox4.Text;
            string nuevoDueño = textBox2.Text;
            string nuevoTelefono = textBox5.Text;
            string nuevaFechaNacimiento = richTextBox1.Text;
            string nuevaNota = richTextBox1.Text;

            List<Perro> perros = CargarPerrosDesdeArchivo();

            Perro perro = perros.FirstOrDefault(p => p.ID == id);

            if (perro != null)
            {
                perro.Nombre = string.IsNullOrWhiteSpace(nuevoNombre) ? perro.Nombre : nuevoNombre;
                perro.Raza = string.IsNullOrWhiteSpace(nuevaRaza) ? perro.Raza : nuevaRaza;
                perro.Dueño = string.IsNullOrWhiteSpace(nuevoDueño) ? perro.Dueño : nuevoDueño;
                perro.Telefono = string.IsNullOrWhiteSpace(nuevoTelefono) ? perro.Telefono : nuevoTelefono;
                perro.Nota = string.IsNullOrWhiteSpace(nuevaNota) ? perro.Nota : nuevaNota;

                GuardarPerrosEnArchivo(perros);

                MessageBox.Show("Datos del perro actualizados con éxito.");
            }
            else
            {
                MessageBox.Show("Perro no encontrado.");
            }
        }

        private void GuardarPerrosEnArchivo(List<Perro> perros)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("perros.txt", false)) 
                {
                    foreach (var perro in perros)
                    {
                        writer.WriteLine($"{perro.ID},{perro.Nombre},{perro.Raza},{perro.Dueño},{perro.Telefono},{perro.Fecha_De_Nacimiento},{perro.Nota}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
