using System.ComponentModel.DataAnnotations;

namespace Job.CrossCutting.DTO.Product
{
    public class UpdateProductDTO
    {
        [Required(ErrorMessage = "{0} was not informed.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} was not informed.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "{0} was not informed.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "{0} was not informed.")]
        public int CategoryId { get; set; }
    }
}