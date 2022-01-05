using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Services.Interfaces;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => View(await _productService.IndexAsync());

        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            var categories = await _productService.ListCategoriesAsync();
            var colors = await _productService.ListColorsAsync();
            var sizes = await _productService.ListSizesAsync();

            return View(new ProductRegistrationViewModel(categories, colors, sizes)); 
        }

        [HttpPost]
        public async Task<IActionResult> Registration(ProductRegistrationViewModel product)
        {
            await _productService.AddAsync(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[controller]/Details/{id:int}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(product);
        }

        [HttpGet]
        [Route("[controller]/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result.IsFailed) { return NotFound(); }
            return RedirectToAction("Index");
        }
    }
}