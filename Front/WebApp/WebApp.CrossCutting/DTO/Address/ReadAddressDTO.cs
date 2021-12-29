namespace Ecommerce.CrossCutting.DTO.Address
{
    public class ReadAddressDTO
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}