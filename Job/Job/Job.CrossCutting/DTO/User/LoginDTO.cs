using System.ComponentModel.DataAnnotations;

namespace Job.CrossCutting.DTO.User
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "{0} não informado.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} não informado.")]
        public string Password { get; set; }
    }
}