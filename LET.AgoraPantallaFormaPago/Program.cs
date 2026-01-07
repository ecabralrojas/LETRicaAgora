using LET.AgoraPantallaFormaPago;
using LET.AgoraPantallaFormaPago.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();

customCulture.NumberFormat.NumberDecimalSeparator = ".";
customCulture.NumberFormat.CurrencyDecimalSeparator = ".";
customCulture.NumberFormat.PercentDecimalSeparator = ".";

CultureInfo.DefaultThreadCurrentCulture = customCulture;
CultureInfo.DefaultThreadCurrentUICulture = customCulture;

var parametro = builder.Configuration.GetSection("Parametro").Get<Parametro>();


builder.Services.AddApplication(parametro);
//builder.Services.AddScoped<TicketService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(parametro.ApiUrl!) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7178") });



await builder.Build().RunAsync();
