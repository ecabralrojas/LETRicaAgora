namespace LET.Agora.UI.Models
{
    public class EnvioPago
    {
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ChangeAmount { get; set; }
        public string? Descripcion { get; set; }

    }
}
