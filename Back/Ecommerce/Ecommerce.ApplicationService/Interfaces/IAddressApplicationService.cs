using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Address;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface IAddressApplicationService
    {
        ReadAddressDTO Add(CreateAddressDTO createAddressDto);
        IList<ReadAddressDTO> List();
        ReadAddressDTO GetById(int id);
    }
}