using LET.Agora.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LET.Agora.UI
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddSettings(this IServiceCollection services,
            string apiUrl,
            string serie,
            string posId,
            string saleCenterId,
            string locationName,
            string token,
            string apiUrlServer)
        {
            services.AddTransient<ISettingServices>(_=>
            new SettingServices(apiUrl, serie, posId, saleCenterId, locationName,token, apiUrlServer));
            return services;
        }

    }
}
