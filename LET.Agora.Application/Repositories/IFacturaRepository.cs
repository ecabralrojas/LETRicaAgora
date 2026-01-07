using LET.Agora.Application.Models;

namespace LET.Agora.Application.Repositories
{
    public interface IFacturaRepository
    {
        Task<ServiceResponse<IEnumerable<NCFSecuencia>>> ObtenerComprobantesFiscales(string serie);
        Task<ServiceResponse<RNCDGII>> ObtenerRNC(string rnc);
        Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(string serie, int number);
        //Task<ServiceResponse<bool>> RegistrarFacturaAgora(FacturaAgora facturaAgora);
        Task<ServiceResponse<FacturaResponse>> RegistrarFacturaAgora(FacturaAgora facturaAgora);
    }
}