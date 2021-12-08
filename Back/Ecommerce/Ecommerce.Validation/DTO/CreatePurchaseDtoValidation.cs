using Ecommerce.CrossCutting.DTO.Purchase;
using System.Collections.Generic;

namespace Ecommerce.Validation.DTO
{
    public static class CreatePurchaseDtoValidation
    {
        public static void Validate(this CreatePurchaseDTO dto, IList<string> erros)
        {
            if (dto.UserId == 0 || dto.Products == null)
            {
                 erros.Add("User name or products not informed.");
            }
        }
    }
}