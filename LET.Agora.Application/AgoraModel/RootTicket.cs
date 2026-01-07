namespace LET.Agora.Application.AgoraModel;

public class RootTicket
{
    public string? Serie { get; set; }
    public int Number { get; set; }
    public string BusinessDay { get; set; }
    public bool VatIncluded { get; set; }
    public int PrintCount { get; set; }
    public DateTime Date { get; set; }
    public Pos Pos { get; set; }
    public Workplace Workplace { get; set; }
    public User User { get; set; }
    public string DocumentType { get; set; }
    public List<InvoiceItem> InvoiceItems { get; set; }
    public List<Payment> Payments { get; set; }
    public Totals Totals { get; set; }
}
