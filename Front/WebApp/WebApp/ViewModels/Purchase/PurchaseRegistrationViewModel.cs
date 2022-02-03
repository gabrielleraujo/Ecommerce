namespace WebApp.ViewModels
{
    public class PurchaseRegistrationViewModel
    {
        public PurchaseRegistrationViewModel(string user, PurchaseItemRegistrationViewModel product)
        {
            User = user;
            Product = product;
        }

        public string User { get; }
        public PurchaseItemRegistrationViewModel Product { get; }
    }
}