using System.ComponentModel.DataAnnotations;

namespace Job.CrossCutting.DTO.User
{
    public class UpdateUsuarioDto
    {
        [Required(ErrorMessage = "{0} não informado.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} não informado.")]
        public string Sobrenome { get; set; }
    }
}