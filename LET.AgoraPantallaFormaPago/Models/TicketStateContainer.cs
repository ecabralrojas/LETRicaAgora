namespace LET.AgoraPantallaFormaPago.Models
{
    public class TicketStateContainer
    {
        private Ticket? _currentticket;

        public Ticket? CurrentTicket
        {
            get => _currentticket;
            set 
            {
                _currentticket = value;
                NotifyStateChanged();
            } 
        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
