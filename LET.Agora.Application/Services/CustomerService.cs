using LET.Agora.Application.Models;
using LET.Agora.Application.Repositories;

namespace LET.Agora.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<ServiceResponse<Customer>> ObtenerCliente(int id)
    {
        return _customerRepository.ObtenerCliente(id);
    }
}
