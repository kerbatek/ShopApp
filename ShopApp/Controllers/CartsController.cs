using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.ECommerce.Interfaces;

namespace ShopApp.Controllers;

[Route("cart")]
public class CartsController : Controller
{
    private readonly ICartService _cartService;
    private readonly ICartItemService _cartItemService;

    public CartsController(ICartService cartService, ICartItemService cartItemService)
    {
        _cartService = cartService;
        _cartItemService = cartItemService;
    }
    
    [Authorize]
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var cart = await _cartService.GetCartByUserId(userId!);
        int cartId = cart.CartID;
        var vm = await _cartItemService.GetCartItemsByCartIdAsync(cartId);
        
        return View(vm);
    }
    
    [Authorize]
    [HttpPost("add", Name = "AddToCart")]
    public async Task<IActionResult> Add(int productId, int quantity)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _cartItemService.AddProductToCartAsync(productId, userId!, quantity);
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpPost("delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int cartItemId)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _cartItemService.DeleteCartItemByIdAsync(cartItemId, userId!);
            return RedirectToAction(nameof(Index));
        }
        
        return RedirectToAction(nameof(Index));
    }
    
}