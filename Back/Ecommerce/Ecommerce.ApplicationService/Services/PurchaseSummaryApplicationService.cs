using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.DomainService.Interfaces;

namespace Ecommerce.ApplicationService.Services
{
    public class PurchaseSummaryApplicationService : IPurchaseSummaryApplicationService
    {
        private readonly IPurchaseSummaryDomainService _purchaseSummaryDomainService;

        public PurchaseSummaryApplicationService(IPurchaseSummaryDomainService purchaseSummaryDomainService)
        {
            _purchaseSummaryDomainService = purchaseSummaryDomainService;
        }

        public void Add(IList<ReadPurchaseDTO> readPurchasesDto)
        {
            _purchaseSummaryDomainService.AddList(readPurchasesDto);     
        }

        public ReadPurchaseSummaryDTO GetById(DateTime data)
        {
            return _purchaseSummaryDomainService.GetById(data);
        }

        public IList<ReadPurchaseSummaryDTO> ListByDate()
        {
            return _purchaseSummaryDomainService.ListByDate();
        }
    }
}