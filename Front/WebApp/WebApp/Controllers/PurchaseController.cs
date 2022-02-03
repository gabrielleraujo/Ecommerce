using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApp.Services.Interfaces;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> Registration(int productId, double unitPrice)
        {
            var result = await _purchaseService.AddAsync(productId, unitPrice);
            ViewBag.Result = result.IsSuccess ? "Success c:" : "Fail :c";
            return View();
        }
    }
}