using Microsoft.Extensions.DependencyInjection;
using PosClient.Models;
using PosClient.Services;

namespace PosClient;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services, 
        AgoraSetting agoraSetting)
    {
        services.AddTransient<FrmPantallaCobro>();
        services.AddTransient<IAgoraSettingService>(_ =>
        new AgoraSettingService(agoraSetting));

        return services;
    }
}
