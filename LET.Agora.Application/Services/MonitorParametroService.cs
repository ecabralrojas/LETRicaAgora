using LET.Agora.Application.Models;
using LET.Agora.Application.Repositories;

namespace LET.Agora.Application.Services;

public class MonitorParametroService : IMonitorParametroService
{
    private readonly IMonitorParametroRepository _monitorParametroRepository;

    public MonitorParametroService(IMonitorParametroRepository monitorParametroRepository)
    {
        _monitorParametroRepository = monitorParametroRepository;
    }

    public Task<ServiceResponse<MonitorParametros>> ObtenerMonitorParametros(int idPos)
    {
        return _monitorParametroRepository.ObtenerMonitorParametros(idPos);
    }
}