using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapeleriaDESKAPP
{
    public partial class Efectivo : Form
    {
        public List<Productos> ProductosVenta { get; set; } = new List<Productos>();
        public int IdCliente { get; set; }
        public float TotalVenta { get; set; }

        public int IDVenta { get; set; }
        public int IDC { get; set; }

        public int PuntosGenerados { get; set; } // Nueva propiedad

        private readonly HttpClient _httpClient;
        public Efectivo()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://apipapeleria.azurewebsites.net/") }; //
            this.Load += TransferenciaForm_Load; // Suscripción al evento Load
        }


        private async void TransferenciaForm_Load(object sender, EventArgs e)
        {
            // Asegúrate de que TotalVenta tenga un valor válido
            txtCobro.Text = TotalVenta > 0 ? TotalVenta.ToString("F2") : "0.00";

            // Cargar los puntos del cliente si IdCliente es válido
            if (IdCliente > 0)
            {
                await CargarPuntosCliente(IdCliente);
            }
            else
            {
                MessageBox.Show("ID del cliente no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async Task CargarPuntosCliente(int idCliente)
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Clientes/externos");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var clientes = JsonConvert.DeserializeObject<List<ClienteExterno>>(responseContent);

                    var cliente = clientes.FirstOrDefault(c => c.numero_Control == idCliente);

                    if (cliente != null)
                    {
                        Ptstxt.Text = cliente.puntos_Acumulados.ToString();
                        IDC = cliente.idCliente; // Asignar el ID al formulario o alguna variable
                    }
                    else
                    {
                        MessageBox.Show($"Cliente con número de control {idCliente} no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Error al cargar los datos del cliente: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los puntos del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PtsUsartxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores actuales
                int saldoPuntos = int.Parse(Ptstxt.Text); // Puntos disponibles
                float cobroOriginal = float.Parse(txtCobro.Tag?.ToString() ?? txtCobro.Text); // Monto original almacenado en Tag
                int puntosAUsar = string.IsNullOrEmpty(PtsUsartxt.Text) ? 0 : int.Parse(PtsUsartxt.Text); // Puntos a usar

                // Guardar el monto original en Tag la primera vez
                if (txtCobro.Tag == null)
                {
                    txtCobro.Tag = cobroOriginal;
                }

                // Validar que los puntos a usar no excedan el saldo de puntos
                if (puntosAUsar > saldoPuntos)
                {
                    MessageBox.Show("No puedes usar más puntos de los que tienes disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PtsUsartxt.Text = saldoPuntos.ToString(); // Limitar a los puntos disponibles
                    PtsUsartxt.SelectionStart = PtsUsartxt.Text.Length; // Mantener el cursor al final del texto
                    puntosAUsar = saldoPuntos; // Ajustar el valor
                }

                // Calcular el nuevo total
                float nuevoCobro = cobroOriginal - puntosAUsar;

                // Actualizar el txtCobro con el nuevo total
                txtCobro.Text = nuevoCobro >= 0 ? nuevoCobro.ToString("F2") : "0.00"; // Asegurar que no sea negativo
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores válidos para los puntos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PtsUsartxt.Text = "0"; // Resetear el valor del campo en caso de error
                PtsUsartxt.SelectionStart = PtsUsartxt.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al calcular el total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener el monto total a pagar
                float montoTotal = float.Parse(txtCobro.Text);

                // Obtener la cantidad pagada por el cliente
                float cantidadPagada = string.IsNullOrEmpty(txtPago.Text) ? 0 : float.Parse(txtPago.Text);

                // Validar si la cantidad pagada es suficiente
                if (cantidadPagada >= montoTotal)
                {
                    // Calcular y mostrar el cambio
                    float cambio = cantidadPagada - montoTotal;
                    txtCambio.Text = cambio.ToString("F2");
                }
                else
                {
                    // Si no alcanza, mostrar 0 en el cambio
                    txtCambio.Text = "0.00";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un valor válido en el campo de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPago.Text = "0"; // Restablecer el valor en caso de error
                txtPago.SelectionStart = txtPago.Text.Length;
                txtCambio.Text = "0.00"; // Resetear el cambio
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al calcular el cambio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCambio.Text = "0.00"; // Resetear el cambio en caso de error
            }
        }

        private string GenerarTicket()
        {
            // Encabezado del ticket
            string Ticket = $"No.Control: {IdCliente}\n" +
                            "Producto             |     Precio |     \n";

            // Concatenar la lista de productos formateada
            foreach (var producto in ProductosVenta)
            {
                Ticket += $"{producto.Nombre,-20} | {producto.Precio,10:0.00} | \n";
            }

            // Método de Pago
            string MetodoP = "Efectivo"; // Cambiar según el método usado, si es dinámico

            // Datos de la venta
            string Total = txtCobro.Text; // Total de la venta
            string Dinero = txtPago.Text; // Cantidad de dinero con la que pagó el cliente
            string Cambio = txtCambio.Text; // Cambio que se le dio al cliente
            string Puntos = string.IsNullOrWhiteSpace(PtsUsartxt.Text) ? "0" : PtsUsartxt.Text; // Puntos utilizados o 0 si no se usaron

            // Fecha actual
            string Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            // Agregar los detalles finales al ticket
            Ticket += 
                      $"Total: {Total}\n" +
                      $"Metodo_Pago: {MetodoP}\n" +
                      $"Dinero: {Dinero}\n" +
                      $"Cambio: {Cambio}\n" +
                      $"Puntos: {Puntos}\n" +
                      $"Fecha: {Fecha}";

            return Ticket;
        }

        private void GuardarTicketEnEscritorio()
        {
            try
            {
                // Generar el ticket
                string ticket = GenerarTicket();

                // Obtener la ruta del escritorio
                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Definir el nombre del archivo
                string nombreArchivo = $"Ticket_{IdCliente}_{DateTime.Now:yyyyMMddHHmmss}.txt";

                // Ruta completa del archivo
                string rutaArchivo = Path.Combine(rutaEscritorio, nombreArchivo);

                // Guardar el ticket en un archivo de texto
                File.WriteAllText(rutaArchivo, ticket);

                // Informar al usuario
                MessageBox.Show($"El ticket se ha guardado correctamente en:\n{rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnPagar_Click(object sender, EventArgs e)
        {
            GuardarTicketEnEscritorio();
        }

        // Clase que representa los datos de un cliente externo
        public class ClienteExterno
        {
            public int idCliente { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string email { get; set; }
            public string contrasena { get; set; }
            public int puntos_Acumulados { get; set; }
            public int numero_Control { get; set; }
        }

        public class Venta
        {
            public int idVenta { get; set; } // ID de la venta, generado de forma única
            public float total { get; set; } // Total de la venta
            public bool usarPuntos { get; set; } // Indica si se van a usar puntos en la venta
            public int puntosUsados { get; set; } // Cantidad de puntos usados en la venta
            public int numeroControl { get; set; } // Número de control del cliente
            public int idCliente { get; set; } // ID del cliente
        }

       
    }
}
