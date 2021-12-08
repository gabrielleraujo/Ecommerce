using System.Collections.Generic;

namespace Ecommerce.CrossCutting.DTO.Purchase
{
    public class CreatePurchaseDTO
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public IList<CreatePurchaseItemDTO> Products { get; set; }
    }
}