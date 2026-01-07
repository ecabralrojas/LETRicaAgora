using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace LET.Agora.WebUI.Services.SocketService
{
    public class ClientSocketConnection
    {
        private readonly ClientWebSocket websocket;
        private readonly Uri websocketUrl;

        public ClientSocketConnection(ClientWebSocket websocket, Uri websocketUrl)
        {
            this.websocket = websocket;
            this.websocketUrl = websocketUrl;
        }

        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            await websocket.ConnectAsync(websocketUrl, cancellationToken);
        }

        public Task SendStringAsync(string data, CancellationToken cancellation)
        {
            var encoded = Encoding.UTF8.GetBytes(data);
            var buffer = new ArraySegment<byte>(encoded, 0, encoded.Length);
            return websocket.SendAsync(buffer, WebSocketMessageType.Text, endOfMessage: true, cancellation);
        }

        public Task SendObjectAsync(object obj, CancellationToken cancellation)
        {
            string jsonData = JsonConvert.SerializeObject(obj);
            return SendStringAsync(jsonData, cancellation);
        }

        public async Task<ServiceResponse<T>> ReceiveResponseAsync<T>(CancellationToken cancellationToken)
        {
            var buffer = new ArraySegment<byte>(new byte[2048]);
            using var ms = new MemoryStream();
            WebSocketReceiveResult result;
            do
            {
                result = await websocket.ReceiveAsync(buffer, cancellationToken);
                ms.Write(buffer.Array, buffer.Offset, result.Count);
            } while (!result.EndOfMessage);

            ms.Seek(0, SeekOrigin.Begin);
            var jsonResponse = Encoding.UTF8.GetString(ms.ToArray());
            return JsonConvert.DeserializeObject<ServiceResponse<T>>(jsonResponse);
        }

        public async Task<ServiceResponse<T>> SendAndReceiveAsync<T>(object obj, CancellationToken cancellationToken)
        {
            await SendObjectAsync(obj, cancellationToken);
            return await ReceiveResponseAsync<T>(cancellationToken);
        }
    }
}
