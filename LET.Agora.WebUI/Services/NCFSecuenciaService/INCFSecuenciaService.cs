using LET.Agora.WebUI.Models;

namespace LET.Agora.WebUI.Services.NCFSecuenciaService
{
    public interface INCFSecuenciaService
    {
        Task<ServiceResponse<IEnumerable<NCFSecuencia>>> ObtenerComprobanteFiscales();

    }
}