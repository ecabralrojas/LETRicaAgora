using LET.Agora.Application.Models;

namespace LET.Agora.Application.Services
{
    public interface ITicketService
    {
        Task<ServiceResponse<TicketAbiertoContainer>> ObtenerTicketsAbiertos(string salecenterid, string locationName);
        Task<ServiceResponse<int>> ObtenerIdClienteTicketAbierto(string globalId);
    }
}