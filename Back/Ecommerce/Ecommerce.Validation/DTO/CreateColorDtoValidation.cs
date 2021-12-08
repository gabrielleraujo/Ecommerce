using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Color;
using Ecommerce.Data.Commons.Extensions;

namespace Ecommerce.Validation.DTO
{
    public static class CreateColorDtoValidation
    {
        public static void Validate(this CreateColorDTO dto, IList<string> erros)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                erros.Add("Color name not informed.");
            }

            try { ColorExtensions.ToValue_(dto.Name); }
            catch (Exception)
            {
                erros.Add("Name not available for color.");
            }
        }
    }
}