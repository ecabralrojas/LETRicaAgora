
using System.Windows.Forms.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using LET.Agora.UI.Models;
using LET.Agora.UI;


namespace LET.Agora.UI
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; set; }
        public static IConfiguration Configuration { get; private set; } = null!;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI setctings or default font,
            // see https://aka.ms/applicationconfiguration.
            //await Task.Delay(3000);
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path to the application directory
                .AddJsonFile("parametrospos.json").Build();

            var apiUrl = builder.GetValue<string>("ApiUrl");
            var apiUrlServer = builder.GetValue<string>("ApiUrlServer");
            var serie = builder.GetValue<string>("Serie");
            var posid = builder.GetValue<string>("PosId");
            var saleCenterId = builder.GetValue<string>("SaleCenterId");
            var locationName = builder.GetValue<string>("LocationName");
            var token = builder.GetValue<string>("Token");

            ApplicationConfiguration.Initialize();
            var servicesCollection = new ServiceCollection();
            ConfigureServices(servicesCollection, apiUrl, serie, posid, saleCenterId, locationName,token, apiUrlServer);
            ServiceProvider = servicesCollection.BuildServiceProvider();
      
            Application.Run(ServiceProvider.GetRequiredService<frmFormaPago>());
     

        }

        private static void ConfigureServices(ServiceCollection services, 
                                              string apiurl, 
                                              string serie, 
                                              string posid, 
                                              string saleCenterId,
                                              string locationName,
                                              string tokenServer,
                                              string apiUrlServer)
        {
            services.AddSettings(apiurl, serie, posid, saleCenterId, locationName, tokenServer, apiUrlServer); 
            services.AddTransient<frmFormaPago>();
               
        }

    

    }
}