using Ecommerce.Data.Entities;
using System.Collections.Generic;

namespace Ecommerce.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category categoria);
        IList<Category> List();
        Category GetById(int id);
        void Update(Category categoria);
        void Delete(int id);
    }
}