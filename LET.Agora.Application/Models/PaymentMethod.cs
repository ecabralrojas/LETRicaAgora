namespace LET.Agora.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool GiveChange { get; set; }
    public bool IncludeInBalance { get; set; }
    public bool IncludeTipInBalance { get; set; }
    public bool IsValidForSale { get; set; }
    public bool IsValidForPurchase { get; set; }
    public bool OpenCashDrawer { get; set; }
    public bool RegisterTip { get; set; }
    public bool AllowOverPaid { get; set; }
    public bool AllowExtraInformation { get; set; }
    public string ButtonText { get; set; }
    public string Color { get; set; }
    public bool ExtractTipFromCashdrawer { get; set; }
    public int Priority { get; set; }
    public bool RequireCustomer { get; set; }
    public object MaxAllowedPayment { get; set; }
    public bool IsValidForPhoneOrder { get; set; }
    public bool IsRefundVoucher { get; set; }
    public bool IsValidForRefund { get; set; }
    public DateTime? DeletionDate { get; set; }
}

public class PaymentMethodContainer
{
    public IEnumerable<PaymentMethod>? PaymentMethods { get; set; }
}