namespace LET.Agora.Application.AgoraModel
{
    public class Line
    {
        public int Index { get; set; }
        public DateTime CreationDate { get; set; }
        public string Type { get; set; }
        public int? ParentIndex { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SaleFormatId { get; set; }
        public string SaleFormatName { get; set; }
        public decimal SaleFormatRatio { get; set; }
        public string MainBarcode { get; set; }
        public decimal ProductPrice { get; set; }
        public int VatId { get; set; }
        public decimal VatRate { get; set; }
        public decimal SurchargeRate { get; set; }
        public decimal ProductCostPrice { get; set; }
        public string MenuGroup { get; set; }
        public int? PreparationTypeId { get; set; }
        public string PreparationTypeName { get; set; }
        public string PLU { get; set; }
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public int? PreparationOrderId { get; set; }
        public string PreparationOrderName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCostPrice { get; set; }
        public decimal TotalCostPrice { get; set; }
        public int UserId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal CashDiscount { get; set; }
        public int? OfferId { get; set; }
        public string OfferCode { get; set; }
        public decimal TotalAmount { get; set; }
        public int PriceListId { get; set; }
    }
}
