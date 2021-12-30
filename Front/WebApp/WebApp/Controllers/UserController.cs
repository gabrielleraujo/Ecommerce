using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApp.Services.Interfaces;
using WebApp.ViewModels;
using FluentResults;

namespace WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> Index() => View(await _userService.IndexAsync());


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var userViewModel = await _userService.ListAsync();
            return View(userViewModel);
        }


        [HttpGet]
        [Route("[controller]/Details/{id:int}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var userViewModel = await _userService.GetByIdAsync(id);
            return View(userViewModel);
        }


        [HttpGet]
        public IActionResult Registration() => View(new UserRegistrationViewModel());

        [HttpPost]
        public async Task<IActionResult> Registration(UserRegistrationViewModel userRegistrationViewModel)
        {
            await _userService.AddAsync(userRegistrationViewModel);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("[controller]/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result.IsFailed) { return NotFound(); }
            return  RedirectToAction("Registration");
        }
    }
}