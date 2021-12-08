using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.Validation;
using Ecommerce.Validation.DTO;

namespace Ecommerce.ValidationService.Services
{
    public class PurchaseValidationService : BaseValidator<CreatePurchaseDTO>
    {
        public override void Validate(CreatePurchaseDTO dto)
        {
            dto.Validate(Erros);
            dto.Products.Validate(Erros);

            CheckErrors();
        }
    }
}