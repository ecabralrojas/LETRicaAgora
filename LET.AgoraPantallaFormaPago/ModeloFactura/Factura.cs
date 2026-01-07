namespace LET.AgoraPantallaFormaPago.ModeloFactura
{
    public class Factura
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Impuestos { get; set; }
        public decimal TotalNeto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Propina { get; set; }
        public string MensajePropina { get; set; }
        public string Ubicacion { get; set; }
        public string Mesa { get; set; }
        public string Usuario { get; set; }
        public int IdInvoice { get; set; }
        public int IdTicket { get; set; }
        public int RelatedInvoiceId { get; set; }
        public decimal TasaUSD { get; set; }
        public decimal MontoTotalUSD { get; set; }
        public decimal Descuento { get; set; }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal MontoTotalDescuento { get; set; }
        public int PosId { get; set; }
        public int IdCliente { get; set; }
        public string? CodigoCliente { get; set; }
        public string? NombreCliente { get; set; }
    }
}
