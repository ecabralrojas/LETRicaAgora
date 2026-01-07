using LET.Agora.Application.AgoraModel;
using LET.Agora.Application.Models;
using LET.Agora.Models;

namespace LET.Agora.Application.Repositories
{
    public interface IPaymentRepository
    {
        Task<ServiceResponse<PaymentMethodContainer>> ObtenerFormaDePagos();
        Task<ServiceResponse<Ticket>> EnviarFormaPago(AddPayment payment);
        Task<ServiceResponse<InvoiceRoot>> EnviarFormaPagoAgoraAsync(AddPayment payment);
        
    }
}