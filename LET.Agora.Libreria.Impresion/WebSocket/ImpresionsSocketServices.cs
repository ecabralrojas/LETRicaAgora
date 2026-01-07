using LET.Agora.Libreria.Impresion.Repositories;
using LET.Agora.Libreria.Impresion.SocketUrl;
using WebSocketSharp.Server;

namespace LET.Agora.Libreria.Impresion.WebSocket
{
    public class ImpresionsSocketServices
    {
        private WebSocketServer? _webSocketServer;
        private readonly IImpresionService _impresionService;
        private readonly ISocketUrlFactory _socketUrlFactory;


        public ImpresionsSocketServices(IImpresionService impresionService, ISocketUrlFactory socketUrlFactory)
        {
            _impresionService = impresionService;  
            _socketUrlFactory = socketUrlFactory;
        }

        public void Start()
        {
            _webSocketServer = new WebSocketServer($"ws://{_socketUrlFactory.SocketUrl()}");
            _webSocketServer.AddWebSocketService("/servicioimpresion", () =>
                        new ImpresionWebSocket(_impresionService));
            _webSocketServer.Start();
        }

        public void Stop()
        {
            _webSocketServer!.Stop();
        }
    }
}
