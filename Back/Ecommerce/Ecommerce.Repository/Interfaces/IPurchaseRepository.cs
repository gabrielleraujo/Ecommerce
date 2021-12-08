using Ecommerce.Data.Entities;
using System.Collections.Generic;

namespace Ecommerce.Repository.Interfaces
{
    public interface IPurchaseRepository
    {
        void Add(Purchase purchase);
        IList<Purchase> List();
        Purchase GetById(int id);
        IList<Purchase> GetByUserId(int userId);
        IList<Purchase> GetHasNoSummary();
        void SetHasSummary(bool value, int id);
        IList<Purchase> ListUserPurchases(int userId);
    }
}