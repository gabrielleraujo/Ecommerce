using System.ComponentModel.DataAnnotations;

namespace Job.CrossCutting.DTO.User
{
    public class CreateUserDTO
    {
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        public string RePassword { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? AddressId { get; set; }
    }
}