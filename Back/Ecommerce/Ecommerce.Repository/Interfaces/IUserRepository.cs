using Ecommerce.Data.Entities;
using System.Collections.Generic;

namespace Ecommerce.Repository.Interfaces
{
    public interface IUserRepository
    {
        void Add(User usuario);
        IList<User> List();
        User GetById(int id);
        void Update(User produto);
        void Delete(int id);
        public User GetByLogin(string username, string password);
        User GetByEmail(string email);
        int? GetAddressByUserId(int userId);
    }
}