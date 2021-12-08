using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Category;
using Ecommerce.Data.Commons.Extensions;

namespace Ecommerce.Validation.DTO
{
    public static class CreateCategoryDtoValidation
    {
        public static void Validate(this CreateCategoryDTO dto, IList<string> erros)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                erros.Add("Category name not entered.");
            }

            try { CategoryExtensions.ToValue_(dto.Name); }
            catch (Exception)
            {
                erros.Add("Name not available for category.");
            }
        }
    }
}