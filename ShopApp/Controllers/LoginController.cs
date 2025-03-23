using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Core;
using ShopApp.Services.Core.Interfaces;

namespace ShopApp.Controllers
{
    [Route("core")]
    public class LoginController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;

        public LoginController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        [HttpGet("login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _applicationUserService.AuthenticateUserAsync(email, password);
            return View(result);
        }
    }
}