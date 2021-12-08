using System;
using AutoMapper;
using FluentResults;
using System.Collections.Generic;
using Ecommerce.Data.Entities;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.Repository.Interfaces;
using Ecommerce.CrossCutting.DTO.Product;

namespace Ecommerce.DomainService.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProdutoRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductDomainService(IProdutoRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ReadProductDTO Add(CreateProductDTO createProductDto)
        {
            if (createProductDto.CategoryId == 0) { throw new ArgumentException("Category not found."); }

            var product = _mapper.Map<Product>(createProductDto);
            _productRepository.Add(product);

            return _mapper.Map<ReadProductDTO>(product);
        }

        public Result Update(int id, UpdateProductDTO updateProductDto)
        {
            var product = _productRepository.GetById(id);

            if (product == null) { return Result.Fail("Product not found"); }

            _mapper.Map(updateProductDto, product);
            _productRepository.Update(product);

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null) { return Result.Fail("Product not found"); }

            _productRepository.Delete(id);

            return Result.Ok();
        }

        public IList<ReadProductDTO> List()
        {
            var products = _productRepository.List();

            return products != null ? _mapper.Map<IList<ReadProductDTO>>(products) : null;
        }

        public ReadProductDTO RecuperarPorId(int id)
        {
            var product = _productRepository.GetById(id);

            return product != null ? _mapper.Map<ReadProductDTO>(product) : null;
        }
    }
}