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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Acceder_Click(object sender, EventArgs e)
        {

            //    if (cn.conSQL(txt_Usuario.Text, txt_Contrasena.Text) == 1)
            //    {
            //        MessageBox.Show("El Usuario ha sido encontrado")
            //    }
            //    else
            //    {
            //        MessageBox.Show("El usuario no ha sido encontrado")
            //    }

            // Crear una instancia del formulario Menú
            Menu menuForm = new Menu();

            // Mostrar el formulario Menú
            menuForm.Show();

            // Ocultar el formulario actual
            this.Hide();

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
