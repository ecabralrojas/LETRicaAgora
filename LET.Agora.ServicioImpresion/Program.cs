using Microsoft.Extensions.Hosting;
using LET.Agora.Libreria.Impresion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace LET.Agora.ServicioImpresion
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                Directory.SetCurrentDirectory(AppContext.BaseDirectory);

                var host = Host.CreateDefaultBuilder(args)
                     .ConfigureAppConfiguration((context, config) =>
                     {
                         config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                     })
                     .ConfigureServices((hostContext, services) =>
                      {
                          var socketUrl = hostContext.Configuration["socketUrl"];

                          services.AddApplication(socketUrl);
                         services.AddSingleton<ServicioSocket>();
                      })
                 .Build();

                var app = host.Services.GetRequiredService<ServicioSocket>();

                app.IniciarServicio();

            }
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
