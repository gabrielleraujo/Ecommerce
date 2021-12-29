namespace Ecommerce.CrossCutting.DTO.Purchase
{
    public class CreatePurchaseItemDTO
    {
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}