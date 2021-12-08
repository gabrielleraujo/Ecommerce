using AutoMapper;
using System.Collections.Generic;
using Ecommerce.Repository.Interfaces;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.CrossCutting.DTO.Category;
using Ecommerce.Data.Entities;
using FluentResults;

namespace Ecommerce.DomainService.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryDomainService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public ReadCategoryDTO Add(CreateCategoryDTO createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _categoryRepository.Add(category);

            return _mapper.Map<ReadCategoryDTO>(category);
        }

        public Result Update(int id, UpdateCategoryDTO updateCategoryDto)
        {
            var category = _categoryRepository.GetById(id);

            if (category == null) { return Result.Fail("Product not found"); }

            _mapper.Map(updateCategoryDto, category);
            _categoryRepository.Update(category);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            var categoria = _categoryRepository.GetById(id);

            if (categoria == null) { return Result.Fail("Product not found"); }

            _categoryRepository.Delete(id);

            return Result.Ok();
        }

        public IList<ReadCategoryDTO> List()
        {
            var categories = _categoryRepository.List();

            return categories != null ? _mapper.Map<IList<ReadCategoryDTO>>(categories) : null;
        }

        public ReadCategoryDTO GetById(int id)
        {
            var category = _categoryRepository.GetById(id);

            return category != null ? _mapper.Map<ReadCategoryDTO>(category) : null;
        }
    }
}