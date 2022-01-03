using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.DomainService.Interfaces;
using FluentResults;

namespace Ecommerce.ApplicationService.Services
{
    public class PurchaseSummaryApplicationService : IPurchaseSummaryApplicationService
    {
        private readonly IPurchaseSummaryDomainService _purchaseSummaryDomainService;
        private readonly IPurchaseDomainService _purchaseDomainService;

        public PurchaseSummaryApplicationService(
            IPurchaseSummaryDomainService purchaseSummaryDomainService,
            IPurchaseDomainService purchaseDomainService)
        {
            _purchaseSummaryDomainService = purchaseSummaryDomainService;
            _purchaseDomainService = purchaseDomainService;
        }

        public ReadPurchaseSummaryDTO GetById(DateTime data)
        {
            return _purchaseSummaryDomainService.GetById(data);
        }

        public IList<ReadPurchaseSummaryDTO> ListByDate()
        {
            return _purchaseSummaryDomainService.ListByDate();
        }

        public Result Build()
        {
            var readPurchasesDto = _purchaseDomainService.GetHasNoSummary();

            if (readPurchasesDto.Count == 0) { return Result.Fail("There are no purchases to summarize at the moment."); }

            _purchaseSummaryDomainService.AddList(readPurchasesDto);

            _purchaseDomainService.SetHasSummary(true, readPurchasesDto);

            return Result.Ok();
        }
    }
}