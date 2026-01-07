using LET.Agora.WebUI.Models;
using System.Net.Http.Json;

namespace LET.Agora.WebUI.Services.FacturaService
{
    public class FacturaService : IFacturaService
    {
        private readonly HttpClient _http;

        public FacturaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(Ticket ticket, string rncContribuyente, int tipocomprobante)
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

