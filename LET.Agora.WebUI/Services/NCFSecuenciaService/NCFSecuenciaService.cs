using LET.Agora.WebUI.Models;
using System.Net.Http.Json;
using LET.Agora.WebUI.Services.ParametroPosService;

namespace LET.Agora.WebUI.Services.NCFSecuenciaService;

public class NCFSecuenciaService : INCFSecuenciaService
{
    private readonly HttpClient _http;
    private readonly IParametroPosService _parametroPosService;

    public NCFSecuenciaService(HttpClient http, IParametroPosService parametroPosService)
    {
        _http = http;
        _parametroPosService = parametroPosService;
    }


    public async Task<ServiceResponse<IEnumerable<NCFSecuencia>>> ObtenerComprobanteFiscales()
    {
        var parametro = _parametroPosService.CreateAgoraParametro();
        var response = await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<NCFSecuencia>>>($"api/facturas/ObtenerComprobantesFiscales/{parametro.Serie}");
        return response;
    }

}
