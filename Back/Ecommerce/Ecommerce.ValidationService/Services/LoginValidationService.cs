using Ecommerce.CrossCutting.DTO.User;
using Ecommerce.Validation;
using Ecommerce.Validation.DTO;

namespace Ecommerce.ValidationService.Services
{
    public class LoginValidationService : BaseValidator<LoginDTO>
    {
        public override void Validate(LoginDTO dto)
        {
            dto.Validate(Erros);

            CheckErrors();
        }
    }
}