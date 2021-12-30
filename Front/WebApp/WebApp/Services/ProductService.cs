using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using Ecommerce.CrossCutting.DTO.Product;
using WebApp.Clients.Interfaces;
using WebApp.ViewModels;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IMapper _mapper;

        public ProductService(IProductApiClient productApiClient, IMapper mapper)
        {
            _productApiClient = productApiClient;
            _mapper = mapper;
        }

        public async Task<ProductListViewModel> IndexAsync()
        {
            var readProdutoDto = await _productApiClient.GetProductsAsync();

            var productHomeViewModel = _mapper.Map<IList<ProductHomeViewModel>>(readProdutoDto);
            return new ProductListViewModel { Products = productHomeViewModel };
        }

        public async Task<IList<ProductDetailsViewModel>> ListAsync()
        {
            var readProdutoDto = await _productApiClient.GetProductsAsync();
            return _mapper.Map<IList<ProductDetailsViewModel>>(readProdutoDto); ;
        }

        public async Task<ProductDetailsViewModel> GetByIdAsync(int id)
        {
            var readProdutoDto = await _productApiClient.GetProductByIdAsync(id);
            return _mapper.Map<ProductDetailsViewModel>(readProdutoDto);
        }

        public async Task<ProductDetailsViewModel> AddAsync(ProductRegistrationViewModel produtoViewModel)
        {
            var createProductDto = _mapper.Map<CreateProductDTO>(produtoViewModel);

            var readProdutoDto = await _productApiClient.PostProductAsync(createProductDto);
            return _mapper.Map<ProductDetailsViewModel>(readProdutoDto);
        }

        public async Task<Result> DeleteAsync(int id) => await _productApiClient.DeleteProductAsync(id);
    }
}