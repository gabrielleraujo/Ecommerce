using Job.CrossCutting.DTO.Product;

namespace Job.CrossCutting.DTO.Purchase
{
    public class ReadPurchaseItemDTO
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        //public Ecommerce.Data.Entities.Product Product { get; set; }
        public ReadProductDTO Product { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}