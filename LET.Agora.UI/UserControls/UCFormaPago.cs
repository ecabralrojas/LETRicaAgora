using LET.Agora.UI.Models;
using LET.Agora.UI.Services;
using System.Text;
using System.Globalization;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LET.Agora.UI.UserControls
{
    public partial class UCFormaPago : UserControl
    {
        private NCFSecuencia? nCFSecuencia { get; set; }
        public event Action OnTicketAbierto;

        private readonly ISettingServices _settingServices;
        private TicketAbierto? TicketAbierto { get; set; }
        private bool EsEmpleado = false;
        public UCFormaPago(ISettingServices settingServices)
        {
            _settingServices = settingServices;
            InitializeComponent();
            InitializeNumericButton();
        }


        public async void SetTicketData(TicketAbierto ticket)
        {
            // Process the received ticket data
            TicketAbierto = ticket;
            var idCliente = await ObtenderIdClienteTicketAbierto(ticket.GlobalId);

            if (idCliente.Data != 0)
            {
                var cliente = await ObtenerCliente(idCliente.Data);
                lblCodigoCliente.Text = cliente.Data.CustomerCode;
                lblCliente.Text = cliente.Data.FiscalName;
            }

            TotalInicial(ticket);
        }

        private void ResetearControles()
        {
            var culture = new CultureInfo("en-US");
            listViewFormaPago.Items.Clear();
            lblCodigoCliente.Text = string.Empty;
            lblCliente.Text = string.Empty;
            lblRNCTipo.Text = string.Empty;
            lblDescripcionComprobante.Text = string.Empty;
            lblRNC.Text = string.Empty;
            lblRazonSocial.Text = string.Empty;
            lblMontoPendiente.Text = 0.00.ToString("C", culture);
            lblMontoEntregado.Text = 0.00.ToString("C", culture);
            lblMontoCambio.Text = 0.00.ToString("C", culture);
            lblMontoTotal.Text = 0.00.ToString("C", culture);
            btnCobrar.Enabled = true;

        }

        public void SetComprobanteFiscal(NCFSecuencia ncf)
        {
            nCFSecuencia = ncf;
        }

        string URI = "";

        private void btnVolver_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnCobrar_Click(object sender, EventArgs e)
        {
            if (!ValidaSiTieneTipoComprobanteFiscal())
            {
                CustomMessageBox.Show($"DEBE ELEGIR EL TIPO DE COMPROBANTE FISCAL", "Warning", CustomMessageBox.MessageType.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(lblCodigoCliente.Text))
            {
                bool limiteCredito = await LimiteCredito();

                if (limiteCredito == false)
                {
                    return;
                }
            }

            EnviarFormasDePago();
        }

        private bool ValidaSiTieneTipoComprobanteFiscal()
        {
            return !string.IsNullOrEmpty(lblRNCTipo.Text);
        }

        private async void EnviarFormasDePago()
        {
            List<AddPayment> payments = MapListViewToAddPaymentList(listViewFormaPago);

            foreach (var payment in payments)
            {
                await RegistrarFormaPagoAgora(payment);
            }

            Application.Exit();

        }
        private async Task RegistrarFormaPagoAgora(AddPayment payment)
        {
            var setting = _settingServices.CreateAgoraSetting();
            var ticket = new ServiceResponse<Ticket>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(setting.ApiUrl);

                var jsonContent = JsonConvert.SerializeObject(payment);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("api/facturas/RegistrarFormaPagoAgora", httpContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseContent = await responseMessage.Content.ReadAsStringAsync();
                    ticket = JsonConvert.DeserializeObject<ServiceResponse<Ticket>>(responseContent);

                    if (ticket.Exito == true)
                    {
                        if (ticket.Data != null)
                        {
                            await ObtenerFacturaAgora(ticket.Data);
                        }
                    }
                    else
                    {
                        CustomMessageBox.Show($"{ticket.Mensaje}", "Error", CustomMessageBox.MessageType.Error);
                    }
                }
                else
                {
                    CustomMessageBox.Show($"Error Al Enviar {responseMessage.StatusCode}", "Error", CustomMessageBox.MessageType.Error);
                }
            }
        }
        private async Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(Ticket ticket)
        {
            var response = new ServiceResponse<FacturaAgora>();

            var setting = _settingServices.CreateAgoraSetting();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(setting.ApiUrl);
                    using (var respuesta = await client.GetAsync($"api/facturas/ObtenerFacturaAgora/{ticket.Serie}/{ticket.Number}"))
                    {
                        if (respuesta.IsSuccessStatusCode)
                        {
                            var bodyResponse = await respuesta.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<ServiceResponse<FacturaAgora>>(bodyResponse);

                            if (response.Exito = true)
                            {

                                var factura = new FacturaAgora
                                {
                                    factura = response.Data.factura,
                                    FacturaDetalles = response.Data.FacturaDetalles,
                                    facturaDetalleAddins = response.Data.facturaDetalleAddins,
                                    facturaFormaPagos = response.Data.facturaFormaPagos,
                                    rnc = lblRNC.Text,
                                    TipoComprobante = Convert.ToInt32(lblRNCTipo.Text)
                                };

                                RegistrarFacturaAgora(factura);
                            }
                            else
                            {
                                CustomMessageBox.Show($"Error {response.Mensaje}", "Error", CustomMessageBox.MessageType.Error);
                            }
                        }
                        else
                        {
                            CustomMessageBox.Show($"Error {respuesta.StatusCode}", "Error", CustomMessageBox.MessageType.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
                response.Exito = false;
            }

            return response;
        }
        private async void RegistrarFacturaAgora(FacturaAgora facturaAgora)
        {
            var setting = _settingServices.CreateAgoraSetting();
            var factura = new ServiceResponse<bool>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(setting.ApiUrl);

                var jsonContent = JsonConvert.SerializeObject(facturaAgora);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("api/facturas/RegistrarFacturaAgora", httpContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseContent = await responseMessage.Content.ReadAsStringAsync();
                    factura = JsonConvert.DeserializeObject<ServiceResponse<bool>>(responseContent);

                    if (factura.Exito == false)
                    {
                        CustomMessageBox.Show($"Error {factura.Mensaje}", "Error", CustomMessageBox.MessageType.Error);
                    }
                    else
                    {
                        lblVentaFactura.Text = $"ULTIMA VENTA: {facturaAgora.factura.Serie} - {facturaAgora.factura.Numero}";
                        lblVentaImporte.Text = $"IMPORTE: {lblMontoTotal.Text}";
                        lblVentaEntregada.Text = $"ENTREGADO: {lblMontoEntregado.Text}";
                        lblVentaCambio.Text = $"CAMBIO: {lblMontoCambio.Text}";
                        ResetearControles();

                    }

                }
                else
                {
                    CustomMessageBox.Show($"Error {responseMessage.StatusCode}", "Error", CustomMessageBox.MessageType.Error);

                }
            }
        }
        private AddPayment MapToAddPayment(ListViewItem item)
        {
            return new AddPayment
            {
                TicketGlobalId = item.Text, // The main text of the ListViewItem
                PosId = int.Parse(item.SubItems[1].Text),
                UserId = int.Parse(item.SubItems[2].Text),
                Date = item.SubItems[3].Text,
                PaymentMethodId = int.Parse(item.SubItems[4].Text),
                Amount = decimal.Parse(item.SubItems[5].Text),
                PaidAmount = decimal.Parse(item.SubItems[6].Text),
                ChangeAmount = decimal.Parse(item.SubItems[7].Text),
                TipAmount = decimal.Parse(item.SubItems[8].Text),
                KeepOpen = bool.Parse(item.SubItems[9].Text),
                ExtraInformation = item.SubItems[10].Text
            };


        }
        private List<AddPayment> MapListViewToAddPaymentList(ListView listViewFormaPago)
        {
            var payments = new List<AddPayment>();

            foreach (ListViewItem item in listViewFormaPago.Items)
            {
                payments.Add(MapToAddPayment(item));
            }

            return payments;
        }
        private async Task<bool> LimiteCredito()
        {
            CultureInfo culture = new CultureInfo("en-US");
            decimal montoTotal = 0;


            if (decimal.TryParse(lblMontoTotal.Text, NumberStyles.Currency, culture, out decimal outputmontoTotal))
            {
                montoTotal = outputmontoTotal;
            }

            var resuesta = await ObtenerLimiteCredito(lblCodigoCliente.Text, montoTotal.ToString());

            if (resuesta.Exito != true)
            {
                CustomMessageBox.Show($"{resuesta.Mensaje}", "Error", CustomMessageBox.MessageType.Error);
            }

            return resuesta.Exito;
        }
        private AddPayment AsignarFormaPago(TicketAbierto ticket, EnvioPago envioPago)
        {
            return new AddPayment
            {
                TicketGlobalId = ticket.GlobalId,
                PosId = ticket.Pos.Id,
                UserId = ticket.User.Id,
                Date = ticket.BusinessDay,
                PaymentMethodId = envioPago.PaymentMethodId,
                Amount = envioPago.Amount,
                PaidAmount = envioPago.PaidAmount,
                ChangeAmount = envioPago.ChangeAmount,
                TipAmount = 0.00m,
                KeepOpen = false,
                ExtraInformation = ""
            };
        }
        private EnvioPago AsignarPago(int paymentMethodId,
                                      decimal amount,
                                      decimal payAmount,
                                      decimal changeAmount,
                                      string descripcion)
        {
            return new EnvioPago
            {
                PaymentMethodId = paymentMethodId,
                Amount = amount,
                PaidAmount = payAmount,
                ChangeAmount = changeAmount,
                Descripcion = descripcion
            };
        }
        public void AgregarBotonEfectivo()
        {


            Button btn = new Button();
            btn.Size = new Size(78, 67);
            btn.Text = "Efectivo";
            //btn.Tag = "1";

            btn.Tag = new PaymentMethod
            {
                Id = 1,
                Name = "Efectivo",
                GiveChange = true,
                IncludeInBalance = false,
                IncludeTipInBalance = false,
                IsValidForSale = true,
                IsValidForPurchase = true,
                OpenCashDrawer = true,
                RegisterTip = false,
                AllowOverPaid = true,
                AllowExtraInformation = false,
                ButtonText = "#00000",
                Color = "#00000",
                ExtractTipFromCashdrawer = false,
                Priority = 0,
                RequireCustomer = false,
                MaxAllowedPayment = null,
                IsValidForPhoneOrder = false,
                IsRefundVoucher = false,
                IsValidForRefund = false,
                DeletionDate = null

            };

            btn.Click += bnt_Click;
            flowLayoutPanelPagos.Controls.Add(btn);

        }

        private void bnt_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var metodoPago = (PaymentMethod)btn.Tag;
            AgregarFormaPagoListview(TicketAbierto, metodoPago, btn.Text);
        }
        private void AgregarFormaPagoListview(TicketAbierto ticket, PaymentMethod paymentMethod, string descripcion)
        {
            decimal montoEntregado = 0, montoPendiente = 0, totalEntregado = 0, montoCambio = 0, montoTotal = 0, totalPendiente = 0;

            CultureInfo culture = new CultureInfo("en-US");


            if (decimal.TryParse(lblMontoPendiente.Text, NumberStyles.Currency, culture, out decimal resultadoMontoPendiente))
            {
                montoPendiente = resultadoMontoPendiente;
            }

            if (decimal.TryParse(txtEntregado.Text, NumberStyles.Currency, culture, out decimal resultadoMontoEntregado))
            {
                montoEntregado = resultadoMontoEntregado;

                if (montoEntregado < 0)
                {
                    lblMensaje.Text = "El valor debe ser positivo";
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtEntregado.Text) && montoEntregado == 0)
            {
                montoEntregado = montoPendiente;
            }

            if (decimal.TryParse(lblMontoCambio.Text, NumberStyles.Currency, culture, out decimal resultadoMontoCambio))
            {
                montoCambio = resultadoMontoCambio;
            }

            if (montoPendiente == 0)
            {
                lblMensaje.Text = "No hace falta añadir mas formas de pagos";
                return;
            }

            if (paymentMethod.GiveChange &&
                paymentMethod.AllowOverPaid)
            {
                if (montoEntregado > montoPendiente)
                {
                    montoCambio = montoEntregado - montoPendiente;
                    lblMontoCambio.Text = montoCambio.ToString("C", culture);
                    montoPendiente = 0;
                }
            }
            else if (
                  paymentMethod.GiveChange == false &&
                  paymentMethod.AllowOverPaid == false)
            {
                if (montoEntregado > montoPendiente)
                {
                    lblMensaje.Text = $"No se puede pagar una cantidad superior al total de {descripcion}";
                    return;
                }
            }


            montoTotal = montoEntregado - montoCambio;

            var enviopago = AsignarPago(paymentMethod.Id, montoTotal, montoEntregado, montoCambio, descripcion);

            var payment = AsignarFormaPago(ticket, enviopago);
            var item = new ListViewItem(payment.TicketGlobalId);
            item.SubItems.Add(payment.PosId.ToString());
            item.SubItems.Add(payment.UserId.ToString());
            item.SubItems.Add(payment.Date);
            item.SubItems.Add(payment.PaymentMethodId.ToString());
            item.SubItems.Add(payment.Amount.ToString());
            item.SubItems.Add(payment.PaidAmount.ToString());
            item.SubItems.Add(payment.ChangeAmount.ToString());
            item.SubItems.Add(payment.TipAmount.ToString());
            item.SubItems.Add(payment.KeepOpen.ToString());
            item.SubItems.Add(payment.ExtraInformation);
            item.SubItems.Add(enviopago.Descripcion);
            item.SubItems.Add(payment.PaidAmount.ToString());
            item.SubItems.Add("X");
            item.Tag = payment;
            listViewFormaPago.Items.Add(item);

            //totalPendiente = montoPendiente - montoEntregado;
            RefreshListView();

            //if (montoEntregado > montoPendiente)
            //{
            //    totalPendiente = 0;
            //}
            //else
            //{
            //    totalPendiente = montoPendiente - montoEntregado;
            //}

            ////RefreshListView();

            //foreach (ListViewItem lvitem in listViewFormaPago.Items)
            //{
            //    if (decimal.TryParse(lvitem.SubItems[6].Text, out decimal paidAmount))
            //    {
            //        totalEntregado += paidAmount;
            //    }
            //}

            //lblMontoEntregado.Text = totalEntregado.ToString("C", culture);
            //lblMontoPendiente.Text = totalPendiente.ToString("C", culture);
            txtEntregado.Text = string.Empty;
            btnCobrar.Enabled = true;
        }
        private void RefreshListView()
        {
            decimal totalEntregado = 0;
            decimal totalPendiente = 0;
            CultureInfo culture = new CultureInfo("en-US");

            // Sumar los pagos realizados en la lista
            foreach (ListViewItem item in listViewFormaPago.Items)
            {
                if (decimal.TryParse(item.SubItems[6].Text, NumberStyles.Currency, culture, out decimal paidAmount))
                {
                    totalEntregado += paidAmount;
                }
            }

            // Obtener el monto total de la venta
            if (decimal.TryParse(lblMontoTotal.Text, NumberStyles.Currency, culture, out decimal montoTotal))
            {
                totalPendiente = montoTotal - totalEntregado;
                if (totalPendiente < 0) totalPendiente = 0; // Evitar negativos
            }

            // Si no hay elementos en la lista, resetear el monto de cambio
            if (listViewFormaPago.Items.Count == 0)
            {
                lblMontoCambio.Text = 0.ToString("C", culture);
                btnCobrar.Enabled = false;
            }

            // Actualizar los labels
            lblMontoEntregado.Text = totalEntregado.ToString("C", culture);
            lblMontoPendiente.Text = totalPendiente.ToString("C", culture);
        }
        private void TotalInicial(TicketAbierto ticket)
        {
            var culture = new CultureInfo("en-US");
            lblVentaFactura.Text = string.Empty;
            lblVentaImporte.Text = string.Empty;
            lblVentaEntregada.Text = string.Empty;
            lblVentaCambio.Text = string.Empty;
            lblMontoPendiente.Text = ticket.Totals.GrossAmount.ToString("C", culture);
            lblMontoTotal.Text = ticket.Totals.GrossAmount.ToString("C", culture);
        }
        private async void CargarFormasDePago()
        {

            var setting = _settingServices.CreateAgoraSetting();

            URI = setting.ApiUrl;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URI);
                    using (var response = await client.GetAsync("api/facturas/ObtenerFormaPagos"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var bodyResponse = await response.Content.ReadAsStringAsync();
                            var datos = JsonConvert.DeserializeObject<ServiceResponse<PaymentMethodContainer>>(bodyResponse);
                            if (datos.Exito == true)
                            {
                                BotonesFormaPago(datos);
                            }
                            else
                            {
                                CustomMessageBox.Show($"Error al cargar formas de pagos {datos.Mensaje}", "Error", CustomMessageBox.MessageType.Error);
                            }
                        }
                        else
                        {
                            CustomMessageBox.Show($"Error al cargar formas de pagos {response.StatusCode}", "Error", CustomMessageBox.MessageType.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error al obtener el id cliente {ex.Message}", "Error", CustomMessageBox.MessageType.Error);
            }
        }
        private void BotonesFormaPago(ServiceResponse<PaymentMethodContainer> formapagos)
        {
            AgregarBotonEfectivo();

            foreach (var pago in formapagos.Data.PaymentMethods)
            {
                Button btn = new Button();
                btn.Size = new Size(78, 67);
                btn.Text = pago.ButtonText;
                //btn.Tag = pago.Id;
                btn.Tag = pago;
                btn.Click += bnt_Click;
                flowLayoutPanelPagos.Controls.Add(btn);
            }
        }
        private void Buttons_Click(object sender, EventArgs e)
        {
            int index = Array.IndexOf(Buttons, sender);
            string textbutton = Buttons[index].Text;
            if (textbutton.Length > 0)
            {
                txtEntregado.AppendText(textbutton);
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEntregado?.Clear();
        }
        private void UCFormaPago_Load(object sender, EventArgs e)
        {
            CargarFormasDePago();
            btnCobrar.Enabled = false;

        }
        private async Task<ServiceResponse<int>> ObtenderIdClienteTicketAbierto(string globalId)
        {
            var response = new ServiceResponse<int>();

            var setting = _settingServices.CreateAgoraSetting();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(setting.ApiUrl);
                    using (var respuesta = await client.GetAsync($"api/facturas/ObtenerIdClienteTicketAbierto/{globalId}"))
                    {
                        if (respuesta.IsSuccessStatusCode)
                        {
                            var bodyResponse = await respuesta.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<ServiceResponse<int>>(bodyResponse);

                        }
                        else
                        {
                            CustomMessageBox.Show($"Error al obtener el idel cliente {respuesta.StatusCode}", "Error", CustomMessageBox.MessageType.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error {ex.Message}", "Error", CustomMessageBox.MessageType.Error);
                response.Mensaje = ex.Message;
                response.Exito = false;
            }

            return response;
        }
        private async Task<ServiceResponse<bool>> ObtenerLimiteCredito(string codigoCLiente, string totalTransaccion)
        {
            var response = new ServiceResponse<bool>();

            var setting = _settingServices.CreateAgoraSetting();
            string idCaja = setting.PosId;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(setting.ApiUrlServer);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", setting.Token);
                    using (var respuesta = await client.GetAsync($"api/facturas/ObtenerLimiteCredito/{codigoCLiente}/{totalTransaccion}/{idCaja}"))
                    {
                        if (respuesta.IsSuccessStatusCode)
                        {
                            var bodyResponse = await respuesta.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<ServiceResponse<bool>>(bodyResponse);

                            if (response.Exito == false)
                            {
                                CustomMessageBox.Show($"Error {response.Mensaje}", "Error", CustomMessageBox.MessageType.Error);
                            }
                        }
                        else
                        {
                            CustomMessageBox.Show($"Error {respuesta.StatusCode}", "Error", CustomMessageBox.MessageType.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error {ex.Message}", "Error", CustomMessageBox.MessageType.Error);
                response.Mensaje = ex.Message;
                response.Exito = false;
            }

            return response;
        }
        private async Task<ServiceResponse<Customer>> ObtenerCliente(int id)
        {
            var response = new ServiceResponse<Customer>();

            var setting = _settingServices.CreateAgoraSetting();


            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(setting.ApiUrl);
                    using (var respuesta = await client.GetAsync($"api/facturas/ObtenerCliente/{id}"))
                    {
                        if (respuesta.IsSuccessStatusCode)
                        {
                            var bodyResponse = await respuesta.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<ServiceResponse<Customer>>(bodyResponse);

                            if (response.Exito == false)
                            {
                                CustomMessageBox.Show($"Error {response.Mensaje}", "Error", CustomMessageBox.MessageType.Error);
                            }
                        }
                        else
                        {
                            CustomMessageBox.Show($"Error {respuesta.StatusCode}", "Error", CustomMessageBox.MessageType.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Error {ex.Message}", "Error", CustomMessageBox.MessageType.Error);
                response.Exito = false;
            }

            return response;
        }
        private void btnComprobantes_Click(object sender, EventArgs e)
        {
            var pantalla = new frmPantallaComprobante(_settingServices);

            // Subscribe to the event
            pantalla.OnComprobanteSeleccionado += ProcesarComprobanteSeleccionado;

            if (pantalla.ShowDialog() == DialogResult.OK)
            {
                // Form closed after successful selection
            }
        }
        private void ProcesarComprobanteSeleccionado(ComprobanteSeleccionadoEventArgs eventArgs)
        {
            // Retrieve data from event args
            var comprobante = eventArgs.Comprobante;
            var rnc = eventArgs.RNC;
            var razonSocial = eventArgs.RazonSocial;

            lblRNCTipo.Text = comprobante.Tipo.ToString();
            lblRazonSocial.Text = razonSocial;
            lblRNC.Text = rnc;
            lblDescripcionComprobante.Text = comprobante.Descripcion;
            // Display or use the received data
            //lblComprobanteInfo.Text = $"Tipo: {comprobante.Tipo}, Serie: {comprobante.Serie}";
            //lblClienteInfo.Text = $"RNC: {rnc}, Razón Social: {razonSocial}";

            //Console.WriteLine($"Comprobante seleccionado: {comprobante.Tipo} - {comprobante.Descripcion}");
            //Console.WriteLine($"RNC: {rnc}, Razón Social: {razonSocial}");
        }
        private void listViewFormaPago_MouseClick(object sender, MouseEventArgs e)
        {
            var hitTest = listViewFormaPago.HitTest(e.Location);
            if (hitTest.Item != null && hitTest.SubItem != null)
            {
                int columnIndex = hitTest.Item.SubItems.IndexOf(hitTest.SubItem);

                // Assuming "Remove" is the last column, adjust index as needed
                if (columnIndex == listViewFormaPago.Columns.Count - 1)
                {
                    listViewFormaPago.Items.Remove(hitTest.Item);
                    RefreshListView();
                }
            }
        }

        private void btnTicketAbierto_Click(object sender, EventArgs e)
        {
            
            OnTicketAbierto.Invoke();
        }
    }
}
