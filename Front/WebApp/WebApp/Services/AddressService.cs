using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.CrossCutting.DTO.Address;
using WebApp.Clients.Interfaces;
using WebApp.ViewModels;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressApiClient _addressApiClient;
        private readonly IMapper _mapper;

        public AddressService(IAddressApiClient addressApiClient, IMapper mapper)
        {
            _addressApiClient = addressApiClient;
            _mapper = mapper;
        }

        public async Task<AddressDetailsViewModel> AddAsync(AddressRegistrationViewModel addressViewModel)
        {
            var addressDto = _mapper.Map<CreateAddressDTO>(addressViewModel);

            var address = await _addressApiClient.PostAddressAsync(addressDto);
            return _mapper.Map<AddressDetailsViewModel>(address);
        }
    }
}