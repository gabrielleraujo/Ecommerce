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
        private readonly IPurchaseSummaryMapping _purchaseSummaryMapping;

        public PurchaseSummaryDomainService(
            IPurchaseSummaryRepository purchaseSummaryRepository,
            IPurchaseSummaryMapping purchaseSummaryMapping)
        {
            _purchaseSummaryRepository = purchaseSummaryRepository;
            _purchaseSummaryMapping = purchaseSummaryMapping;
        }

        public void AddList(IList<ReadPurchaseDTO> readListPurchaseDto)
        {
            List<PurchaseSummary> purchaseSummary;

            foreach (var purchase in readListPurchaseDto) 
            {
                purchaseSummary = new List<PurchaseSummary>();

                foreach (var item in purchase.Products)
                {
                    purchaseSummary.Add(_purchaseSummaryMapping.Criate(purchase, item));
                }
                _purchaseSummaryRepository.Add(purchaseSummary);
            }
        }

        public ReadPurchaseSummaryDTO GetById(DateTime date)
        {
            var purchaseSummary = _purchaseSummaryRepository.GetByDate(date);
            return _purchaseSummaryMapping.CreateReadPurchaseSummaryDTO(purchaseSummary, date);
        }

        public IList<ReadPurchaseSummaryDTO> ListByDate()
        {
            var query = _purchaseSummaryRepository.ListByDate();
            var sumaryList = new List<ReadPurchaseSummaryDTO>();

            foreach (var nameGroup in query)
            {
                sumaryList.Add(_purchaseSummaryMapping.CreateReadPurchaseSummaryDTO(nameGroup.ToList(), nameGroup.First().PurchaseDate));
            }

            return sumaryList;
        }
    }
}