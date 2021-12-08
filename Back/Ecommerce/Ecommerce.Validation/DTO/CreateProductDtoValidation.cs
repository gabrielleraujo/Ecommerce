using Ecommerce.CrossCutting.DTO.Product;
using System.Collections.Generic;

namespace Ecommerce.Validation.DTO
{
    public static class CreateProductDtoValidation
    {
        public static void Validate(this CreateProductDTO dto, IList<string> erros)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                erros.Add("Product name not entered.");
            }
            if (string.IsNullOrEmpty(dto.Description))
            {
                erros.Add("Description name not entered.");
            }
            if (dto.Price <= 0)
            {
                erros.Add("Price must be greater than zero.");
            }
            if (dto.CategoryId <= 0)
            {
                erros.Add("Category not found.");
            }
        }
    }
}