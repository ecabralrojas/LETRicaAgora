using Dapper;
using LET.Agora.Application.Models;
using LET.Agora.Database;
using System.Data;

namespace LET.Agora.Application.Repositories
{
    public class MonitorParametroRepository : IMonitorParametroRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MonitorParametroRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;
        }
        public async Task<ServiceResponse<MonitorParametros>> ObtenerMonitorParametros(int idPos)
        {
            var response = new ServiceResponse<MonitorParametros>();

            try
            {
                using var connection = await _connectionFactory.CreateConnectionAsync();
                var p = new DynamicParameters();
                p.Add("@IdPos", idPos);
                response.Data = await connection.QueryFirstOrDefaultAsync<MonitorParametros>("ObtenerMonitorParametros", p, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.Mensaje = ex.Message;

            }

            return response;
        }
    }
}
