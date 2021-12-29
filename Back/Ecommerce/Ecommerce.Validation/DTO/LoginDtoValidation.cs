using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.User;

namespace Ecommerce.Validation.DTO
{
    public static class LoginDtoValidation
    {
        public static void Validate(this LoginDTO dto, IList<string> erros)
        {
            if (string.IsNullOrEmpty(dto.Username))
            {
                erros.Add("Username not entered.");
            }
            if (string.IsNullOrEmpty(dto.Password))
            {
                erros.Add("Password not entered.");
            }
        }
    }
}