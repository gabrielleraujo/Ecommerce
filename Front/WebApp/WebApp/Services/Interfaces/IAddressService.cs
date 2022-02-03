using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Services.Interfaces
{
    public interface IAddressService
    {
        Task<AddressDetailsViewModel> AddAsync(AddressRegistrationViewModel addressViewModel);
    }
}