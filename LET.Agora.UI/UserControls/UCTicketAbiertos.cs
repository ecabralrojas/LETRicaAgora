using LET.Agora.UI.Models;
using LET.Agora.UI.Services;
using Newtonsoft.Json;

namespace LET.Agora.UI.UserControls
{
    public partial class UCTicketAbiertos : UserControl
    {
        private readonly ISettingServices _settingServices;

        public event Action<TicketAbierto>? TicketSelected;


        public UCTicketAbiertos(ISettingServices settingServices)
        {
            _settingServices = settingServices;
            InitializeComponent();
        }
        public async Task CargarTicketAbierto()
        {
            var setting = _settingServices.CreateAgoraSetting();

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
                            LlenarListViewTicketAbiertos(tickets);
                        }
                        else
                        {
                            Console.WriteLine(response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }
        public void LlenarListViewTicketAbiertos(ServiceResponse<TicketAbiertoContainer> ticketabiertos)
        {
            listViewTicketAbierto.Items.Clear();

            foreach (var ticket in ticketabiertos.Data.Tickets)
            {
                var item = new ListViewItem(ticket.GlobalId);
                item.SubItems.Add(ticket.BusinessDay);
                item.SubItems.Add(ticket.User.Id.ToString());
                item.SubItems.Add(ticket.Pos.Id.ToString());
                item.SubItems.Add(ticket.Pos.Name);
                item.SubItems.Add(ticket.User.Name);
                item.SubItems.Add(ticket.Totals.GrossAmount.ToString());
                item.Tag = ticket;
                listViewTicketAbierto.Items.Add(item);

            }

        }
        private async void UCTicketAbiertos_Load(object sender, EventArgs e)
        {
            await CargarTicketAbierto();
        }
        private void listViewTicketAbierto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTicketAbierto.SelectedItems.Count > 0)
            {
                var selecteditem = (TicketAbierto)listViewTicketAbierto.SelectedItems[0].Tag;

                if (selecteditem != null)
                {
                    TicketSelected?.Invoke(selecteditem);
                }
            }
        }

        private void LlamarControlUCFormaPago(TicketAbierto ticketabiertos)
        {
            if (ticketabiertos != null)
            {
                TicketSelected?.Invoke(ticketabiertos);
            } 
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
           listViewTicketAbierto.Items.Clear();    
           await CargarTicketAbierto();
        }
    }
}
