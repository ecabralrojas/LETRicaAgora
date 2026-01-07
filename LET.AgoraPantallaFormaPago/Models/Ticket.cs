namespace LET.AgoraPantallaFormaPago.Models
{
    public class Ticket
    {
  
        public string? GlobalId { get; set; }
        public string? BusinessDay { get; set; }
        public string? Date { get; set; }
        public User? User { get; set; }
        public Pos? Pos { get; set; }
        public Totals? Totals { get; set; }
        public Customer? Customer { get; set; }
    }
}
