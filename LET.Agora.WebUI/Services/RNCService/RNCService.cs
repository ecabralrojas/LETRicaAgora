using LET.Agora.WebUI.Models;
using System.Net.Http.Json;

namespace LET.Agora.WebUI.Services.RNCService
{
    public class RNCService : IRNCService
    {
        private readonly HttpClient _http;
        public RNCService(HttpClient http)
        {
            _http = http;
        }


        public async Task<ServiceResponse<RNCDGII>> ObtenerRNC(string RNCContribuyente)
        {
            var resultado = await _http.GetFromJsonAsync<ServiceResponse<RNCDGII>>($"api/facturas/ObtenerRNC/{RNCContribuyente}");
            return resultado;
        }
    }
}
