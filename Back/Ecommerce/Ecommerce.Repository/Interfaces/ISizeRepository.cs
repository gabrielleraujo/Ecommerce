using Ecommerce.Data.Entities;
using System.Collections.Generic;

namespace Ecommerce.Repository.Interfaces
{
    public interface ISizeRepository
    {
        void Adicionar(Size tamanho);
        IList<Size> Listar();
        Size RecuperarPorId(int id);
    }
}