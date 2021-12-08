using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Address;

namespace Ecommerce.DomainService.Interfaces
{
    public interface IAddressDomainService
    {
        ReadAddressDTO Add(CreateAddressDTO createAddressDto);
        IList<ReadAddressDTO> List();
        ReadAddressDTO GetById(int id);
    }
}