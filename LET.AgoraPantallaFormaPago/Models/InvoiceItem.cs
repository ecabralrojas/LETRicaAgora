namespace LET.AgoraPantallaFormaPago.Models
{
    public class InvoiceItem
    {
        public string ContentType { get; set; }
        public Pos Pos { get; set; }
        public User User { get; set; }
        public string GlobalId { get; set; }
        public string BusinessDay { get; set; }
        public object Guests { get; set; }
        public DateTime Date { get; set; }
        public SaleCenter SaleCenter { get; set; }
        public ServiceCharge ServiceCharge { get; set; }
        public List<Line> Lines { get; set; }
        public Discounts Discounts { get; set; }
        public List<object> Payments { get; set; }
        public List<object> Offers { get; set; }
        public bool VatIncluded { get; set; }
        public Totals Totals { get; set; }
    }
}
