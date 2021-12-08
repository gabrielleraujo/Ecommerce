using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.Data.Entities;

namespace Ecommerce.Repository.Interfaces
{
    public interface IPurchaseSummaryRepository
    {
        void Add(IList<PurchaseSummary> sumary);

        IList<PurchaseSummary> GetByDate(DateTime data);

        IList<PurchaseSummary> List();
        IOrderedEnumerable<IGrouping<DateTime, PurchaseSummary>> ListByDate();
    }
}