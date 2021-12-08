using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.User;

namespace Ecommerce.Validation.DTO
{
    public static class CreateUserDtoValidation
    {
        public static void Validate(this CreateUserDTO dto, IList<string> erros)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                erros.Add("Name not entered.");
            }
            if (string.IsNullOrEmpty(dto.Surname))
            {
                erros.Add("Surname not entered.");
            }
            if (string.IsNullOrEmpty(dto.Username))
            {
                erros.Add("Username not entered.");
            }
            if (string.IsNullOrEmpty(dto.Password))
            {
                erros.Add("Password not entered.");
            }
            if (string.IsNullOrEmpty(dto.RePassword))
            {
                erros.Add("RePassword not entered.");
            }
        }
    }
}