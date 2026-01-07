
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using PosClient.Models;

namespace PosClient
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();

                MessageBox.Show("LEER ARCHIVO");
                //using var reader = new StreamReader($"{path}\\appsettings.json");
                string tmp = File.ReadAllText($"{path}\\appsettings.json");
                var appsettings = JsonConvert.DeserializeObject<AgoraSetting>(tmp);
                //var appsettings = JsonConvert.DeserializeObject<AgoraSetting>(reader.ReadToEnd());
                MessageBox.Show("PASO ARCHIVO");

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                var servicesCollection = new ServiceCollection();

                ConfigureServices(servicesCollection, appsettings!);
                ServiceProvider = servicesCollection.BuildServiceProvider();
                MessageBox.Show("PASO DEPENDENCIA");


                Application.Run(ServiceProvider.GetRequiredService<FrmPantallaCobro>());
                //Application.Run(new FrmPantallaCobro());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            
        }

        private static void ConfigureServices(ServiceCollection services, AgoraSetting agoraSetting)
        {
            services.AddApplication(agoraSetting);
            
        }
    }
}