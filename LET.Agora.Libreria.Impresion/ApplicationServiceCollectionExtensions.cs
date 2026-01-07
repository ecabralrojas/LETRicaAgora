using LET.Agora.Libreria.Impresion.Repositories;
using LET.Agora.Libreria.Impresion.SocketUrl;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace LET.Agora.Libreria.Impresion
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, string socketUrl)
        {
            services.AddSingleton<IImpresionService, ImpresionService>();
            services.AddSingleton<ISocketUrlFactory>(new SocketUrlFactory(
                socketUrl));
            return services;
        }
    }
}
