using FluentResults;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Category;

namespace Ecommerce.DomainService.Interfaces
{
    public interface ICategoryDomainService
    {
        ReadCategoryDTO Add(CreateCategoryDTO createCategoryDto);
        IList<ReadCategoryDTO> List();
        Result Update(int id, UpdateCategoryDTO updateCategoryDto);
        ReadCategoryDTO GetById(int id);
        Result Delete(int id);
    }
}