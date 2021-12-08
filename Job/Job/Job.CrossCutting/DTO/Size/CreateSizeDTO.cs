using System.ComponentModel.DataAnnotations;

namespace Job.CrossCutting.DTO.Size
{
    public class CreateSizeDTO
    {
        [Required]
        public string Name { get; set; }
    }
}