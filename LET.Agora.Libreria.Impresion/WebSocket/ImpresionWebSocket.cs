using LET.Agora.Libreria.Impresion.Models;
using LET.Agora.Libreria.Impresion.Repositories;
using System.Text.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace LET.Agora.Libreria.Impresion.WebSocket
{
    public class ImpresionWebSocket : WebSocketBehavior
    {
        private readonly IImpresionService _printService;

        public ImpresionWebSocket(IImpresionService printService)
        {
            _printService = printService;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var factura = JsonSerializer.Deserialize<FacturaResponse>(e.Data);

                response = _printService.ImprimirFactura(factura);

            }
            catch (Exception ex)
            {

                response.Exito = false;
                response.Mensaje = ex.Message;
            }

            var serializeResponse = JsonSerializer.Serialize(response);

            Send(serializeResponse);

        }
    }
}
