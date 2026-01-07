namespace LET.AgoraPantallaFormaPago.Models
{
    public class Totals
    {
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal SurchargeAmount { get; set; }
        public List<Tax>? Taxes { get; set; }
    }
}
