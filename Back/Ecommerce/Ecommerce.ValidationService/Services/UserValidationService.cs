using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.Validation;
using Ecommerce.Validation.DTO;

namespace Ecommerce.ValidationService.Services
{
    public class UserValidationService : BaseValidator<CreateUserDTO>
    {
        public override void Validate(CreateUserDTO dto)
        {
            dto.Validate(Erros);

            CheckErrors();
        }
    }
}