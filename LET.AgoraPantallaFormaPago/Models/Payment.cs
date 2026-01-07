namespace LET.AgoraPantallaFormaPago.Models
{
    public class Payment
    {
        public int MethodId { get; set; }
        public string? MethodName { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal TipAmount { get; set; }
        public DateTime Date { get; set; }
        public int PosId { get; set; }
        public bool IsPrepayment { get; set; }
        public string? ExtraInformation { get; set; }
    }
}
