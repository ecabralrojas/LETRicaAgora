using LET.AgoraPantallaFormaPago.ModeloFactura;
using LET.AgoraPantallaFormaPago.Models;

namespace LET.AgoraPantallaFormaPago.Services.TicketServices
{
    public interface ITicketService
    {
        Task<ServiceResponse<bool>> ObtenerLimiteCreditoCliente(string customerCode, decimal amount);
        Task<ServiceResponse<TicketResponse>> GetOpenTickets();
        Task<ServiceResponse<PaymentMethodsResponse>> GetPaymentMethods();
        Task<ServiceResponse<IEnumerable<NCFSecuencia>>> ObtenerComprobantesFiscales();
        Task<ServiceResponse<RncDgii>> ObtenerRNC(string rnc);
        Task<ServiceResponse<TicketAgora>> RegistrarFormaPagoAgora(AddPayment payment);
        Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(TicketAgora ticket, string rncContribuyente, int tipocomprobante);
        Task<ServiceResponse<FacturaResponse>> RegistrarFacturaAgora(FacturaAgora facturaAgora);
    }
}