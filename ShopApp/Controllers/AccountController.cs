using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopApp.Services.Core.Interfaces;

namespace ShopApp.Controllers;
[Route("core")]
public class AccountController : Controller
{
    private readonly IApplicationUserService _applicationUserService;

    public AccountController(IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService;
    }
    
    [HttpGet("login")]
    public IActionResult LoginPage()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _applicationUserService.AuthenticateUserAsync(email, password);
        return View(result);
    }
    
    [HttpGet("register")]
    public IActionResult RegisterPage()
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