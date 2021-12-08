using FluentResults;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Product;

namespace Ecommerce.DomainService.Interfaces
{
    public interface IProductDomainService
    {
        ReadProductDTO Add(CreateProductDTO createProductDto);
        IList<ReadProductDTO> List();
        ReadProductDTO RecuperarPorId(int id);
        Result Update(int id, UpdateProductDTO updateProductDto);
        Result Delete(int id);
    }
}