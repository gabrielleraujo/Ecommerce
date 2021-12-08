using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.CrossCutting.DTO.Purchase;

namespace Ecommerce.IoC.MapperProfiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<CreatePurchaseDTO, Purchase>();
            CreateMap<Purchase, ReadPurchaseDTO>();

            CreateMap<CreatePurchaseItemDTO, PurchaseItem>();
            CreateMap<PurchaseItem, ReadPurchaseItemDTO>();

            CreateMap<PurchaseSummary, ReadPurchaseSummaryDTO>();
            CreateMap<ReadPurchaseSummaryDTO, PurchaseSummary>();

            CreateMap<PurchaseSummary, ReadProductOverviewDTO>();
        }
    }
}