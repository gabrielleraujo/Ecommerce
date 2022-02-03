using Ecommerce.CrossCutting.DTO.Purchase;
using System.Collections.Generic;

namespace WebApp.Services.Mappings
{
    public class PurchaseServiceMapping
    {
        public static CreatePurchaseDTO CreateDataTestToPurchase(int productId, double unitPrice)
        {
            var purchaseItemDto = CreatePurchaseItem(productId, unitPrice);
            var purchaseDto = SetDataTestToPurchase(purchaseItemDto);

            return purchaseDto;
        }

        private static CreatePurchaseItemDTO CreatePurchaseItem(int productId, double unitPrice)
        {
            return new CreatePurchaseItemDTO
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = 1
            };
        }

        private static CreatePurchaseDTO SetDataTestToPurchase(CreatePurchaseItemDTO purchaseItemDto)
        {
            // to test
            var purchaseDto = new CreatePurchaseDTO
            {
                UserId = 1,
                AddressId = 1,
                Products = new List<CreatePurchaseItemDTO> { purchaseItemDto }
            };
            return purchaseDto;
        }
    }
}