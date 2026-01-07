using LET.Agora.Application.Repositories;
using LET.Agora.Application.Services;
using LET.Agora.Database;
using Microsoft.Extensions.DependencyInjection;

namespace LET.Agora.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
         services.AddSingleton<IPaymentRepository, PaymentRepository>();
         services.AddSingleton<IPaymentService, PaymentService>();
         services.AddSingleton<ITicketRepository, TicketRepository>();
         services.AddSingleton<ITicketService, TicketService>();
         services.AddSingleton<ICustomerRepository, CustomerRepository>();
         services.AddSingleton<ICustomerService, CustomerService>();
         services.AddSingleton<IFacturaRepository, FacturaRepository>();
         services.AddSingleton<IFacturaService, FacturaService>();
         services.AddSingleton<IMonitorParametroRepository, MonitorParametroRepository>();
         services.AddSingleton<IMonitorParametroService, MonitorParametroService>();
         return services;    
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services,
          string connectionString, string agoraBaseApiAddress, string agoraToken)
    {
        services.AddSingleton<IDbConnectionFactory>(_ =>
            new MSqlDbConnectionFactory(connectionString, agoraBaseApiAddress, agoraToken));
        return services;
    }

}