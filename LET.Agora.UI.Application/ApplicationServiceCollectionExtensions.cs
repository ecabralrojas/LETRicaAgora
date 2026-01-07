using LET.Agora.UI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LET.Agora.UI.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddSettings(this IServiceCollection services,
            string apiUrl,
            string serie,
            int posId,
            string nombreId)
        {
            services.AddTransient<ISettingServices>(_=>
            new SettingServices(apiUrl, serie, posId, nombreId));
            return services;
        }

    }
}
