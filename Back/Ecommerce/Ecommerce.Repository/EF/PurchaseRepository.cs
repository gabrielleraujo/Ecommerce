using Ecommerce.Data.Context;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ecommerce.Repository.EF
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private EcommerceContext _context;

        public PurchaseRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Add(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
        }

        public void SetHasSummary(bool value, int id)
        {
            _context.Purchases
                .Where(p => p.Id == id)
                .FirstOrDefault()
                .HasSummary = value;

            _context.SaveChanges();
        }

        public IList<Purchase> ListUserPurchases(int userId)
        {
            return IncludeProperties(p => p.UserId == userId).ToList();
        }

        public IList<Purchase> List()
        {
            return IncludeProperties().ToList();
        }

        public Purchase GetById(int id)
        {
            return IncludeProperties(p => p.Id == id).FirstOrDefault();
        }

        public IList<Purchase> GetByUserId(int userId)
        {
            return IncludeProperties(p => p.UserId == userId).ToList();
        }

        public IList<Purchase> GetHasNoSummary()
        {
            return IncludeProperties(p => p.HasSummary == false).ToList();
        }

        
        private IIncludableQueryable<Purchase, Size> IncludeProperties(Expression<Func<Purchase, bool>> myDelegate)
        {
            return _context.Purchases
                            .Where(myDelegate)

                            .Include(p => p.User)
                            .Include(p => p.Address)

                            .Include(p => p.Products)
                            .ThenInclude(x => x.Product)
                            .ThenInclude(productItem => productItem.Category)

                            .Include(x => x.Products)
                            .ThenInclude(x => x.Product)
                            .ThenInclude(productItem => productItem.Color)

                            .Include(x => x.Products)
                            .ThenInclude(x => x.Product)
                            .ThenInclude(productItem => productItem.Size);
        }
        private IIncludableQueryable<Purchase, Size> IncludeProperties()
        {
            return _context.Purchases
                            .Include(p => p.User)
                            .Include(p => p.Address)

                            .Include(p => p.Products)
                            .ThenInclude(x => x.Product)
                            .ThenInclude(productItem => productItem.Category)

                            .Include(x => x.Products)
                            .ThenInclude(x => x.Product)
                            .ThenInclude(productItem => productItem.Color)

                            .Include(x => x.Products)
                            .ThenInclude(x => x.Product)
                            .ThenInclude(productItem => productItem.Size);
        }
    }
}