using LET.Agora.Application.Models;

namespace LET.Agora.Application.Services
{
    public interface IMonitorParametroService
    {
        Task<ServiceResponse<MonitorParametros>> ObtenerMonitorParametros(int idPos);
    }
}