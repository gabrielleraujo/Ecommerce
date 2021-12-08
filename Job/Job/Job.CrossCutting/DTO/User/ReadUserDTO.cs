using Job.CrossCutting.DTO.Address;

namespace Job.CrossCutting.DTO.User
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public ReadAddressDTO Address { get; set; }
        //public Ecommerce.Data.Entities.Address Endereco { get; set; }
    }
}