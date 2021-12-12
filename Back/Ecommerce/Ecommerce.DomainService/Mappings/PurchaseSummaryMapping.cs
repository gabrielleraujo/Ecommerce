using AutoMapper;
using Ecommerce.CrossCutting.DTO.Product;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.Data.Entities;
using Ecommerce.DomainService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DomainService.Mappings
{
    public class PurchaseSummaryMapping : IPurchaseSummaryMapping
    {
        private readonly IMapper _mapper;

        public PurchaseSummaryMapping(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PurchaseSummary Criate(ReadPurchaseDTO purchase, ReadPurchaseItemDTO item)
        {
            return new PurchaseSummary
            {
                PurchaseDate = purchase.Date,
                UserId = purchase.User.Id,

                Name = item.Product.Name,
                Description = item.Product.Description,

                CategoryText = item.Product.Category.CategoryText,
                ColorText = item.Product.Color.ColorText,
                SizeText = item.Product.Size.SizeText,

                UnitPrice = item.UnitPrice,
                Quantity = item.Quantity
            };
        }

        public ReadPurchaseSummaryDTO CreateReadPurchaseSummaryDTO(IList<PurchaseSummary> purchaseSummary, DateTime date)
        {
            var products = _mapper.Map<List<ReadProductDTO>>(purchaseSummary);

            return new ReadPurchaseSummaryDTO
            {
                Date = date,
                Price = purchaseSummary.Sum(x => x.UnitPrice * x.Quantity),
                Products = products
            };
        }
    }
}