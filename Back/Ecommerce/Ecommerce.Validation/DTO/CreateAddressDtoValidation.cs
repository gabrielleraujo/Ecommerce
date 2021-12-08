using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Address;

namespace Ecommerce.Validation.DTO
{
    public static class CreateAddressDtoValidation
    {
        public static void Validate(this CreateAddressDTO dto, IList<string> erros)
        {
            if (string.IsNullOrEmpty(dto.CEP))
            {
                erros.Add("CEP not entered.");
            }
            if (dto.Number <= 0)
            {
                erros.Add("This number is invalid.");
            }
            if (string.IsNullOrEmpty(dto.City))
            {
                erros.Add("City not entered.");
            }
            if (string.IsNullOrEmpty(dto.State))
            {
                erros.Add("State not entered.");
            }
            if (string.IsNullOrEmpty(dto.Neighborhood))
            {
                erros.Add("Neighborhood not entered.");
            }
            if (string.IsNullOrEmpty(dto.Complement))
            {
                erros.Add("Complement not entered.");
            }
        }
    }
}