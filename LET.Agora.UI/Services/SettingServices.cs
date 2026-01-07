using LET.Agora.UI.Models;

namespace LET.Agora.UI.Services;

public class SettingServices : ISettingServices
{
    private readonly string _apiUrl, _serie, _posId, _locatioName, _saleCenterId, _token, _apiUrlServer;

    public SettingServices(string apiUrl,
                           string serie,
                           string posId,
                           string saleCenterId,
                           string locationName,
                           string token,
                           string apiUrlServer)
    {
        _apiUrl = apiUrl;
        _serie = serie;
        _posId = posId;
        _saleCenterId = saleCenterId;
        _locatioName = locationName;
        _token = token;
        _apiUrlServer = apiUrlServer;
    }

    public AgoraSetting CreateAgoraSetting()
    {
        var setting = new AgoraSetting
        {
            ApiUrl = _apiUrl,
            ApiUrlServer = _apiUrlServer,
            Serie = _serie,
            PosId = _posId,
            SaleCenterId = _saleCenterId,
            LocatioName = _locatioName,
            Token = _token              

        };

        return setting;
    }
}
