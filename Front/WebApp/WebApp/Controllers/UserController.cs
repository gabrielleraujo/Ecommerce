using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using WebApp.Services.Interfaces;
using WebApp.ViewModels;

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
        public IActionResult Registration() => View(new UserRegistrationViewModel());

        [HttpPost]
        public async Task<IActionResult> Registration(UserRegistrationViewModel user)
        {
            await _userService.AddAsync(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _userService.ListAsync();
            return View(users);
        }

        [HttpGet]
        [Route("[controller]/Details/{id:int}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(user);
        }

        [HttpGet]
        [Route("[controller]/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result.IsFailed) { return NotFound(); }
            return RedirectToAction("Index");
        }
    }
}