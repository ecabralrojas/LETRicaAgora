using LET.Agora.UI.Models;
using LET.Agora.UI.Services;
using LET.Agora.UI.UserControls;
using Newtonsoft.Json;


namespace LET.Agora.UI
{
    public partial class frmFormaPago : Form
    {
       

        private UCFormaPago ucFormaPago;
        private UCTicketAbiertos ucTicketAbiertos;
        private readonly ISettingServices _settingServices;
        public event Action<List<TicketAbierto>>? TicketListed;
        public event Action<TicketAbierto>? TicketSelected;

        public frmFormaPago(ISettingServices settingServices)
        {
            _settingServices = settingServices;
             InitializeComponent();

            ucFormaPago = new UCFormaPago(settingServices);
            ucTicketAbiertos = new UCTicketAbiertos(settingServices);

            // Wire up the event
            ucTicketAbiertos.TicketSelected += OnTicketSelected;
            //ucFormaPago.OnTicketAbierto += OnCallControl;


            // Add default user control
            //addUserControl(ucTicketAbiertos);
           
        }

  
        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private async void OnTickeListed(ServiceResponse<TicketAbierto> ticketAbierto)
        {
           await ucTicketAbiertos.CargarTicketAbierto();
        }


        private void LlamarControlUCFormaPago(TicketAbierto ticketabiertos)
        {
            if (ticketabiertos != null)
            {
                TicketSelected?.Invoke(ticketabiertos);
            }
        }

        private async Task CargarTicketAbierto()
        {
            var setting = _settingServices.CreateAgoraSetting();

            bool esMayorDeDos = false;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(setting.ApiUrl);

                    
                    using (var response = await client.GetAsync($"api/facturas/ObtenerTicketAbiertos/{setting.SaleCenterId}/{setting.LocatioName}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var bodyResponse = await response.Content.ReadAsStringAsync();
                            var tickets = JsonConvert.DeserializeObject<ServiceResponse<TicketAbiertoContainer>>(bodyResponse);

                            if (tickets.Data.Tickets.Count() > 1)
                            {
                                OnCallControlTicketAbierto();
                            }
                            else if (tickets.Data.Tickets.Count() == 1)
                            {
                                OnTicketSelected(tickets.Data.Tickets.FirstOrDefault());

                            }
                            else
                            {
                                CustomMessageBox.Show($"NO HAY TICKETS PARA FACTURAR", "Warning", CustomMessageBox.MessageType.Warning);
                                Application.Exit();

                            }

                        }
                        else
                        {
                            CustomMessageBox.Show($"NO SE PUDO CARGAR APLICACION DE PAGOS {response.StatusCode}", "Warning", CustomMessageBox.MessageType.Warning);
                            
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //CustomMessageBox.Show($"{ex.Message}", "Error", CustomMessageBox.MessageType.Error);

            }           
        }

        

        private void OnTicketSelected(TicketAbierto selectedTicket)
        {
            // Pass data to UCFormaPago
            ucFormaPago.SetTicketData(selectedTicket);

            // Switch to UCFormaPago
            addUserControl(ucFormaPago);
        }



        private void OnCallControlTicketAbierto()
        {
            addUserControl(ucTicketAbiertos);
        }


        private void OnCallControl()
        {
            addUserControl(ucTicketAbiertos);
        }
        private async void frmFormaPago_Load(object sender, EventArgs e)
        {
            await CargarTicketAbierto();
        }

    }
}
    