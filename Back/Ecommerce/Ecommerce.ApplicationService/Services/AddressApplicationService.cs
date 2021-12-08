using System.Collections.Generic;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.CrossCutting.DTO.Address;
using Ecommerce.ValidationService.Services;

namespace Ecommerce.ApplicationService.Services
{
    public class AddressApplicationService : IAddressApplicationService
    {
        private readonly IAddressDomainService _addressDomainService;
        private readonly AddressValidationService _addressValidationService;

        public AddressApplicationService(IAddressDomainService addressDomainService, AddressValidationService addressValidationService)
        {
            _addressDomainService = addressDomainService;
            _addressValidationService = addressValidationService;
        }

        public ReadAddressDTO Add(CreateAddressDTO createAddressDto)
        {
            _addressValidationService.Validate(createAddressDto);

            return _addressDomainService.Add(createAddressDto);
        }

        public IList<ReadAddressDTO> List()
        {
            return _addressDomainService.List();
        }

        public ReadAddressDTO GetById(int id)
        {
            return _addressDomainService.GetById(id);
        }
    }
}