using LET.Agora.UI.Application.Models;

namespace LET.Agora.UI.Application.Services;

public class SettingServices : ISettingServices
{
    private readonly string _apiUrl, _serie, _nombreId;
    private readonly int _posId;

    public SettingServices(string apiUrl, string serie, int posId, string nombreId)
    {
        _apiUrl = apiUrl;
        _serie = serie;
        _posId = posId;
        _nombreId = nombreId;
    }

    public AgoraSetting CreateAgoraSetting()
    {
        var setting = new AgoraSetting
        {
            ApiUrl = _apiUrl,
            Serie = _serie,
            PosId = _posId,
            NombreId = _nombreId
        };

        return setting;
    }
}
