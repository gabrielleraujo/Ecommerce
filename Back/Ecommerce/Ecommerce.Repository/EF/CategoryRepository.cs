using Ecommerce.Data.Context;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository.EF
{
    public class CategoryRepository : ICategoryRepository
    {
        private EcommerceContext _context;

        public CategoryRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryDb = GetById(id);

            _context.Categories.Remove(categoryDb);
            _context.SaveChanges();
        }

        public IList<Category> List()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}