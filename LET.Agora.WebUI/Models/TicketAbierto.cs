namespace LET.Agora.WebUI.Models;

public class Pos
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class TicketAbiertoContainer
{
    public IEnumerable<TicketAbierto>? Tickets { get; set; }
}

public class SaleCenter
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
}


public class TicketAbierto
{
    public string? GlobalId { get; set; }
    public string? BusinessDay { get; set; }
    public string? Date { get; set; }
    public User? User { get; set; }
    public Pos? Pos { get; set; }
    public Totals? Totals { get; set; }
    public Customer? Customer { get; set; }
}

public class Totals
{
    public decimal GrossAmount { get; set; }
    public decimal NetAmount { get; set; }
    public decimal VatAmount { get; set; }
    public decimal SurchargeAmount { get; set; }

}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string? FiscalName { get; set; }
    public string? CustomerCode { get; set; }
}