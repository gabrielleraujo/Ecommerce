using Ecommerce.CrossCutting.DTO.Color;
using Ecommerce.Validation;
using Ecommerce.Validation.DTO;

namespace Ecommerce.ValidationService.Services
{
    public class ColorValidationService : BaseValidator<CreateColorDTO>
    {
        public override void Validate(CreateColorDTO dto)
        {
            dto.Validate(Erros);

            CheckErrors();
        }
    }
}