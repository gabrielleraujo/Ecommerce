using AutoMapper;
using WebApp.ViewModels;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.CrossCutting.DTO.Address;

namespace WebApp.Ioc.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<CreatePurchaseDTO, PurchaseRegistrationViewModel>();

            CreateMap<AddressRegistrationViewModel, CreateAddressDTO>();
            CreateMap<ReadAddressDTO, AddressDetailsViewModel>();

            CreateMap<PurchaseItemRegistrationViewModel, CreatePurchaseItemDTO>();
        }
    }
}