using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Core.Interfaces;

namespace ShopApp.Controllers
{
    [Route("core")]
    public class RegisterController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;

        public RegisterController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        
        [HttpGet("register")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string password, string firstName, string lastName, DateTime dateOfBirth)
        {
            var result = await _applicationUserService.RegisterUserAsync(email, password, firstName, lastName, dateOfBirth);
            return View(result);
        }
    }
}