using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Core.Interfaces;
using ShopApp.ViewModels;

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
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("registerPage", model);
        }

        var result = await _applicationUserService.RegisterUserAsync(model);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("registerPage", model);
        }

        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    [HttpPost("logout")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _applicationUserService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }
    
}