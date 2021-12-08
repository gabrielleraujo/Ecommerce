using System.Collections.Generic;

namespace Job.CrossCutting.DTO.Purchase
{
    public class CreatePurchaseDTO
    {
        public int UserId { get; set; }
        public IList<CreatePurchaseItemDTO> Products { get; set; }
    }
}