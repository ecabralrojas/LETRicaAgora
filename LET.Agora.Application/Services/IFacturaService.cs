using LET.Agora.Application.Models;

namespace LET.Agora.Application.Services
{
    public interface IFacturaService
    {
        Task<ServiceResponse<IEnumerable<NCFSecuencia>>> ObtenerComprobantesFiscales(string serie);
        Task<ServiceResponse<RNCDGII>> ObtenerRNC(string rnc);
        Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(string serie, int number);
        Task<ServiceResponse<FacturaResponse>> RegistrarFacturaAgora(FacturaAgora facturaAgora);

    }
}