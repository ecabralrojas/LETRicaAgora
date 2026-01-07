using LET.Agora.Libreria.Impresion.Models;

namespace LET.Agora.Libreria.Impresion.Repositories
{
    public interface IImpresionService
    {
        ServiceResponse<bool> ImprimirFactura(FacturaResponse fr);
    }
}