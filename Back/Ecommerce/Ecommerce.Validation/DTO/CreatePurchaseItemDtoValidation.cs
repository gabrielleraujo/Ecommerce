using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;

namespace Ecommerce.Validation.DTO
{
    public static class CreatePurchaseItemDtoValidation
    {
        public static void Validate(this IList<CreatePurchaseItemDTO> dtoList, IList<string> erros)
        {
            foreach (var item in dtoList)
            {
                if (item.Quantity <= 0 || item.UnitPrice <= 0)
                {
                    erros.Add("Product quantity not informed, or unit price less than or equal to zero.");
                    return;
                }
            }
        }
    }
}