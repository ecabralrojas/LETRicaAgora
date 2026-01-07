namespace LET.Agora.WebUI.Models
{
    public class NCFSecuencia
    {
        public int ID { get; set; }
        public int Tipo { get; set; }
        public string? Descripcion { get; set; }
        public string? NCFPrefix { get; set; }
        public int NCFSecuenciaInicial { get; set; }
        public int NCFSecuenciaFinal { get; set; }
        public DateTime NCFFechaVencimiento { get; set; }
        public int NCFSecuenciaActual { get; set; }
        public string? Status { get; set; }
        public string? Serie { get; set; }
        public string? AvisoComprobantes { get; set; }
        public int TieneDisponible { get; set; }
        public string? MensajeComprobantes { get; set; }
        public string? AvisoVencimiento { get; set; }
        public int TienenVencimiento { get; set; }
    }
}
