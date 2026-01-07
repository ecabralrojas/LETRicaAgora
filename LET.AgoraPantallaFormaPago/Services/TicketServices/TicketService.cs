using LET.AgoraPantallaFormaPago.ModeloFactura;
using LET.AgoraPantallaFormaPago.Models;
using LET.AgoraPantallaFormaPago.Services.ParametroService;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static LET.AgoraPantallaFormaPago.Pages.ComprobantesFiscales;
using static System.Net.WebRequestMethods;

namespace LET.AgoraPantallaFormaPago.Services.TicketServices
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _http;
        private readonly IParametroPosService _parametroPos;

        public TicketService(HttpClient http, IParametroPosService parametroPos)
        {
            _http = http;
            _parametroPos = parametroPos; 
        }
        public async Task<ServiceResponse<TicketResponse>> GetOpenTickets()
        {
            var param = _parametroPos.CreateAgoraParametro();
            var response = await _http.GetFromJsonAsync<ServiceResponse<TicketResponse>>(
                $"api/facturas/ObtenerTicketAbiertos/{param.SaleCenterId}/{param.LocationName}");
            return response;
        }
        public async Task<ServiceResponse<bool>> ObtenerLimiteCreditoCliente(string customerCode, decimal amount)
        {
            var param = _parametroPos.CreateAgoraParametro();
            var response = new ServiceResponse<bool>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(param.ApiUrlServer!);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", param.Token);
                    response = await client.GetFromJsonAsync<ServiceResponse<bool>>(
                        $"/api/facturas/ObtenerLimiteCredito/{customerCode}/{amount}/{param.PosId}");
                }

            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.Mensaje = ex.Message;                  
            }

            return response;

        }
        public async Task<ServiceResponse<PaymentMethodsResponse>> GetPaymentMethods()
        {
            return await _http.GetFromJsonAsync<ServiceResponse<PaymentMethodsResponse>>(
                "api/facturas/ObtenerFormaPagos");
        }
        public async Task<ServiceResponse<IEnumerable<NCFSecuencia>>> ObtenerComprobantesFiscales()
        {
            var param = _parametroPos.CreateAgoraParametro();
            return await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<NCFSecuencia>>>(
                $"api/facturas/ObtenerComprobantesFiscales/{param.Serie}");
        }
        public async Task<ServiceResponse<RncDgii>> ObtenerRNC(string rnc)
        {
            return await _http.GetFromJsonAsync<ServiceResponse<RncDgii>>(
                $"api/facturas/ObtenerRNC/{rnc}");
        }
        public async Task<ServiceResponse<TicketAgora>> RegistrarFormaPagoAgora(AddPayment payment)
        {
            try
            {
                var resultado = await _http.PostAsJsonAsync("api/facturas/RegistrarFormaPagoAgora", payment);
                var ticket = await resultado.Content.ReadFromJsonAsync<ServiceResponse<TicketAgora>>();
                return ticket;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(TicketAgora ticket, string rncContribuyente, int tipocomprobante)
        {
            var factura = new ServiceResponse<FacturaAgora>();

            try
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<FacturaAgora>>($"api/facturas/ObtenerFacturaAgora/{ticket.Serie}/{ticket.Number}");

                if (response.Exito = true)
                {
                    factura = new ServiceResponse<FacturaAgora>
                    {
                        Data = new FacturaAgora
                        {
                            factura = response.Data.factura,
                            FacturaDetalles = response.Data.FacturaDetalles,
                            facturaDetalleAddins = response.Data.facturaDetalleAddins,
                            facturaFormaPagos = response.Data.facturaFormaPagos,
                            rnc = rncContribuyente,
                            TipoComprobante = tipocomprobante
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                factura.Exito = false;
                factura.Mensaje = ex.Message;
            }

            return factura;

        }
        public async Task<ServiceResponse<FacturaResponse>> RegistrarFacturaAgora(FacturaAgora facturaAgora)
        {
            var responseResult = new ServiceResponse<FacturaResponse>();

            try
            {
                var response = await _http.PostAsJsonAsync("api/facturas/RegistrarFacturaAgora", facturaAgora);
                responseResult = await response.Content.ReadFromJsonAsync<ServiceResponse<FacturaResponse>>();
            }
            catch (Exception ex)
            {
                responseResult.Exito = false;
                responseResult.Mensaje = ex.Message;
            }

            return responseResult;
        }

    }
}
