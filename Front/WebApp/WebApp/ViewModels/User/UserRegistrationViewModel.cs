using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class UserRegistrationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }


        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        public int? AddressId { get; set; }
    }
}