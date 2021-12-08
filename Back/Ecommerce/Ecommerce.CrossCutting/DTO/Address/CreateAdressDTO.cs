namespace Ecommerce.CrossCutting.DTO.Address
{
    public class CreateAddressDTO
    {
        public string CEP { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}