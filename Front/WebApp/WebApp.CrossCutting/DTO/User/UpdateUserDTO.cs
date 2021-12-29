using System.ComponentModel.DataAnnotations;

namespace Ecommerce.CrossCutting.DTO.User
{
    public class UpdateUserDTO
    {
        [Required(ErrorMessage = "{0} não informado.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} não informado.")]
        public string Sobrenome { get; set; }
    }
}