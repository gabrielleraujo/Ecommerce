using Ecommerce.Data.Context;
using Ecommerce.Data.Entities;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repository.EF
{
    public class UserRepository : IUserRepository
    {
        private EcommerceContext _context;

        public UserRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Add(User usuario)
        {
            _context.Users.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(User usuario)
        {
            _context.Users.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuarioDto = GetById(id);

            _context.Users.Remove(usuarioDto);
            _context.SaveChanges();
        }

        public IList<User> List()
        {
            return _context.Users
                .Include(u => u.Address)
                .ToList();
        }

        public User GetById(int id)
        {
            return _context.Users
                .Include(u => u.Address)
                .FirstOrDefault(u => u.Id == id);
        }

        public User GetByLogin(string username, string password)
        {
            return _context.Users
                .Include(u => u.Address)
                .FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public int? GetAddress(int userId)
        {
            return GetById(userId).AddressId;
        }
    }
}