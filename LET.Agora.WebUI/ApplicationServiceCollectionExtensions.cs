using LET.Agora.WebUI.Models;
using LET.Agora.WebUI.Services;
using LET.Agora.WebUI.Services.ParametroPosService;

namespace LET.Agora.WebUI
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,
        string apiUrl,
        string serie,
        string posId,
        string saleCenterId,
        string locationName,
        string token,
        string apiUrlServer,
        string socketUrl)
            {
            services.AddScoped<IParametroPosService>(_ =>
            new ParametroPosService(apiUrl, serie, posId, saleCenterId, locationName, token, apiUrlServer, socketUrl));
            return services;
        }

    }
}
