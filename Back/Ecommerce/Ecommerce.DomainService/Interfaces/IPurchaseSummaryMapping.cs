using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.Data.Entities;

namespace Ecommerce.DomainService.Interfaces
{
    public interface IPurchaseSummaryMapping
    {
        PurchaseSummary Criate(ReadPurchaseDTO purchase, ReadPurchaseItemDTO item);
        ReadPurchaseSummaryDTO CreateReadPurchaseSummaryDTO(IList<PurchaseSummary> purchaseSummary, DateTime date);
    }
}