using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Size;
using Ecommerce.Data.Commons.Extensions;

namespace Ecommerce.Validation.DTO
{
    public static class CreateSizeDtoValidation
    {
        public static void Validate(this CreateSizeDTO dto, IList<string> erros)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                erros.Add("Size name not entered.");
            }

            try { SizeExtensions.ToValue_(dto.Name); }
            catch (Exception)
            {
                erros.Add("Name not available for size.");
            }
        }
    }
}