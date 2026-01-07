namespace LET.Agora.Application.Models
{
    public class AddPayment
    {
        public string? TicketGlobalId { get; set; }
        public int PosId { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal TipAmount { get; set; }
        public bool KeepOpen { get; set; }
        public string? ExtraInformation { get; set; }
    }
}
