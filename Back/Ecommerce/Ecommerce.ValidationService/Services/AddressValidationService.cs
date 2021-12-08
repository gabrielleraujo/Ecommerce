using Ecommerce.CrossCutting.DTO.Address;
using Ecommerce.Validation;
using Ecommerce.Validation.DTO;

namespace Ecommerce.ValidationService.Services
{
    public class AddressValidationService : BaseValidator<CreateAddressDTO>
    {
        public override void Validate(CreateAddressDTO dto)
        {
            dto.Validate(Erros);

            CheckErrors();
        }
    }
}