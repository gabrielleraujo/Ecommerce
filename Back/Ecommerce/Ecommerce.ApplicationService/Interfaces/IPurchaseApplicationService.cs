using Ecommerce.CrossCutting.DTO.Purchase;
using FluentResults;
using System.Collections.Generic;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface IPurchaseApplicationService
    {
        ReadPurchaseDTO Add(CreatePurchaseDTO novaCompraDto);
        IList<ReadPurchaseDTO> List();
        ReadPurchaseDTO GetById(int id);
        IList<ReadPurchaseDTO> GetHasNoSummary();
        Result MakeSummary();
        IList<ReadPurchaseDTO> ListUserPurchases(int userId);
    }
}