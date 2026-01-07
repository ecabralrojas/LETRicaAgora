using Dapper;
using LET.Agora.Application.Models;
using LET.Agora.Database;
using System.Data;

namespace LET.Agora.Application.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public CustomerRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }


        public async Task<ServiceResponse<Customer>> ObtenerCliente(int id)
        {
            var response = new ServiceResponse<Customer>();

            try
            {
                using (var connection = await _dbConnectionFactory.CreateConnectionAsync())
                {
                    var p = new DynamicParameters();
                    p.Add("@id", id);
                    var resultado = await connection.QueryFirstOrDefaultAsync<Customer>("ObtenerCliente", p, commandType: CommandType.StoredProcedure);
                    response.Data = resultado;

                }
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
