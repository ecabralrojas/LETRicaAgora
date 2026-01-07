using LET.Agora.Application.Models;

namespace LET.Agora.Application.Services
{
    public interface ICustomerService
    {
        Task<ServiceResponse<Customer>> ObtenerCliente(int id);
    }
}