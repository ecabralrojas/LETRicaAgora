using System.Globalization;
using CurrieTechnologies.Razor.SweetAlert2;
using LET.Agora.WebUI;
using LET.Agora.WebUI.JSInterop;
using LET.Agora.WebUI.Models;
using LET.Agora.WebUI.Services.CustomerService;
using LET.Agora.WebUI.Services.FacturaService;
using LET.Agora.WebUI.Services.FormaPagoService;
using LET.Agora.WebUI.Services.NCFSecuenciaService;
using LET.Agora.WebUI.Services.RNCService;
using LET.Agora.WebUI.Services.SocketService;
using LET.Agora.WebUI.Services.TicketService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

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

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(parametro.ApiUrl!)});
builder.Services.AddScoped<INCFSecuenciaService, NCFSecuenciaService>();
builder.Services.AddScoped<IFormaPagoService, FormaPagoService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IRNCService, RNCService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<ISocketUrlService, SocketUrlService>();
builder.Services.AddScoped<AgoraInterop>();
builder.Services.AddSweetAlert2();

builder.Services.AddApplication(parametro.ApiUrl!,
                                parametro.Serie!,
                                parametro.PosId!,
                                parametro.SaleCenterId!,
                                parametro.LocationName!,
                                parametro.Token!,
                                parametro.ApiUrlServer!,
                                parametro.SocketUrl!);

builder.Services.AddMudServices();



await builder.Build().RunAsync();
