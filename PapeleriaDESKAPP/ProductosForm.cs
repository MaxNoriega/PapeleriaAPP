using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapeleriaDESKAPP
{
    public partial class ProductosForm : Form
    {
        private readonly HttpClient _httpClient;
        public ProductosForm()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://apipapeleria.azurewebsites.net/") }; //
        }

        private async void AddProductBtn_Click(object sender, EventArgs e)
        {
            string idProducto = txtIDproducto.Text.Trim();
            string nombre = txtNombreproducto.Text.Trim();
            string descripcion = txtDescProducto.Text.Trim();
            string precioTexto = txtPrecioproducto.Text.Trim();
            string stockTexto = txtProductoStock.Text.Trim();

            if (string.IsNullOrEmpty(idProducto) || string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(precioTexto) || string.IsNullOrEmpty(stockTexto))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convertir precio y stock
            if (!decimal.TryParse(precioTexto, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(stockTexto, out int stock))
            {
                MessageBox.Show("El stock debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear objeto Producto
            var producto = new Producto
            {
                IdProducto = idProducto,
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock
            };

            // Llamar al método para enviar datos a la API
            bool resultado = await AgregarProductoAsync(producto);

            if (resultado)
            {
                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar el producto. Revisa los datos o el estado del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> AgregarProductoAsync(Producto producto)
        {
            try
            {
                string json = JsonConvert.SerializeObject(producto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Productoes", content); // Cambia 'Productos' por el endpoint correcto
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LimpiarCampos()
        {
            txtIDproducto.Clear();
            txtNombreproducto.Clear();
            txtPrecioproducto.Clear();
            txtPrecioproducto.Clear();
            txtProductoStock.Clear();
            txtDescProducto.Clear();
        }


        public class Producto
        {
            public string IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
        }



        private void BackBtn_Click(object sender, EventArgs e)
        {
            Menu menuForm = new Menu();

            // Mostrar el formulario Menú
            menuForm.Show();

            // Ocultar el formulario actual
            this.Hide();

        }
    }
}
