namespace LET.AgoraPantallaFormaPago.ModeloFactura
{
    public class FacturaFormaPago
    {
        public int IdPago { get; set; }
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int IdFormaPago { get; set; }
        public int PosId { get; set; }
        public int IdTransaccionTarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal TotalDevuelta { get; set; }
        public decimal TotalPropina { get; set; }
        public string InformacionExtra { get; set; }
        public string DescripcionPago { get; set; }
    }
}
