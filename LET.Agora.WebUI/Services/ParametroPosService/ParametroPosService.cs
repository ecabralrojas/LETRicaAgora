using LET.Agora.WebUI.Models;

namespace LET.Agora.WebUI.Services.ParametroPosService
{
    public class ParametroPosService : IParametroPosService
    {
        private readonly string _apiUrl, _serie, _posId, _locatioName, _saleCenterId, _token, _apiUrlServer, _socketUrl;

        public ParametroPosService(string apiUrl,
                               string serie,
                               string posId,
                               string saleCenterId,
                               string locationName,
                               string token,
                               string apiUrlServer,
                               string socketUrl)
        {
            _apiUrl = apiUrl;
            _serie = serie;
            _posId = posId;
            _saleCenterId = saleCenterId;
            _locatioName = locationName;
            _token = token;
            _apiUrlServer = apiUrlServer;
            _socketUrl = socketUrl; 
        }

        public Parametro CreateAgoraParametro()
        {
            var parametro = new Parametro
            {
                ApiUrl = _apiUrl,
                ApiUrlServer = _apiUrlServer,
                Serie = _serie,
                PosId = _posId,
                SaleCenterId = _saleCenterId,
                LocationName = _locatioName,
                Token = _token,
                SocketUrl = _socketUrl  

            };

            return parametro;
        }
    }
}
