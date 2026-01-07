using LET.Agora.WebUI.Models;

namespace LET.Agora.WebUI.Services.FacturaService
{
    public interface IFacturaService
    {
        Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(Ticket ticket, string rncContribuyente, int tipocomprobante);
        Task<ServiceResponse<FacturaResponse>> RegistrarFacturaAgora(FacturaAgora facturaAgora);
    }
}