using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PapeleriaDESKAPP
{
    public partial class TransferenciaForm : Form
    {
        public List<Productos> ProductosVenta { get; set; } = new List<Productos>();
        public int IdCliente { get; set; }
        public float TotalVenta { get; set; }

        public int IDVenta { get; set; }

        public int IDC { get; set; }

        public int PuntosGenerados { get; set; } // Nueva propiedad


        private readonly HttpClient _httpClient;
        public TransferenciaForm()
        {
            
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://apipapeleria.azurewebsites.net/") }; //
            this.Load += TransferenciaForm_Load; // Suscripción al evento Load

        }

        private async void BtnEnviarTrans_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si el valor de txtCobro es un número válido
                double monto;
                if (!double.TryParse(txtCobro.Text, out monto))
                {
                    MessageBox.Show("El monto ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Termina la ejecución si el monto no es válido
                }

                // Obtener el valor de puntos usados (si corresponde)
                int puntosUsados = 0;
                if (!string.IsNullOrEmpty(PtsUsartxt.Text))
                {
                    int.TryParse(PtsUsartxt.Text, out puntosUsados); // Asignar puntos usados si están presentes
                }

                string cuentaOrigen = txtCuenta.Text;

                // Crear objeto de pago basado en los datos locales
                var pago = new Pagoes
                {
                    ctaOrig = cuentaOrigen, // Cuenta de origen del cliente
                    ctaDest = "8157285806626531", // Cuenta destino del comercio
                    monto = monto, // Monto total del pago, convertido a double
                    fecha = DateTime.Now, // Fecha actual
                    estado = "Pendiente" // Estado inicial del pago
                };

                // Serializar y enviar el pago
                var jsonPago = JsonConvert.SerializeObject(pago);
                var contentPago = new StringContent(jsonPago, Encoding.UTF8, "application/json");
                var responsePago = await _httpClient.PostAsync("/api/Pagoes", contentPago);

                if (responsePago.IsSuccessStatusCode)
                {
                    MessageBox.Show("Pago registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Realizar el movimiento de puntos (si se generaron o se usaron)

        //            MessageBox.Show(
        //$"IDC: {IDC}\n" +
        //$"IdCliente: {IdCliente}\n" +
        //$"Puntos Usados: {puntosUsados}\n" +
        //$"Puntos Generados: {PuntosGenerados}",
        //"Verificación de Datos",
        //MessageBoxButtons.OK,
        //MessageBoxIcon.Information);
                    if (puntosUsados > 0)
                    {
                        // Si hay puntos usados, restamos los puntos
                        await RestarPuntosAsync(IDC, IdCliente, puntosUsados);
                        await AgregarPuntosAsync(IDC, IdCliente, PuntosGenerados);
                    }
                    else
                    {
                        // Si no hay puntos usados, generamos puntos
                        
                        await AgregarPuntosAsync(IDC, IdCliente, PuntosGenerados);
                    }
                    var voucher = await ObtenerVoucherReciente(cuentaOrigen);

                    if (voucher != null)
                    {
                        // Mostrar los detalles del voucher
                        MessageBox.Show(
                            $"Transacción Exitosa\n" +
                            $"Estado: {voucher.Estado}\n" +
                            $"Número de Transacción: {voucher.Id}\n" +
                            $"Fecha: {voucher.FechaTransaccion}\n" +
                            $"Monto: {voucher.Monto:C}\n" +
                            $"Cuenta Origen: {voucher.CtaOrig}\n" +
                            $"Cuenta Destino: {voucher.CtaDest}",
                            "Información del Voucher",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Guardar el ticket si es necesario
                        GuardarTicketEnEscritorio();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un voucher para la cuenta origen especificada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                }
                else
                {
                    MessageBox.Show("Error al registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el pago y la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Voucher> ObtenerVoucherReciente(string cuentaOrigen)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // URL de la API del banco
                    string url = "https://apibancoappservice.azurewebsites.net/api/transacciones";

                    // Realizar la solicitud GET
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Asegurarse de que la respuesta fue exitosa
                    response.EnsureSuccessStatusCode();

                    // Leer la respuesta como string
                    string respuestaJson = await response.Content.ReadAsStringAsync();

                    // Deserializar la lista de transacciones
                    var transacciones = JsonConvert.DeserializeObject<List<Voucher>>(respuestaJson);

                    // Filtrar el voucher más reciente para la cuenta origen
                    var voucherReciente = transacciones
                        .Where(v => v.CtaOrig == cuentaOrigen && v.Estado == "Completada")
                        .OrderByDescending(v => DateTime.Parse(v.FechaTransaccion))
                        .FirstOrDefault();

                    return voucherReciente; // Retornar el voucher encontrado o null si no hay coincidencias
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el voucher: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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

        private async Task AgregarPuntosAsync(int IDC, int IdCliente, int PuntosGenerados)
        {
            int IdCliCTRL = IdCliente;
            string apiUrl = "https://proyectogestion.azurewebsites.net/api/Movimientos/Add";
            // Verificar si el valor de txtCobro es un número válido
            double monto;
            if (!double.TryParse(txtCobro.Text, out monto))
            {
                MessageBox.Show("El monto ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Termina la ejecución si el monto no es válido
            }
            var movimiento = new Movimiento

            {
                
                IdCliente = IDC,
                fecha_movimiento = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                tipoMov = "compra",
                ptosGdos = PuntosGenerados,
                descripcion = "Venta",
                numero_Control = IdCliCTRL
            };

            await EnviarMovimiento(apiUrl, movimiento);
        }

        private async Task RestarPuntosAsync(int IDC, int IdCliente, int puntosUsados)
        {
            int IdCliCTRL = IdCliente;
            string apiUrl = "https://proyectogestion.azurewebsites.net/api/Movimientos/Add";
            var movimiento = new Movimiento
            {
                
                IdCliente = IDC,
                fecha_movimiento = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                tipoMov = "uso_puntos",
                ptosGdos = puntosUsados,
                descripcion = "Venta con puntos",
                numero_Control = IdCliCTRL
            };

            await EnviarMovimiento(apiUrl, movimiento);
        }

        private async Task EnviarMovimiento(string apiUrl, Movimiento movimiento)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonMovimiento = JsonConvert.SerializeObject(movimiento);
                    var contenido = new StringContent(jsonMovimiento, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, contenido);

                    if (response.IsSuccessStatusCode)
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show($"Error al registrar el movimiento: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al enviar el movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            string MetodoP = "Tarjeta";

            // Cargar los datos de la última venta (asegúrate de que el método ya se haya llamado antes)
            string Total = txtCobro.Text;

            // Puntos
            string Puntos = string.IsNullOrWhiteSpace(PtsUsartxt.Text) ? "0" : PtsUsartxt.Text; // Puntos utilizados o 0 si no se usaron

            // Fecha actual
            string Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");


            // Agregar los detalles finales al ticket
            Ticket += "Total: " + Total + "\n" +
                      "Metodo_Pago: " + MetodoP + "\n" +
                      "Puntos: " + Puntos + "\n" +
                      "Tipo_Mov: Transferencia\n" +
                      "Fecha: " + Fecha;

            return Ticket;
        }
        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter es un número o una tecla especial permitida (ej. Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter no permitido
            }
        }


      

        private void BackBtn_Click(object sender, EventArgs e)
        {
            MetodoPagoForm metodPagoForm = new MetodoPagoForm();

            // Mostrar el formulario Menú
            metodPagoForm.Show();

            // Ocultar el formulario actual
            this.Hide();
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
    }



    public class Pagoes
    {
        public int idPago { get; set; } // Generado por la API
        public string ctaOrig { get; set; } // Cuenta del cliente (opcional)
        public string ctaDest { get; set; } // Cuenta destino del comercio
        public double monto { get; set; } // Monto total del pago
        public DateTime fecha { get; set; } // Fecha del pago
        public string estado { get; set; } // Estado del pago
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

    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdCliente { get; set; }
        public string fecha_movimiento { get; set; }
        public string tipoMov { get; set; }
        public int ptosGdos { get; set; }
        public string descripcion { get; set; }
        public int numero_Control { get; set; }
    }

    public class Voucher
    {
        public int Id { get; set; }
        public string CtaOrig { get; set; }
        public string CtaDest { get; set; }
        public decimal Monto { get; set; }
        public string FechaTransaccion { get; set; }
        public string TipoTransaccion { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Clave { get; set; }
    }

    public class ResultadoTransaccion
    {
        public Voucher voucher { get; set; }
        public string mensaje { get; set; }
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
