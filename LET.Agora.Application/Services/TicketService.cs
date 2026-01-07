using LET.Agora.Application.Models;
using LET.Agora.Application.Repositories;

namespace LET.Agora.Application.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public Task<ServiceResponse<TicketAbiertoContainer>> ObtenerTicketsAbiertos(string salecenterid, string locationName)
    {
        return _ticketRepository.ObtenerTicketsAbiertos(salecenterid, locationName);
    }

    public Task<ServiceResponse<int>> ObtenerIdClienteTicketAbierto(string globalId)
    {
        return _ticketRepository.ObtenerIdClienteTicketAbierto(globalId);
    }
}
