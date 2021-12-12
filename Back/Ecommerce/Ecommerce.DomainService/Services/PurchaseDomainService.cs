using AutoMapper;
using Ecommerce.Data.Entities;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.Repository.Interfaces;
using Ecommerce.CrossCutting.DTO.Purchase;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DomainService.Services
{
    public class PurchaseDomainService : IPurchaseDomainService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseDomainService(IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public IList<ReadPurchaseDTO> List()
        {
            IList<Purchase> purchases = _purchaseRepository.List();

            return _mapper.Map<IList<ReadPurchaseDTO>>(purchases);
        }

        public ReadPurchaseDTO GetById(int id)
        {
            var purchase = _purchaseRepository.GetById(id);

            return _mapper.Map<ReadPurchaseDTO>(purchase);
        }

        public IList<ReadPurchaseDTO> GetHasNoSummary()
        {
            var purchases = _purchaseRepository.GetHasNoSummary();

            return _mapper.Map<IList<ReadPurchaseDTO>>(purchases);
        }

        public ReadPurchaseDTO Add(CreatePurchaseDTO createPurchaseDto)
        {
            var purchase = _mapper.Map<Purchase>(createPurchaseDto);
            purchase.Price = CalculateTotalPrice(createPurchaseDto.Products);

            _purchaseRepository.Add(purchase);

            return _mapper.Map<ReadPurchaseDTO>(purchase);
        }

        private double CalculateTotalPrice(IList<CreatePurchaseItemDTO> purchaseItemsDto)
        {
            return purchaseItemsDto.Sum(x => x.Quantity * x.UnitPrice);
        }

        public IList<ReadPurchaseDTO> ListUserPurchases(int userId)
        {
            var purchases = _purchaseRepository.ListUserPurchases(userId);

            return _mapper.Map<IList<ReadPurchaseDTO>>(purchases);
        }

        public void SetHasSummary(bool value, IList<ReadPurchaseDTO> readPurchasesDto)
        {
            var purchases = _mapper.Map<IList<Purchase>>(readPurchasesDto);

            foreach (var item in purchases)
            {
                item.HasSummary = value;
            }
            _purchaseRepository.Update(purchases);
        }
    }
}