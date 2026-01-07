using LET.Agora.WebUI.Models;

namespace LET.Agora.WebUI.Services.FormaPagoService
{
    public interface IFormaPagoService
    {
        Task<ServiceResponse<PaymentMethodContainer>> ObtenerFormasDePagos();
        Task<ServiceResponse<Ticket>> RegistrarTicketPagos(AddPayment payment);
    }
}