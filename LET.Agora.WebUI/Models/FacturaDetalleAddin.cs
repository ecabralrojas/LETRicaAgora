namespace LET.Agora.WebUI.Models
{
    public class FacturaDetalleAddin
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int LineaTicket { get; set; }
        public int FormatoIdVenta { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int IdImpuesto { get; set; }
        public decimal TasaImpuesto { get; set; }
        public decimal PrecioCosto { get; set; }
        public int AddinIndex { get; set; }
        public int PosId { get; set; }
    }
}
