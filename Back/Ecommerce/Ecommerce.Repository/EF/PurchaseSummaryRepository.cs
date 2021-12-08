using System;
using System.Linq;
using System.Collections.Generic;
using Ecommerce.Data.Context;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;

namespace Ecommerce.Repository.EF
{
    public class PurchaseSummaryRepository : IPurchaseSummaryRepository
    {
        private EcommerceContext _context;

        public PurchaseSummaryRepository(EcommerceContext context)
        {
            _context = context;
        }


        public void Add(IList<PurchaseSummary> sumary)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                foreach (var item in sumary)
                {
                    _context.Add(item);
                    _context.SaveChanges();
                }
                transaction.Commit();
            }
            catch (Exception e) { throw e; }
        }

        public IList<PurchaseSummary> GetByDate(DateTime data)
        {
            return _context.SummariesPurchases.Where(rc => rc.PurchaseDate == data).ToList();
        }

        public IList<PurchaseSummary> List()
        {
            return _context.SummariesPurchases.ToList();
        }

        public IOrderedEnumerable<IGrouping<DateTime, PurchaseSummary>> ListByDate()
        {
            var summaries = List();

            var summaryList = new List<PurchaseSummary>();

            var query =
                from summary in summaries
                group summary by summary.PurchaseDate into newGroup
                orderby newGroup.Key
                select newGroup;

            return query;
        }
    }
}