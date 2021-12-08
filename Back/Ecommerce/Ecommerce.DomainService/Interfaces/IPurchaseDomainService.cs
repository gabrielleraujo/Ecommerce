﻿using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;

namespace Ecommerce.DomainService.Interfaces
{
    public interface IPurchaseDomainService
    {
        ReadPurchaseDTO Add(CreatePurchaseDTO createPurchaseDto);
        IList<ReadPurchaseDTO> List();
        ReadPurchaseDTO GetById(int id);
        IList<ReadPurchaseDTO> GetHasNoSummary();
        void SetHasSummary(bool value, int id);
        IList<ReadPurchaseDTO> ListUserPurchases(int userId);
    }
}