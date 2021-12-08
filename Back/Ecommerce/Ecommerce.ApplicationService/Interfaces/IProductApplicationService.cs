using FluentResults;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Product;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface IProductApplicationService
    {
        ReadProductDTO Add(CreateProductDTO createProductDto);
        IList<ReadProductDTO> List();
        ReadProductDTO GetById(int id);
        Result Update(int id, UpdateProductDTO updateProductDto);
        Result Delete(int id);
    }
}