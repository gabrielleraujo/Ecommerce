using Ecommerce.CrossCutting.DTO.Purchase;
using System.Collections.Generic;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface IPurchaseApplicationService
    {
        ReadPurchaseDTO Add(CreatePurchaseDTO novaCompraDto);
        IList<ReadPurchaseDTO> List();
        ReadPurchaseDTO GetById(int id);
        IList<ReadPurchaseDTO> GetHasNoSummary();
        IList<ReadPurchaseDTO> ListUserPurchases(int userId);
    }
}