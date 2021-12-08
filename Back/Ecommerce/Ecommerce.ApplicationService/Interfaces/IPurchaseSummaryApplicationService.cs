using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface IPurchaseSummaryApplicationService
    {
        void Add(IList<ReadPurchaseDTO> readPurchaseDto);
        ReadPurchaseSummaryDTO GetById(DateTime date);
        IList<ReadPurchaseSummaryDTO> ListByDate();
    }
}