using Ecommerce.Data.Entities;
using System.Collections.Generic;

namespace Ecommerce.Repository.Interfaces
{
    public interface IColorRepository
    {
        void Add(Color cor);
        IList<Color> List();
        Color GetById(int id);
    }
}