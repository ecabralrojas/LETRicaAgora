using LET.AgoraPantallaFormaPago.Services.ParametroService;

namespace LET.AgoraPantallaFormaPago.SocketService
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
