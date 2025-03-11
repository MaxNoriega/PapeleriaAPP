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
using System.Net.Http.Json;

namespace PapeleriaDESKAPP
{
    public partial class VentaForm : Form
    {
        private readonly HttpClient _httpClient;
        public VentaForm()
        {
            InitializeComponent();
            ListaProductos.KeyDown += ListaProductos_KeyDown;
            _httpClient = new HttpClient { BaseAddress = new Uri("https://apipapeleria.azurewebsites.net/") }; //
        }
        public static class DatosVenta
        {
            public static List<Productos> ListaProdTicket { get; set; } = new List<Productos>();
        }




        //Agregar Producto
        private async void txtBuscarProdVenta_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si se presionó Enter
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;  // Indica que manejaste el evento
                e.SuppressKeyPress = true;  // Evita el sonido de "ding"

                string idProducto = txtBuscarProdVenta.Text.Trim();

                if (string.IsNullOrEmpty(idProducto))
                {
                    MessageBox.Show("Por favor, ingresa un ID de producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el producto por ID
                var producto = await ObtenerProductoPorIdAsync(idProducto);
                if (producto != null)
                {
                    if (producto.Stock > 0)
                    {
                        // Calcular puntos generados
                        decimal puntosGenerados = producto.Precio / 10;

                        // Mostrar datos en el DataGridView ListaProductos
                        ListaProductos.Rows.Add(producto.IdProducto, producto.Nombre, producto.Precio, puntosGenerados);

                        // Reducir el stock del producto en la API
                        producto.Stock -= 1;
                        bool actualizado = await ActualizarProductoAsync(producto);

                        // Actualizar los totales
                        ActualizarTotales();

                        //if (actualizado)
                        //{
                        //    MessageBox.Show("Producto agregado y stock actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("El producto se agregó a la lista, pero no se pudo actualizar el stock.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}

                        // Limpiar el TextBox después de agregar el producto
                        txtBuscarProdVenta.Clear();
                    }
                    else
                    {
                        MessageBox.Show("El producto no tiene stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado. Verifica el ID ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscarProdVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter es un número o una tecla especial permitida (ej. Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter no permitido
            }
            // Limitar a 10 caracteres
            if (txtBuscarProdVenta.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea caracteres adicionales
            }

        }
        private async Task<bool> ActualizarProductoAsync(Producto producto)
        {
            try
            {
                var jsonProducto = JsonConvert.SerializeObject(producto);
                var content = new StringContent(jsonProducto, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"api/Productoes/{producto.IdProducto}", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private async Task<Producto> ObtenerProductoPorIdAsync(string IdProducto)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Productoes/{IdProducto}"); // Cambia el endpoint según tu API

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Producto>(json);
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void PrepararProductosVenta()
        {
            DatosVenta.ListaProdTicket.Clear();

            foreach (DataGridViewRow fila in ListaProductos.Rows)
            {
                if (fila.Cells["IdProducto"].Value != null) // Verifica que la fila no esté vacía
                {
                    DatosVenta.ListaProdTicket.Add(new Productos
                    {
                        IdProducto = fila.Cells["IdProducto"].Value.ToString(),
                        Nombre = fila.Cells["Nombre_Producto_Venta"].Value.ToString(),
                        Precio = Convert.ToDecimal(fila.Cells["Precio_Producto_Venta"].Value)
                    });
                }
            }
        }





        //Eliminar Producto de la lista
        private async void ListaProductos_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si se presionó la tecla Suprimir (Delete)
            if (e.KeyCode == Keys.Delete)
            {
                // Verifica si se seleccionó alguna fila
                if (ListaProductos.SelectedRows.Count > 0)
                {
                    string idProducto = ListaProductos.SelectedRows[0].Cells[0].Value.ToString(); // Columna 0 = IdProducto
                    string nombreProducto = ListaProductos.SelectedRows[0].Cells["Nombre_Producto_Venta"].Value.ToString();

                    // Pregunta al usuario si está seguro de eliminar el producto
                    var confirmResult = MessageBox.Show($"¿Estás seguro de eliminar el producto '{nombreProducto}'?",
                        "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Elimina la fila del DataGridView
                        ListaProductos.Rows.RemoveAt(ListaProductos.SelectedRows[0].Index);

                        // Recupera el producto desde la API por su nombre
                        var producto = await ObtenerProductoPorNombreAsync(nombreProducto);

                        if (producto != null)
                        {
                            // Restaura el stock en la API
                            producto.Stock += 1;
                            bool actualizado = await ActualizarProductoAsync(producto);

                            // Actualizar los totales después de la eliminación
                            ActualizarTotales();

                            //if (actualizado)
                            //{
                            //    MessageBox.Show("Producto eliminado y stock actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            //else
                            //{
                            //    MessageBox.Show("No se pudo actualizar el stock en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                        }
                    }
                }

            }
        }
        private async Task<Producto> ObtenerProductoPorNombreAsync(string nombreProducto)
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Productoes"); // Ajusta el endpoint si es necesario

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var productos = JsonConvert.DeserializeObject<List<Producto>>(json);

                    return productos.FirstOrDefault(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void ActualizarTotales()
        {
            decimal totalPrecio = 0;
            decimal totalPuntos = 0;

            foreach (DataGridViewRow fila in ListaProductos.Rows)
            {
                // Asegúrate de convertir correctamente los valores
                if (fila.Cells["Precio_Producto_Venta"].Value != null && decimal.TryParse(fila.Cells["Precio_Producto_Venta"].Value.ToString(), out decimal precio))
                {
                    totalPrecio += precio;
                }

                if (fila.Cells["PtosGen_Producto_Venta"].Value != null && decimal.TryParse(fila.Cells["PtosGen_Producto_Venta"].Value.ToString(), out decimal puntos))
                {
                    totalPuntos += puntos;
                }
            }

            // Actualiza los TextBox
            txtCostoTotal.Text = totalPrecio.ToString("0.00");
            txtPtosGenerados.Text = totalPuntos.ToString("0.00");
        }










        //PAGAR
        private void PagarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Datos básicos de la venta
                int idCliente = int.Parse(txtNumCtrlVenta.Text);
                float totalVenta = float.Parse(txtCostoTotal.Text);
                int puntosGen = ConvertirPuntosGenerados(txtPtosGenerados.Text);
                // Generar un identificador único para la venta
                var idVenta = Guid.NewGuid().GetHashCode(); // Genera un ID numérico único
                PrepararProductosVenta();
                // Prepara los datos de la venta para TransferenciaForm
                var metodoPagoForm = new MetodoPagoForm
                {
                    IDVenta = idVenta,
                    IdCliente = idCliente,          // Pasa el IdCliente al formulario
                    TotalVenta = totalVenta,       // Crea una nueva propiedad para recibir TotalVenta
                    ProductosVenta = DatosVenta.ListaProdTicket, // Envía los productos
                    PuntosGenerados = puntosGen   // Nueva propiedad para recibir los puntos generados
                };
                metodoPagoForm.Show();





            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int ConvertirPuntosGenerados(string puntosGeneradosText)
        {
            try
            {
                // Intentar convertir a float y redondear
                float puntosGenerados = float.Parse(puntosGeneradosText);
                return Convert.ToInt32(Math.Round(puntosGenerados));
            }
            catch (FormatException)
            {
                // Manejo de error si el formato no es válido
                MessageBox.Show("El valor de los puntos generados no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; // Retorna 0 en caso de error
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                MessageBox.Show($"Error al convertir los puntos generados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0; // Retorna 0 en caso de error
            }
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
    public class Producto
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }

    public class Productos
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }



}
