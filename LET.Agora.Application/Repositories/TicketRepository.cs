using System.Data;
using System.Net.Http.Headers;
using System.Text.Json;
using Dapper;
using LET.Agora.Application.Models;
using LET.Agora.Database;

namespace LET.Agora.Application.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public TicketRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _connectionFactory = dbConnectionFactory;
    }

    public async Task<ServiceResponse<TicketAbiertoContainer>> ObtenerTicketsAbiertos(string salecenterid, string locationName)
    {

        var response = new ServiceResponse<TicketAbiertoContainer>();

        try
        {

            using (var client = _connectionFactory.CreateHttpAGORAConnectionAsync())
            {
                client.DefaultRequestHeaders.Add("Api-Token", _connectionFactory.AgoraToken());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });

                var respuestAgora = await client.GetAsync($"api/export/tickets/?sale-center-id={salecenterid}&sale-location-name={locationName}");
                var jsonString = await respuestAgora.Content.ReadAsStringAsync();

                if (respuestAgora.IsSuccessStatusCode)
                {
                    var ticketContainer = JsonSerializer.Deserialize<TicketAbiertoContainer>(jsonString);

                    // filtrar si el GrossAmount es  > 0
                    if (ticketContainer != null && 
                        ticketContainer.Tickets != null)
                    {
                        ticketContainer.Tickets = ticketContainer.Tickets
                            .Where(ticket => ticket.Totals != null && ticket.Totals.GrossAmount > 0)
                            .ToList();
                    }

                    // Enrich each ticket with customer data
                    foreach (var ticket in ticketContainer.Tickets)
                    {
                        var customerResponse = await ObtenerCliente(ticket.GlobalId);
                        if (customerResponse.Exito && customerResponse.Data != null)
                        {
                            ticket.Customer = customerResponse.Data;
                        }
                    }

                    response.Data = ticketContainer;
                }
                else
                {
                    response.Mensaje = jsonString;
                    response.Exito = false;
                }
            }
        }
        catch (Exception ex)
        {
            response.Exito = false;
            response.Mensaje = ex.Message;
        }

        return response;
    }
    public async Task<ServiceResponse<int>> ObtenerIdClienteTicketAbierto(string globalId)
    {
        var response = new ServiceResponse<int>();

        try
        {
            using (var connection = await _connectionFactory.CreateConnectionAsync())
            {
                var p = new DynamicParameters();
                p.Add("@GlobalId ", globalId);
                var resultado = await connection.QueryFirstOrDefaultAsync<int>("ObtenerIdClienteTicketAbierto", p, commandType: CommandType.StoredProcedure);
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
    public async Task<ServiceResponse<Customer>> ObtenerCliente(string globalId)
    {
        var response = new ServiceResponse<Customer>();

        try
        {
            using (var connection = await _connectionFactory.CreateConnectionAsync())
            {
                var p = new DynamicParameters();
                p.Add("@GlobalId", globalId);
                var resultado = await connection.QueryFirstOrDefaultAsync<Customer>("LetObtenerCliente", p, commandType: CommandType.StoredProcedure);
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
