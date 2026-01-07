namespace LET.Agora.WebUI.Models
{
    public class FacturaResponse
    {
        public Factura? factura { get; set; }
        public IEnumerable<FacturaDetalle>? FacturaDetalles { get; set; }
        public IEnumerable<FacturaDetalleAddin>? facturaDetalleAddins { get; set; }
        public IEnumerable<FacturaFormaPago>? facturaFormaPagos { get; set; }
        public FacturaComprobanteFiscal? facturaComprobanteFiscal { get; set; }
        public Company? company { get; set; }
        public MonitorParametros? monitorParametros { get; set; }
        public IEnumerable<ComentarioCabecera>? comentarioCabeceras { get; set; }
        public IEnumerable<ComentarioPiePagina>? comentarioPiePaginas { get; set; }
    }
}
