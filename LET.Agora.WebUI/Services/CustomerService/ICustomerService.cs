
namespace LET.Agora.WebUI.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<ServiceResponse<bool>> ObtenerLimiteCredito(string codigoCLiente, string totalTransaccion);
    }
}