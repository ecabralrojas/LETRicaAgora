namespace LET.AgoraPantallaFormaPago.Models
{
    public class ServiceCharge
    {
        public decimal Rate { get; set; }
        public int VatId { get; set; }
        public decimal VatRate { get; set; }
        public decimal SurchargeRate { get; set; }
        public bool ApplyToVatIncluded { get; set; }
        public bool IgnoreTicketDiscounts { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal SurchargeAmount { get; set; }
    }
}
