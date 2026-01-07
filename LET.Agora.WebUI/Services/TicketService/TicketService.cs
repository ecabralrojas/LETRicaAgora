using LET.Agora.WebUI.Models;
using System.Net.Http.Json;
using LET.Agora.WebUI.Services.ParametroPosService;

namespace LET.Agora.WebUI.Services.TicketService;

public class TicketService : ITicketService
{
    private readonly HttpClient _http;
    private readonly IParametroPosService _parametroPosService;

    public TicketService(HttpClient http, IParametroPosService parametroPosService)
    {
        _http = http;
        _parametroPosService = parametroPosService;
    }


    public async Task<ServiceResponse<TicketAbiertoContainer>> ObtenerTicketAbierto()
    {
        var parametro = _parametroPosService.CreateAgoraParametro();
        var response = await _http.GetFromJsonAsync<ServiceResponse<TicketAbiertoContainer>>($"api/facturas/ObtenerTicketAbiertos/{parametro.SaleCenterId}/{parametro.LocationName}");
        return response;
    }

}
