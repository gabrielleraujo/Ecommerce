using Ecommerce.CrossCutting.DTO.Address;

namespace Ecommerce.CrossCutting.DTO.User
{
    public class ReadUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public ReadAddressDTO Address { get; set; }
    }
}