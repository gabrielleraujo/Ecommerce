using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Category;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.ValidationService.Services;
using FluentResults;

namespace Ecommerce.ApplicationService.Services
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private readonly ICategoryDomainService _categoryDomainService;
        private readonly CategoryValidationService _categoryValidationService;

        public CategoryApplicationService(ICategoryDomainService categoryDomainService, CategoryValidationService categoryValidationService)
        {
            _categoryDomainService = categoryDomainService;
            _categoryValidationService = categoryValidationService;
        }

        public ReadCategoryDTO Add(CreateCategoryDTO createCategoryDTO)
        {
            _categoryValidationService.Validate(createCategoryDTO);

            return _categoryDomainService.Add(createCategoryDTO);
        }

        public Result Update(int id, UpdateCategoryDTO updateCategoryDto)
        {
            return _categoryDomainService.Update(id, updateCategoryDto);
        }

        public ReadCategoryDTO GetById(int id)
        {
            return _categoryDomainService.GetById(id);
        }

        public Result Delete(int id)
        {
            return _categoryDomainService.Delete(id);
        }

        public IList<ReadCategoryDTO> List()
        {
            return _categoryDomainService.List();
        }
    }
}