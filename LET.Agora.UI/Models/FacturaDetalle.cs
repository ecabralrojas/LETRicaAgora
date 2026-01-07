namespace LET.Agora.UI.Models
{
    public class FacturaDetalle
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int Linea { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Importe { get; set; }
        public int IdTicket { get; set; }
        public int IdTicketLine { get; set; }
        public int IdInvoice { get; set; }
        public decimal TasaImpuesto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public decimal MontoTotalDescuento { get; set; }
        public int PosId { get; set; }
    }
}
