using AutoMapper;
using FluentResults;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Clients.Interfaces;
using Ecommerce.CrossCutting.DTO.Product;
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

        public async Task<HomeViewModel> IndexAsync()
        {
            var produtos = await _productApiClient.GetProductsAsync();

            IList<ProductHomeViewModel> produtosHomeViewModel = _mapper.Map<IList<ProductHomeViewModel>>(produtos);

            var model = new HomeViewModel { Products = produtosHomeViewModel };

            return model;
        }

        public async Task<IList<ProductDetailsViewModel>> ListAsync()
        {
            var produtos = await _productApiClient.GetProductsAsync();
            return _mapper.Map<IList<ProductDetailsViewModel>>(produtos); ;
        }

        public async Task<ProductDetailsViewModel> GetByIdAsync(int id)
        {
            ReadProductDTO produto = await _productApiClient.GetProductByIdAsync(id);
            return _mapper.Map<ProductDetailsViewModel>(produto);
        }

        public async Task<ProductDetailsViewModel> AddAsync(ProductRegistrationViewModel produtoViewModel)
        {
            CreateProductDTO produto = _mapper.Map<CreateProductDTO>(produtoViewModel);

            //JsonConvert.SerilizeObject() will convert your custom class to JSON
            StringContent content = new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8, "application/json");

            var readProdutoDto = await _productApiClient.PostProductAsync(content);
            return _mapper.Map<ProductDetailsViewModel>(readProdutoDto);
        }

        public async Task<Result> DeleteAsync(int id)
        {
            return await _productApiClient.DeleteProductAsync(id);
        }
    }
}