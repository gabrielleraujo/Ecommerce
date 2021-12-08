using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.DomainService.Interfaces;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Address;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.DomainService.Services
{
    public class AddressDomainService : IAddressDomainService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressDomainService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public ReadAddressDTO Add(CreateAddressDTO createAddressDto)
        {
            var address = _mapper.Map<Address>(createAddressDto);
            _addressRepository.Add(address);

            return _mapper.Map<ReadAddressDTO>(address);
        }

        IList<ReadAddressDTO> IAddressDomainService.List()
        {
            var addresses = _addressRepository.List();

            return addresses != null ? _mapper.Map<IList<ReadAddressDTO>>(addresses) : null;
        }
        ReadAddressDTO IAddressDomainService.GetById(int id)
        {
            var address = _addressRepository.GetById(id);

            return address != null ? _mapper.Map<ReadAddressDTO>(address) : null;
        }
    }
}