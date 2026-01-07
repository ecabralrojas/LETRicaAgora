using LET.Agora.WebUI.Services.ParametroPosService;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LET.Agora.WebUI.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {

        private readonly IParametroPosService _parametroPosService;
        public CustomerService(IParametroPosService parametroPosService)
        {
            _parametroPosService = parametroPosService;
        }

        public async Task<ServiceResponse<bool>> ObtenerLimiteCredito(string codigoCLiente, string totalTransaccion)
        {
            var parametro = _parametroPosService.CreateAgoraParametro();
            var respuesta = new ServiceResponse<bool>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(parametro.ApiUrlServer!);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", parametro.Token);

                    var response = await client.GetFromJsonAsync<ServiceResponse<bool>>($"api/facturas/ObtenerLimiteCredito/{codigoCLiente}/{totalTransaccion}/{parametro.PosId}");
                    respuesta = response;


                }
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;

        }
    }
}
