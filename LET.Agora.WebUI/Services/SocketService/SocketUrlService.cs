using LET.Agora.WebUI.Services.ParametroPosService;
using static System.Net.WebRequestMethods;

namespace LET.Agora.WebUI.Services.SocketService
{
    public class SocketUrlService : ISocketUrlService
    {
        private readonly IParametroPosService _parametroPosService;
        public SocketUrlService(IParametroPosService parametroPosService)
        {
            _parametroPosService = parametroPosService;
        }

        public string ObtenerSocketUrl()
        {
            var parametro = _parametroPosService.CreateAgoraParametro();
            return parametro.SocketUrl;
        }

    }
}
