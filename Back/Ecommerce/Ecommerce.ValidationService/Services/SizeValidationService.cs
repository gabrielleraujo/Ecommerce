using Ecommerce.CrossCutting.DTO.Size;
using Ecommerce.Validation;
using Ecommerce.Validation.DTO;

namespace Ecommerce.ValidationService.Services
{
    public class SizeValidationService : BaseValidator<CreateSizeDTO>
    {
        public override void Validate(CreateSizeDTO dto)
        {
            dto.Validate(Erros);

            CheckErrors();
        }
    }

    //public class TamanhoValidationService<T> : BaseValidator<T>
    //{
    //    public override void Validate(T dto)
    //    {
    //        //dto.Validate(Erros);

    //        CheckErrors();
    //    }
    //}
}