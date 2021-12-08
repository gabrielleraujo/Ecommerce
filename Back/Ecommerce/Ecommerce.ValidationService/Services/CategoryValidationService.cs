using Ecommerce.CrossCutting.DTO.Category;
using Ecommerce.Validation;
using Ecommerce.Validation.DTO;

namespace Ecommerce.ValidationService.Services
{
    public class CategoryValidationService : BaseValidator<CreateCategoryDTO>
    {
        public override void Validate(CreateCategoryDTO dto)
        {
            dto.Validate(Erros);

            CheckErrors();
        }
    }
}