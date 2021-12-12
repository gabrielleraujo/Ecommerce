using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.CrossCutting.DTO.Product;

namespace Ecommerce.IoC.MapperProfiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<CreatePurchaseDTO, Purchase>();
            CreateMap<Purchase, ReadPurchaseDTO>();
            CreateMap<ReadPurchaseDTO, Purchase>()
                .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Address.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<CreatePurchaseItemDTO, PurchaseItem>();
            CreateMap<PurchaseItem, ReadPurchaseItemDTO>();
            CreateMap<ReadPurchaseItemDTO, PurchaseItem>();

            CreateMap<PurchaseSummary, ReadPurchaseSummaryDTO>();
            CreateMap<ReadPurchaseSummaryDTO, PurchaseSummary>();
            CreateMap<PurchaseSummary, ReadProductDTO>()
                .ForPath(dest => dest.Category.CategoryText, opt => opt.MapFrom(src => src.CategoryText))
                .ForPath(dest => dest.Color.ColorText, opt => opt.MapFrom(src => src.ColorText))
                .ForPath(dest => dest.Size.SizeText, opt => opt.MapFrom(src => src.SizeText))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.UnitPrice));
        }
    }
}