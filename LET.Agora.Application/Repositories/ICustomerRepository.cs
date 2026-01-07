using LET.Agora.Application.Models;

namespace LET.Agora.Application.Repositories
{
    public interface ICustomerRepository
    {
        Task<ServiceResponse<Customer>> ObtenerCliente(int id);
    }
}