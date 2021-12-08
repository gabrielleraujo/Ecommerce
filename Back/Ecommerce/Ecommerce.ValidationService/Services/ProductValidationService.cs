using Ecommerce.Validation;
using Ecommerce.Validation.DTO;
using Ecommerce.CrossCutting.DTO.Product;

namespace Ecommerce.ValidationService.Services
{
    public class ProductValidationService : BaseValidator<CreateProductDTO>
    {
        public override void Validate(CreateProductDTO dto)
        {
            dto.Validate(Erros);

            CheckErrors();
        }
    }
}