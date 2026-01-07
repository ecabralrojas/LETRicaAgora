using LET.Agora.WebUI.Models;

namespace LET.Agora.WebUI.Services.TicketService
{
    public interface ITicketService
    {
        Task<ServiceResponse<TicketAbiertoContainer>> ObtenerTicketAbierto();
    }
}