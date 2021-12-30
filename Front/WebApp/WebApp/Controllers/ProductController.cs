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
        [Route("[controller]/Details/{id:int}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var productViewModel = await _productService.GetByIdAsync(id);
            return View(productViewModel);
        }


        [HttpGet]
        public IActionResult Registration() => View(new ProductRegistrationViewModel());

        [HttpPost]
        public async Task<IActionResult> Registration(ProductRegistrationViewModel productRegistrationViewModel)
        {
            await _productService.AddAsync(productRegistrationViewModel);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("[controller]/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result.IsFailed) { return NotFound(); }
            return  RedirectToAction("Registration");
        }
    }
}