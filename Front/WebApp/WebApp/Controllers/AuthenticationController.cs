using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Services.Interfaces;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpGet]
        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await _authService.AuthenticateAsync(loginViewModel);

            if (result.IsFailed)
            {
                TempData["Autenticated"] = result.Reasons[0].Message;
                return View(loginViewModel);
            }

            return RedirectToAction("Index", "User");
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Index", "Product");
        }
    }
}