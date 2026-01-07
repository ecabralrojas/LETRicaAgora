namespace LET.Agora.WebUI.Models
{
    public class Payment
    {
        public int PaymentMethodId { get; set; }
        public string? PaymentMethodName { get; set; }
        public decimal PayAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal ChangeAmount { get; set; }
        public string? Date { get; set; }
    }
}
