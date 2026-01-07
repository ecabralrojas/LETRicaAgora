namespace LET.Agora.Api
{
    public static class ApiEndPoints
    {
        private const string ApiBase = "api";

        public static class Factura
        {
            public const string Base = $"{ApiBase}/facturas";
            public const string ObtenerFormaPagos = $"{Base}/ObtenerFormaPagos";
            public const string ObtenerTicketAbiertos = $"{Base}/ObtenerTicketAbiertos/{{salecenterid}}/{{locationname}}";
            public const string ObtenerCliente = $"{Base}/ObtenerCliente/{{id}}";
            public const string ObtenerIdClienteTicketAbierto = $"{Base}/ObtenerIdClienteTicketAbierto/{{globalId}}";
            public const string RegistrarFormaPagoAgora = $"{Base}/RegistrarFormaPagoAgora";
            public const string ObtenerComprobantesFiscales = $"{Base}/ObtenerComprobantesFiscales/{{serie}}";
            public const string ObtenerRNC = $"{Base}/ObtenerRNC/{{numerornc}}";
            public const string ObtenerFacturaAgora = $"{Base}/ObtenerFacturaAgora/{{serie}}/{{number}}";
            public const string RegistrarFacturaAgora = $"{Base}/RegistrarFacturaAgora";
            public const string ObtenerMonitorParametros = $"{Base}/ObtenerMonitorParametros/{{idPos}}";

        }
    }
}
