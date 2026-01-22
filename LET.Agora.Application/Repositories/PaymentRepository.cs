using Dapper;
using LET.Agora.Application.AgoraModel;
using LET.Agora.Application.Models;
using LET.Agora.Database;
using LET.Agora.Models;
//using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
//using Newtonsoft.Json;

namespace LET.Agora.Application.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PaymentRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;
        }

        public async Task<ServiceResponse<PaymentMethodContainer>> ObtenerFormaDePagos()
        {
            var response = new ServiceResponse<PaymentMethodContainer>();

            try
            {

                using (var client = _connectionFactory.CreateHttpAGORAConnectionAsync())
                {
                    client.DefaultRequestHeaders.Add("Api-Token", _connectionFactory.AgoraToken());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });

                    var respuestaAgora = await client.GetAsync("api/export-master/?filter=PaymentMethods");
                    var jsonString = await respuestaAgora.Content.ReadAsStringAsync();

                    if (respuestaAgora.IsSuccessStatusCode)
                    {
                        var paymentContainer = JsonSerializer.Deserialize<PaymentMethodContainer>(jsonString);
                        var defaultPaymentMethodResponse = await ObtenerFormaDePagoDefault(); 

                        if (defaultPaymentMethodResponse.Exito && defaultPaymentMethodResponse.Data != null)
                        {
                            // Atachar la forma de pago por defecto
                            if (paymentContainer.PaymentMethods != null)
                            {
                                // Convertir de IEnumerable a una lista
                                var paymentMethodsList = paymentContainer.PaymentMethods.ToList();
                                paymentMethodsList.Add(defaultPaymentMethodResponse.Data);
                                paymentContainer.PaymentMethods = paymentMethodsList;
                            }                      
                        }

                        response.Data = paymentContainer;
                    }
                    else
                    {
                        response.Mensaje = $"{respuestaAgora.ReasonPhrase} - {jsonString}";
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

        public async Task<ServiceResponse<PaymentMethod>> ObtenerFormaDePagoDefault()
        {
            var response = new ServiceResponse<PaymentMethod>();

            try
            {
                using (var connection = await _connectionFactory.CreateConnectionAsync())
                {
                    var p = new DynamicParameters();
                    var resultado = await connection.QueryFirstOrDefaultAsync<PaymentMethod>("BuscarFormaPagoEfectivoDefecto", commandType: CommandType.StoredProcedure);
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
        public async Task<ServiceResponse<Ticket>> EnviarFormaPago(AddPayment payment)
        {
            var resp = new ServiceResponse<Ticket>();

            try
            {
                using (var client = _connectionFactory.CreateHttpAGORAConnectionAsync())
                {
                    client.DefaultRequestHeaders.Add("Api-Token", _connectionFactory.AgoraToken());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });


                    string jsonObject = JsonSerializer.Serialize(payment);
                    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/tickets/add-payment", content);

                    string bodyResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        
                        var ticket = JsonSerializer.Deserialize<Ticket>(bodyResponse);

                        if (ticket.Serie != null)
                        {
                            resp.Exito = true;
                            resp.Data = new Ticket { Serie = ticket.Serie, Number = ticket.Number };    
                        }
                        
                    }
                    else
                    {
                        string bodyMessageResponse = $"{response.ReasonPhrase} -  {bodyResponse}";
                        resp.Mensaje = bodyMessageResponse;
                        resp.Exito = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Exito = false;
                resp.Mensaje = ex.Message;
            }

            return resp;
        }

        public async Task<ServiceResponse<InvoiceRoot>> EnviarFormaPagoAgoraAsync(AddPayment payment)
        {
            var resp = new ServiceResponse<InvoiceRoot>();

            try
            {
                using (var client = _connectionFactory.CreateHttpAGORAConnectionAsync())
                {
                    client.DefaultRequestHeaders.Add("Api-Token", _connectionFactory.AgoraToken());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });


                    string jsonObject = JsonSerializer.Serialize(payment);
                    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/tickets/add-payment", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string bodyResponse = await response.Content.ReadAsStringAsync();
                        var ticket = JsonSerializer.Deserialize<InvoiceRoot>(bodyResponse);

                        if (ticket.Serie != null)
                        {
                            resp.Exito = true;
                            resp.Data = ticket;
                        }

                    }
                    else
                    {
                        string bodyResponse = $"{response.ReasonPhrase}";
                        resp.Mensaje = bodyResponse;
                        resp.Exito = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Exito = false;
                resp.Mensaje = ex.Message;
            }

            return resp;
        }

        public async Task<ServiceResponse<Ticket>> EnviarFormaPagoTest(AddPayment payment)
        {
            var resp = new ServiceResponse<Ticket>();

            try
            {
                using (var client = _connectionFactory.CreateHttpAGORAConnectionAsync())
                {
                    client.DefaultRequestHeaders.Add("Api-Token", _connectionFactory.AgoraToken());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });


                    string jsonObject = JsonSerializer.Serialize(payment);
                    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/tickets/add-payment", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string bodyResponse = await response.Content.ReadAsStringAsync();
                        var ticket = JsonSerializer.Deserialize<Ticket>(bodyResponse);

                        if (ticket.Serie != null)
                        {
                            resp.Exito = true;
                            resp.Data = new Ticket { Serie = ticket.Serie, Number = ticket.Number };
                        }

                    }
                    else
                    {
                        string bodyResponse = $"{response.ReasonPhrase}";
                        resp.Mensaje = bodyResponse;
                        resp.Exito = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resp.Exito = false;
                resp.Mensaje = ex.Message;
            }

            return resp;
        }

    }
}
