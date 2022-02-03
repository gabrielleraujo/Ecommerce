using System.Threading.Tasks;
using Ecommerce.CrossCutting.DTO.Address;

namespace WebApp.Clients.Interfaces
{
    public interface IAddressApiClient
    {
        Task<ReadAddressDTO> PostAddressAsync(CreateAddressDTO addressDto);
    }
}