using System.ComponentModel.DataAnnotations;

namespace Ecommerce.CrossCutting.DTO.Category
{
    public class UpdateCategoryDTO
    {
        [Required(ErrorMessage = "{0} was not informed.")]
        public string Name { get; set; }
    }
}