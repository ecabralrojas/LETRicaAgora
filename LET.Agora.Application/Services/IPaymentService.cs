using LET.Agora.Application.AgoraModel;
using LET.Agora.Application.Models;
using LET.Agora.Models;

namespace LET.Agora.Application.Services
{
    public interface IPaymentService
    {
        Task<ServiceResponse<PaymentMethodContainer>> ObtenerFormaDePagos();
        Task<ServiceResponse<Ticket>> RegistrarFormaPagoAgora(AddPayment payment);
        Task<ServiceResponse<InvoiceRoot>> EnviarFormaPagoAgoraAsync(AddPayment payment);
        Task<ServiceResponse<Ticket>> EnviarFormadePago(AddPayment addPayment);
    }
}