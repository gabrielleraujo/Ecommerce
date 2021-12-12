using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.ValidationService.Services;
using Ecommerce.DomainService.Interfaces;
using System;

namespace Ecommerce.ApplicationService.Services
{
    public class PurchaseApplicationService : IPurchaseApplicationService
    {
        private readonly IPurchaseDomainService _purchaseDomainService;
        private readonly PurchaseValidationService _purchaseValidationService;
        private readonly IUserDomainService _userDomainService;

        public PurchaseApplicationService(
            IPurchaseDomainService purchaseDomainService, 
            PurchaseValidationService purchaseValidationService,
            IUserDomainService userDomainService)
        {
            _purchaseDomainService = purchaseDomainService;
            _purchaseValidationService = purchaseValidationService;
            _userDomainService = userDomainService;
        }

        public ReadPurchaseDTO GetById(int id)
        {
            return _purchaseDomainService.GetById(id);
        }

        public IList<ReadPurchaseDTO> GetHasNoSummary()
        {
            return _purchaseDomainService.GetHasNoSummary();
        }

        public IList<ReadPurchaseDTO> List()
        {
            return _purchaseDomainService.List();
        }

        public IList<ReadPurchaseDTO> ListUserPurchases(int userId)
        {
            return _purchaseDomainService.ListUserPurchases(userId);
        }

        public ReadPurchaseDTO Add(CreatePurchaseDTO novaCompraDto)
        {
            _purchaseValidationService.Validate(novaCompraDto);

            ResolveAddress(novaCompraDto);

            var readCompraDto = _purchaseDomainService.Add(novaCompraDto);

            return readCompraDto;
        }

        private void ResolveAddress(CreatePurchaseDTO novaCompraDto)
        {
            if (novaCompraDto.AddressId <= 0)
            {
                var addressId = _userDomainService.GetAddress(novaCompraDto.UserId);

                if (addressId == null)
                {
                    throw new ArgumentException("No address was associated with the purchase.");
                }
                novaCompraDto.AddressId = addressId ?? 0;
            }
        }
    }
}