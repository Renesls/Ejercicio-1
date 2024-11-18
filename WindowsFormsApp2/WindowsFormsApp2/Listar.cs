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
    public partial class Listar : UserControl


    {
        Form1 form1;
        private Panel panel7;



        private List<Perro> perros = new List<Perro>();

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
        public Listar(Panel panel)
        {
            InitializeComponent();
            CargarDatosPerros(); 
            ConfigurarComboBox(); 
            ActualizarDataGridView(perros);
            this.panel7 = panel;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);


        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtén el perro seleccionado
                var perroSeleccionado = perros[e.RowIndex];

                // Crea una nueva instancia de PantallaEdicion
                PantallaEdicion pantallaControl = new PantallaEdicion();

                // Agrega el control al panel si aún no está agregado
                if (!panel7.Controls.Contains(pantallaControl))
                {
                    panel7.Controls.Add(pantallaControl);
                    pantallaControl.Dock = DockStyle.Fill;
                    pantallaControl.BringToFront();
                }

                // Cargar los datos en los controles de PantallaEdicion
                pantallaControl.CargarDatos(perroSeleccionado);
            }
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void CargarDatosPerros()
        {
            if (File.Exists("perros.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader("perros.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split(',');
                            if (parts.Length == 7)
                            {
                                perros.Add(new Perro
                                {
                                    ID = int.Parse(parts[0]),
                                    Nombre = parts[1],
                                    Raza = parts[2],
                                    Dueño = parts[3],
                                    Telefono = parts[4],
                                    Fecha_De_Nacimiento = parts[5],
                                    Nota = parts[6]
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarComboBox()
        {

            comboBox2.SelectedIndex = 1; 
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string criterio = comboBox2.SelectedItem.ToString();
            string textoBusqueda = textBox6.Text.Trim();

            List<Perro> resultados = new List<Perro>();

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                foreach (var perro in perros)
                {
                    switch (criterio)
                    {
                        case "ID":
                            if (int.TryParse(textoBusqueda, out int idBusqueda) && perro.ID == idBusqueda)
                            {
                                resultados.Add(perro);
                            }
                            break;
                        case "Nombre":
                            if (perro.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                resultados.Add(perro);
                            }
                            break;
                        case "Dueño":
                            if (perro.Dueño.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                resultados.Add(perro);
                            }
                            break;
                    }
                }
            }
            else
            {
                resultados = perros;
            }

            ActualizarDataGridView(resultados);
        }

        private void ActualizarDataGridView(List<Perro> listaPerros)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ConvertirAListaVisual(listaPerros);
        }


        private List<Perro> ConvertirAListaVisual(List<Perro> listaPerros)
        {
            var listaVisual = new List<Perro>();
            foreach (var perro in listaPerros)
            {
                listaVisual.Add(new Perro
                {
                    ID = perro.ID,
                    Nombre = perro.Nombre,
                    Raza = perro.Raza,
                    Dueño = perro.Dueño,
                    Telefono = perro.Telefono,
                    Nota = perro.Nota,
                    Fecha_De_Nacimiento = perro.Fecha_De_Nacimiento
                });
            }
            return listaVisual;
        }

    }
}
