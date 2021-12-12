using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;

namespace Ecommerce.DomainService.Interfaces
{
    public interface IPurchaseSummaryDomainService
    {
        void AddList(IList<ReadPurchaseDTO> readListPurchaseDto);
        ReadPurchaseSummaryDTO GetById(DateTime date);
        IList<ReadPurchaseSummaryDTO> ListByDate();
    }
}