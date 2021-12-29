using Ecommerce.CrossCutting.DTO.Product;

namespace Ecommerce.CrossCutting.DTO.Purchase
{
    public class ReadPurchaseItemDTO
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public ReadProductDTO Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}