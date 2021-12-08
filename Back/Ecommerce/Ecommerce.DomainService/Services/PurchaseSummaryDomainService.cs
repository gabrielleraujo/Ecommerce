using AutoMapper;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.Repository.Interfaces;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.Data.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Ecommerce.DomainService.Services
{
    public class PurchaseSummaryDomainService : IPurchaseSummaryDomainService
    {
        private readonly IPurchaseSummaryRepository _purchaseSummaryRepository;
        private readonly IPurchaseDomainService _purchaseDomainService;
        private readonly IMapper _mapper;

        public PurchaseSummaryDomainService(
            IPurchaseSummaryRepository purchaseSummaryRepository,
            IPurchaseDomainService purchaseDomainService,
            IMapper mapper)
        {
            _purchaseSummaryRepository = purchaseSummaryRepository;
            _purchaseDomainService = purchaseDomainService;
            _mapper = mapper;
        }

        public void AddList(IList<ReadPurchaseDTO> readListPurchaseDto)
        {
            foreach (var item in readListPurchaseDto) { Add(item); }
        }

        public void Add(ReadPurchaseDTO readPurchaseDTO)
        {
            var purchaseSummary = new List<PurchaseSummary>();

            foreach (var item in readPurchaseDTO.Products)
            {
                purchaseSummary.Add(Criate(readPurchaseDTO, item));                
            }
            _purchaseSummaryRepository.Add(purchaseSummary);
            _purchaseDomainService.SetHasSummary(true, readPurchaseDTO.Id);
        }

        public ReadPurchaseSummaryDTO GetById(DateTime date)
        {
            var purchaseSummary = _purchaseSummaryRepository.GetByDate(date);
            return CreateReadSummaryDTO(purchaseSummary, date);
        }

        public IList<ReadPurchaseSummaryDTO> ListByDate()
        {
            var query = _purchaseSummaryRepository.ListByDate();
            var sumaryList = new List<ReadPurchaseSummaryDTO>();

            foreach (var nameGroup in query)
            {
                sumaryList.Add(CreateReadSummaryDTO(nameGroup.ToList(), nameGroup.First().PurchaseDate));
            }
            return sumaryList;
        }

        private PurchaseSummary Criate(ReadPurchaseDTO purchase, ReadPurchaseItemDTO item)
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

        private ReadPurchaseSummaryDTO CreateReadSummaryDTO(IList<PurchaseSummary> purchaseSummary, DateTime date)
        {
            var products = _mapper.Map<List<ReadProductOverviewDTO>>(purchaseSummary);
            return new ReadPurchaseSummaryDTO
            {
                Date = date,
                Price = purchaseSummary.Sum(x => x.UnitPrice * x.Quantity),
                Products = products
            };
        }
    }
}