using LET.Agora.Application.AgoraModel;
using LET.Agora.Application.Models;
using LET.Agora.Application.Repositories;
using LET.Agora.Models;

namespace LET.Agora.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public Task<ServiceResponse<PaymentMethodContainer>> ObtenerFormaDePagos()
        {
            return _paymentRepository.ObtenerFormaDePagos();
        }

        public Task<ServiceResponse<Ticket>> RegistrarFormaPagoAgora(AddPayment payment)
        {
            return _paymentRepository.EnviarFormaPago(payment);
        }        

        public Task<ServiceResponse<InvoiceRoot>> EnviarFormaPagoAgoraAsync(AddPayment payment)
        {
            return _paymentRepository.EnviarFormaPagoAgoraAsync(payment);
        }

        public Task<ServiceResponse<Ticket>> EnviarFormadePago(AddPayment addPayment)
        {
            return _paymentRepository.EnviarFormaPago(addPayment);
        }
    }
}
