using LET.Agora.Application.Models;
using LET.Agora.Application.Services;
using LET.Agora.Models;
using Microsoft.AspNetCore.Mvc;

namespace LET.Agora.Api.Controllers
{

    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ITicketService _ticketService;
        private readonly ICustomerService _customerService;
        private readonly IFacturaService _facturaService; 
        private readonly IMonitorParametroService _monitorParametroService; 
        public FacturaController(IPaymentService paymentService,
                                 ITicketService ticketService,
                                 ICustomerService customerService,
                                 IFacturaService facturaService,
                                 IMonitorParametroService monitorParametroService)
        {
            _paymentService = paymentService;   
            _ticketService = ticketService;
            _customerService = customerService;
            _facturaService = facturaService;
            _monitorParametroService = monitorParametroService; 
        }

        [HttpGet(ApiEndPoints.Factura.ObtenerFormaPagos)]
        public async Task<IActionResult> ObtenerFormaPagos()
        {
            var formapagos = await _paymentService.ObtenerFormaDePagos();   
            return Ok(formapagos);  
        }

        [HttpGet(ApiEndPoints.Factura.ObtenerTicketAbiertos)]
        public async Task<IActionResult> ObtenerTicketAbiertos(string salecenterid, string locationname)
        {
            var ticketAbiertos = await _ticketService.ObtenerTicketsAbiertos(salecenterid, locationname);
            return Ok(ticketAbiertos);
        }

        //[HttpGet(ApiEndPoints.Factura.ObtenerIdClienteTicketAbierto)]
        //public async Task<IActionResult> ObtenerIdClienteTicketAbierto(string globalId)
        //{
        //    var idCliente = await _ticketService.ObtenerIdClienteTicketAbierto(globalId);
        //    return Ok(idCliente);
        //}

        //[HttpGet(ApiEndPoints.Factura.ObtenerCliente)]
        //public async Task<IActionResult> ObtenerCliente(int id)
        //{
        //    var customer = await _customerService.ObtenerCliente(id);
        //    return Ok(customer);
        //}

        [HttpPost(ApiEndPoints.Factura.RegistrarFormaPagoAgora)]
        public async Task<IActionResult> EnviarFormaPago([FromBody] AddPayment paymentMethod)
        {
            var formadepago = await _paymentService.EnviarFormadePago(paymentMethod);
            return Ok(formadepago);
        }

        [HttpGet(ApiEndPoints.Factura.ObtenerComprobantesFiscales)]
        public async Task<IActionResult> ObtenerComprobantesFiscales(string serie)
        {
            var comprobantes = await _facturaService.ObtenerComprobantesFiscales(serie);
            return Ok(comprobantes);
        }

        [HttpGet(ApiEndPoints.Factura.ObtenerRNC)]
        public async Task<IActionResult> ObtenerRNC(string numerornc)
        {
            var rnc = await _facturaService.ObtenerRNC(numerornc);
            return Ok(rnc);
        }

        [HttpGet(ApiEndPoints.Factura.ObtenerFacturaAgora)]
        public async Task<IActionResult> ObtenerFacturaAgora(string serie, int number)
        {
            var factura = await _facturaService.ObtenerFacturaAgora(serie, number);
            return Ok(factura);
        }

        [HttpPost(ApiEndPoints.Factura.RegistrarFacturaAgora)]
        public async Task<IActionResult> RegistrarFacturaAgora(FacturaAgora facturaAgora)
        {
            var factura = await _facturaService.RegistrarFacturaAgora(facturaAgora);
            return Ok(factura);
        }



        [HttpGet(ApiEndPoints.Factura.ObtenerMonitorParametros)]
        public async Task<IActionResult> ObtenerMonitorParametros(int idPos)
        {
            var parametros = await _monitorParametroService.ObtenerMonitorParametros(idPos);
            return Ok(parametros);
        }
    }
}
