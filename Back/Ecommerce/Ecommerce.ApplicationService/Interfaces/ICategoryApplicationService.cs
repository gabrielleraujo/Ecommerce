using Ecommerce.CrossCutting.DTO.Category;
using FluentResults;
using System.Collections.Generic;

namespace Ecommerce.ApplicationService.Interfaces
{
    public interface ICategoryApplicationService
    {
        ReadCategoryDTO Add(CreateCategoryDTO createCategoryDTO);
        IList<ReadCategoryDTO> List();
        ReadCategoryDTO GetById(int id);
        Result Update(int id, UpdateCategoryDTO updateCategoryDTO);
        Result Delete(int id);
    }
}