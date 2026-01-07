using LET.Agora.Application.Models;

namespace LET.Agora.Application.Repositories
{
    public interface IMonitorParametroRepository
    {
        Task<ServiceResponse<MonitorParametros>> ObtenerMonitorParametros(int idPos);
    }
}