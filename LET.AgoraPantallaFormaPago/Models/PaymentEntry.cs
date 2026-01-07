namespace LET.AgoraPantallaFormaPago.Models
{
    public class PaymentEntry
    {
        public PaymentMethod PaymentMethod { get; set; }
        public decimal PayAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal ChangeAmount { get; set; }
        public string? Date { get; set; }
    }
}
