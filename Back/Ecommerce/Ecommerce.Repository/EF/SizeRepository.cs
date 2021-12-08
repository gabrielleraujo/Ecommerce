using Ecommerce.Data.Context;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository.EF
{
    public class SizeRepository : ISizeRepository
    {
        private EcommerceContext _context;

        public SizeRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Adicionar(Size tamanho)
        {
            _context.Sizes.Add(tamanho);
            _context.SaveChanges();
        }

        public IList<Size> Listar()
        {
            return _context.Sizes.ToList();
        }

        public Size RecuperarPorId(int id)
        {
            return _context.Sizes.FirstOrDefault(t => t.Id == id);
        }
    }
}