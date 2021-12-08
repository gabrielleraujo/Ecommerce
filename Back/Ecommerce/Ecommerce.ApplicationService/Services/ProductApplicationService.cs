using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Product;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.DomainService.Interfaces;
using Ecommerce.ValidationService.Services;
using FluentResults;

namespace Ecommerce.ApplicationService.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductDomainService _productDomainService;
        private readonly ProductValidationService _productValidationService;

        public ProductApplicationService(IProductDomainService productDomainService, ProductValidationService productValidationService)
        {
            _productDomainService = productDomainService;
            _productValidationService = productValidationService;
        }

        public ReadProductDTO Add(CreateProductDTO createProductDto)
        {
            _productValidationService.Validate(createProductDto);

            return _productDomainService.Add(createProductDto);
        }

        public Result Update(int id, UpdateProductDTO updateProductDto)
        {
            return _productDomainService.Update(id, updateProductDto);
        }

        public Result Delete(int id)
        {
            return _productDomainService.Delete(id);
        }

        public IList<ReadProductDTO> List()
        {
            return _productDomainService.List();
        }

        public ReadProductDTO GetById(int id)
        {
            return _productDomainService.RecuperarPorId(id);
        }
    }
}