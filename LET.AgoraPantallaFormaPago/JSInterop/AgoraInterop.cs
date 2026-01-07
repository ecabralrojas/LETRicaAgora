using Microsoft.JSInterop;

namespace LET.AgoraPantallaFormaPago.JSInterop
{
    public class AgoraInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public AgoraInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task CloseWindow(string applyFlow)
        {
            await _jsRuntime.InvokeVoidAsync("agoraInterop.closeWindow", applyFlow);
        }

        public async Task<T> InvokeApi<T>(string endpoint, string apiToken, object body = null, int timeout = 60000)
        {
            var args = new
            {
                endpoint,
                apiToken,
                body,
                timeout
            };

            return await _jsRuntime.InvokeAsync<T>("agoraInterop.invokeApi", args);
        }
    }
}
