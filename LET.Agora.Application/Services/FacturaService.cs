using LET.Agora.Application.Models;
using LET.Agora.Application.Repositories;


namespace LET.Agora.Application.Services;

public class FacturaService : IFacturaService
{
    private readonly IFacturaRepository _facturaRepository;

    public FacturaService(IFacturaRepository facturaRepository)
    {
        _facturaRepository = facturaRepository;
    }

    public Task<ServiceResponse<IEnumerable<NCFSecuencia>>> ObtenerComprobantesFiscales(string serie)
    {
        return _facturaRepository.ObtenerComprobantesFiscales(serie);
    }

    public Task<ServiceResponse<RNCDGII>> ObtenerRNC(string rnc)
    {
        return _facturaRepository.ObtenerRNC(rnc);
    }

    public Task<ServiceResponse<FacturaAgora>> ObtenerFacturaAgora(string serie, int number)
    {
        return _facturaRepository.ObtenerFacturaAgora(serie, number);   
    }

    public Task<ServiceResponse<FacturaResponse>> RegistrarFacturaAgora(FacturaAgora facturaAgora)
    {
        return _facturaRepository.RegistrarFacturaAgora(facturaAgora);
    }
}
