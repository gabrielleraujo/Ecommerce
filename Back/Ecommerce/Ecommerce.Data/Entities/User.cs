using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual IList<Purchase> Purchases { get; set; }
    }
}