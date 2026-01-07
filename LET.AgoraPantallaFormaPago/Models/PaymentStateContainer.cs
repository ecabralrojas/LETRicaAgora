namespace LET.AgoraPantallaFormaPago.Models
{
    public class PaymentStateContainer
    {
        public List<AddPayment>? MappedPayments { get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal PaidAmount { get; private set; }
        public decimal RemainingAmount { get; private set; }
        public decimal ChangeAmount { get; private set; }
        public Ticket? Ticket { get; private set; }

        public event Action? OnChange;

        public void SetPayments(List<AddPayment> payments, decimal totalAmount, decimal paidAmount, decimal remainingAmount, decimal changeAmount, Ticket ticket)
        {
            MappedPayments = payments;
            TotalAmount = totalAmount;
            TotalAmount = totalAmount;
            PaidAmount = paidAmount;
            RemainingAmount = remainingAmount;
            ChangeAmount = changeAmount;
            Ticket = ticket;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}
