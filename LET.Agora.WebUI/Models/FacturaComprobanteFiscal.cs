namespace LET.Agora.WebUI.Models
{
    public class FacturaComprobanteFiscal
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public int Tipo { get; set; }
        public string NCF { get; set; }
        public string RNC { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string NCFDescripcion { get; set; }
        public string AvisoComprobantes { get; set; }
        public int TieneDisponible { get; set; }
        public string MensajeComprobantes { get; set; }
    }
}
