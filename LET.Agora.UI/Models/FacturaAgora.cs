namespace LET.Agora.UI.Models
{
    public class FacturaAgora
    {
        public Factura? factura { get; set; }
        public IEnumerable<FacturaDetalle>? FacturaDetalles { get; set; }
        public IEnumerable<FacturaDetalleAddin>? facturaDetalleAddins { get; set; }
        public IEnumerable<FacturaFormaPago>? facturaFormaPagos { get; set; }
        public string? rnc { get; set; }
        public int TipoComprobante { get; set; }
    }
}
