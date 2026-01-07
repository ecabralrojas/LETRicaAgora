using LET.Agora.Application.Models;

namespace LET.Agora.Application.Repositories
{
    public interface ITicketRepository
    {
        Task<ServiceResponse<TicketAbiertoContainer>> ObtenerTicketsAbiertos(string salecenter, string locationName);
        Task<ServiceResponse<int>> ObtenerIdClienteTicketAbierto(string globalId);
    }
}