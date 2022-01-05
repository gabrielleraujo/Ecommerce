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
            var readProductDto = await _productApiClient.GetProductsAsync();

            var productHomeViewModel = _mapper.Map<IList<ProductHomeViewModel>>(readProductDto);
            return new ProductListViewModel { Products = productHomeViewModel };
        }

        public async Task<ProductDetailsViewModel> AddAsync(ProductRegistrationViewModel productViewModel)
        {
            var createProductDto = _mapper.Map<CreateProductDTO>(productViewModel);

            var readProductDto = await _productApiClient.PostProductAsync(createProductDto);
            return _mapper.Map<ProductDetailsViewModel>(readProductDto);
        }

        public async Task<Result> DeleteAsync(int id) => await _productApiClient.DeleteProductAsync(id);

        public async Task<ProductDetailsViewModel> GetByIdAsync(int id)
        {
            var readProductDto = await _productApiClient.GetProductByIdAsync(id);
            return _mapper.Map<ProductDetailsViewModel>(readProductDto);
        }


        public async Task<IList<ProductDetailsViewModel>> ListAsync()
        {
            var readProductsDto = await _productApiClient.GetProductsAsync();
            return _mapper.Map<IList<ProductDetailsViewModel>>(readProductsDto); ;
        }

        public async Task<IList<CategoryDetailsViewModel>> ListCategoriesAsync()
        {
            var readCategoriesDto = await _productApiClient.GetCategoriesAsync();
            return _mapper.Map<IList<CategoryDetailsViewModel>>(readCategoriesDto); ;
        }

        public async Task<IList<ColorDetailsViewModel>> ListColorsAsync()
        {
            var readColorsDto = await _productApiClient.GetColorsAsync();
            return _mapper.Map<IList<ColorDetailsViewModel>>(readColorsDto); ;
        }

        public async Task<IList<SizeDetailsViewModel>> ListSizesAsync()
        {
            var readSizesDto = await _productApiClient.GetSizesAsync();
            return _mapper.Map<IList<SizeDetailsViewModel>>(readSizesDto); ;
        }
    }
}