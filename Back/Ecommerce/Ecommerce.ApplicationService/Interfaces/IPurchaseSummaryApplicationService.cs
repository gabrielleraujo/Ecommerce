using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Purchase;
using FluentResults;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface IPurchaseSummaryApplicationService
    {
        Result Build();
        ReadPurchaseSummaryDTO GetById(DateTime date);
        IList<ReadPurchaseSummaryDTO> ListByDate();
    }
}