using LET.Agora.WebUI.Models;
using System.Net.Http.Json;

namespace LET.Agora.WebUI.Services.FormaPagoService;

public class FormaPagoService : IFormaPagoService
{
    private readonly HttpClient _http;

    public FormaPagoService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ServiceResponse<PaymentMethodContainer>> ObtenerFormasDePagos()
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<PaymentMethodContainer>>("api/facturas/ObtenerFormaPagos");
        return response;
    }

    public async Task<ServiceResponse<Ticket>> RegistrarTicketPagos(AddPayment payment)
    {
        var resultado = await _http.PostAsJsonAsync("api/facturas/RegistrarFormaPagoAgora", payment);
        var ticket = await resultado.Content.ReadFromJsonAsync<ServiceResponse<Ticket>>();
        return ticket;

    }

}
