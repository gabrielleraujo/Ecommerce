using Ecommerce.Data.Entities;
using System.Collections.Generic;

namespace Ecommerce.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        void Add(Product product);
        IList<Product> List();
        Product GetById(int id);
        void Update(Product product);
        void Delete(int id);
    }
}