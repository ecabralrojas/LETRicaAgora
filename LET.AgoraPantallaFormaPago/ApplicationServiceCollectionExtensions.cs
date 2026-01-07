using CurrieTechnologies.Razor.SweetAlert2;
using LET.AgoraPantallaFormaPago.JSInterop;
using LET.AgoraPantallaFormaPago.Models;
using LET.AgoraPantallaFormaPago.Services.ParametroService;
using LET.AgoraPantallaFormaPago.Services.TicketServices;
using LET.AgoraPantallaFormaPago.SocketService;
using MudBlazor.Services;
using System.Runtime.CompilerServices;

namespace LET.AgoraPantallaFormaPago
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, Parametro parametro)
        {
            services.AddScoped<IParametroPosService>(_ =>
                new ParametroPosService(parametro));

            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ISocketUrlService, SocketUrlService>();  
            services.AddScoped<TicketStateContainer>();
            services.AddScoped<PaymentStateContainer>();
            services.AddScoped<AgoraInterop>();
            services.AddMudServices();
            services.AddSweetAlert2();
            return services;
        }
    }
}
