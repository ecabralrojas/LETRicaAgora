namespace LET.Agora.Application.AgoraModel;

public class Tax
{
    public decimal VatRate { get; set; }
    public decimal SurchargeRate { get; set; }
    public decimal GrossAmount { get; set; }
    public decimal NetAmount { get; set; }
    public decimal VatAmount { get; set; }
    public decimal SurchargeAmount { get; set; }
}
