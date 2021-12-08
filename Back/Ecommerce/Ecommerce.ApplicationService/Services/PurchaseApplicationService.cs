using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.ValidationService.Services;
using Ecommerce.DomainService.Interfaces;
using FluentResults;

namespace Ecommerce.ApplicationService.Services
{
    public class PurchaseApplicationService : IPurchaseApplicationService
    {
        private readonly IPurchaseDomainService _purchaseDomainService;
        private readonly PurchaseValidationService _purchaseValidationService;
        private readonly IPurchaseSummaryApplicationService _purchaseSummaryApplicationService;

        public PurchaseApplicationService(
            IPurchaseDomainService purchaseDomainService, 
            PurchaseValidationService purchaseValidationService,
            IPurchaseSummaryApplicationService purchaseSummaryApplicationService)
        {
            _purchaseDomainService = purchaseDomainService;
            _purchaseValidationService = purchaseValidationService;
            _purchaseSummaryApplicationService = purchaseSummaryApplicationService;
        }

        public IList<ReadPurchaseDTO> List()
        {
            return _purchaseDomainService.List();
        }

        public ReadPurchaseDTO GetById(int id)
        {
            return _purchaseDomainService.GetById(id);
        }

        public ReadPurchaseDTO Add(CreatePurchaseDTO novaCompraDto)
        {
            _purchaseValidationService.Validate(novaCompraDto);

            var readCompraDto = _purchaseDomainService.Add(novaCompraDto);

            return readCompraDto;
        }

        public IList<ReadPurchaseDTO> GetHasNoSummary()
        {
            return _purchaseDomainService.GetHasNoSummary();
        }

        public Result MakeSummary()
        {
            var purchases = GetHasNoSummary();
            if (purchases.Count == 0)
            {
                return Result.Fail("There are no purchases to summarize at the moment.");
            }
            _purchaseSummaryApplicationService.Add(purchases);
            return Result.Ok();
        }

        public IList<ReadPurchaseDTO> ListUserPurchases(int userId)
        {
            return _purchaseDomainService.ListUserPurchases(userId);
        }
    }
}