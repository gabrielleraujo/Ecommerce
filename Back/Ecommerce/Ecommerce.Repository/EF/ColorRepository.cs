using Ecommerce.Data.Context;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository.EF
{
    public class ColorRepository : IColorRepository
    {
        private EcommerceContext _context;

        public ColorRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Add(Color color)
        {
            _context.Colors.Add(color);
            _context.SaveChanges();
        }

        public IList<Color> List()
        {
            return _context.Colors.ToList();
        }

        public Color GetById(int id)
        {
            return _context.Colors.FirstOrDefault(c => c.Id == id);
        }
    }
}