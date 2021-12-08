using Ecommerce.Data.Context;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository.EF
{
    public class AddressRepository : IAddressRepository
    {
        private EcommerceContext _context;

        public AddressRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public IList<Address> List()
        {
            return _context.Addresses.ToList();
        }

        public Address GetById(int id)
        {
            return _context.Addresses.FirstOrDefault(a => a.Id == id);
        }
    }
}