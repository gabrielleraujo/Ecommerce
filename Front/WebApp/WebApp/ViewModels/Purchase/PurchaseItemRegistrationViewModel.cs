namespace WebApp.ViewModels
{
    public class PurchaseItemRegistrationViewModel
    {
        public PurchaseItemRegistrationViewModel() { }
        public PurchaseItemRegistrationViewModel(int productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = 1;
        }

        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}