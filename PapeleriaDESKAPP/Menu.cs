using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapeleriaDESKAPP
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void UsuariosBtn_Click(object sender, EventArgs e)
        {
          

        }

        private void VentasBtn_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Menú
            VentaForm ventasForm = new VentaForm();

            // Mostrar el formulario Menú
            ventasForm.Show();

            // Ocultar el formulario actual
            this.Hide();

        }

        private void ProductosBtn_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario Menú
            ProductosForm productosForm = new ProductosForm();

            // Mostrar el formulario Menú
            productosForm.Show();

            // Ocultar el formulario actual
            this.Hide();

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
    }
}
