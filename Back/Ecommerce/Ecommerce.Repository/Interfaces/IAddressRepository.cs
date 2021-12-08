using Ecommerce.Data.Entities;
using System.Collections.Generic;

namespace Ecommerce.Repository.Interfaces
{
    public interface IAddressRepository
    {
        void Add(Address address);
        IList<Address> List();
        Address GetById(int id);
    }
}