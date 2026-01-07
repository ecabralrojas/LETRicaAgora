using PosClient.Models;

namespace PosClient.Services;

public class AgoraSettingService : IAgoraSettingService
{
    private readonly AgoraSetting _agoraSetting;
    public AgoraSettingService(AgoraSetting agoraSetting)
    {
        _agoraSetting = agoraSetting;
    }

    public AgoraSetting CreateAgoraSetting()
    {
        var setting = new AgoraSetting
        {
            ApiUrl = _agoraSetting.ApiUrl,
            ApiUrlServer = _agoraSetting.ApiUrlServer,
            Serie = _agoraSetting.Serie,
            PosId = _agoraSetting.PosId,
            SaleCenterId = _agoraSetting.SaleCenterId,
            LocatioName = _agoraSetting.LocatioName,
            Token = _agoraSetting.Token
        };

        return setting;
    }
}
