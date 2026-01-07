using LET.Agora.UI.Models;
using LET.Agora.UI.Services;
using LET.Agora.UI.UserControls;
using LET.Agora.UI.Utilidades;
using Newtonsoft.Json;


namespace LET.Agora.UI
{
    public partial class frmPantallaComprobante : Form
    {
        private readonly ISettingServices _settingServices;
        public event Action<ComprobanteSeleccionadoEventArgs> OnComprobanteSeleccionado;
       
        public frmPantallaComprobante(ISettingServices settingServices)
        {
            _settingServices = settingServices;
            InitializeComponent();
            InitializeNumericButton();

        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            int index = Array.IndexOf(Buttons, sender);
            string textbutton = Buttons[index].Text;
            if (textbutton.Length > 0)
            {
                txtRNC.AppendText(textbutton);
            }

        }
        private async void CargarComprobantesFiscalesAsync()
        {
            var setting = _settingServices.CreateAgoraSetting();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(setting.ApiUrl);

                using (var response = await client.GetAsync($"api/facturas/ObtenerComprobantesFiscales/{setting.Serie}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonComprobante = await response.Content.ReadAsStringAsync();
                        var comprobantes = JsonConvert.DeserializeObject<ServiceResponse<IEnumerable<NCFSecuencia>>>(jsonComprobante);
                        LlenarListViewComprobantes(comprobantes);
                    }
                    else
                    {
                        MessageBox.Show($"NO SE PUDIERON OBTENER LOS COMPROBANTES FISCALES {response.StatusCode}");
                    }
                }
            }
        }

        private async void BuscarRNCAsync()
        {
            var setting = _settingServices.CreateAgoraSetting();

            if (ValidarRNC(txtRNC.Text))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(setting.ApiUrl);

                    using (var response = await client.GetAsync($"api/facturas/ObtenerRNC/{txtRNC.Text}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonResponse = await response.Content.ReadAsStringAsync();
                            var datosdgii = JsonConvert.DeserializeObject<ServiceResponse<RNCDGII>>(jsonResponse);

                            if (datosdgii.Data != null)
                            {
                                lblMensaje.Text = string.Empty;
                                txtRazonSocial.Text = datosdgii.Data.RazonSocial;
                                txtRNC.Text = datosdgii.Data.rnc;
                            }
                            else
                            {
                                lblMensaje.Text = "EL RNC NO EXISTE DEBE DE CREARLO";
                            }

                        }
                        else
                        {
                            MessageBox.Show($"NO SE PUDIERON OBTENER EL RNC {response.StatusCode}");
                        }
                    }
                }

            }

        }

        private bool ValidarRNC(string rnc)
        {
            bool esValido = false;
            if (string.IsNullOrEmpty(txtRNC.Text))
            {
                lblMensaje.Text = "RNC INVALIDO / POR FAVOR VERIFICAR";
                return esValido = false;
            }

            if ((txtRNC.Text.Length == 9 || txtRNC.Text.Length == 11))
            {
                if (txtRNC.Text.Length == 9)
                {
                    if (Utilidad.ValidaRNC(txtRNC.Text.Trim()))
                    {
                        esValido = true;
                    }
                    else
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "RNC INVALIDO / POR FAVOR VERIFICAR";
                        //btnProcesar.Enabled = true;
                        esValido = false;
                    }
                }
                else if (txtRNC.Text.Length == 11)
                {
                    if (Utilidad.ValidarCedula(txtRNC.Text.Trim()))
                    {
                        esValido = true;
                    }
                    else
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "CEDULA INVALIDA / POR FAVOR VERIFICAR";
                        //btnProcesar.Enabled = true;
                        esValido = false;
                    }
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "DIGITE EL RNC CORRECTAMENTE";
                //btnProcesar.Enabled = true;
                esValido = false;
            }

            return esValido;
        }

        private void LlenarListViewComprobantes(ServiceResponse<IEnumerable<NCFSecuencia>> comprobantes)
        {
            foreach (var comprobante in comprobantes.Data)
            {
                var item = new ListViewItem(comprobante.Tipo.ToString());
                item.SubItems.Add(comprobante.Descripcion);
                item.SubItems.Add(comprobante.NCFPrefix);
                item.SubItems.Add(comprobante.NCFSecuenciaInicial.ToString());
                item.SubItems.Add(comprobante.NCFSecuenciaFinal.ToString());
                item.SubItems.Add(comprobante.NCFFechaVencimiento.ToString());
                item.SubItems.Add(comprobante.NCFSecuenciaActual.ToString());
                item.SubItems.Add(comprobante.Serie);
                item.SubItems.Add(comprobante.AvisoComprobantes);
                item.SubItems.Add(comprobante.TieneDisponible.ToString());
                item.SubItems.Add(comprobante.MensajeComprobantes);
                item.SubItems.Add(comprobante.AvisoVencimiento);
                item.SubItems.Add(comprobante.TienenVencimiento.ToString());
                item.Tag = comprobante;
                lvComprobantes.Items.Add(item);
            }
        }

        private void frmPantallaComprobante_Load(object sender, EventArgs e)
        {

            CargarComprobantesFiscalesAsync();
        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {


        }

        private void btnBuscarRNC_Click(object sender, EventArgs e)
        {
            BuscarRNCAsync();
        }

        private void lvComprobantes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (lvComprobantes.SelectedItems.Count > 0)
            {
                var selectedItem = lvComprobantes.SelectedItems[0].Tag as NCFSecuencia;
                if (selectedItem != null)
                {
                    // Create event args with selected comprobante and textbox values
                    var eventArgs = new ComprobanteSeleccionadoEventArgs
                    {
                        Comprobante = selectedItem,
                        RNC = txtRNC.Text,
                        RazonSocial = txtRazonSocial.Text
                    };

                    // Trigger the event
                    OnComprobanteSeleccionado?.Invoke(eventArgs);

                    // Close the form after selection
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                CustomMessageBox.Show($"\"Por favor seleccione un comprobante antes de aceptar.\"", "Warning", CustomMessageBox.MessageType.Warning);                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            

        }
    }
}
