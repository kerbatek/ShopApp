using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Models.ECommerce;
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
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Redirect("core/login");
        }
        var cart = await _cartService.GetUserCartAsync(userId);
        int cartID = cart.CartID;
        var vm = await _cartItemService.GetCartItemsByCartIDAsync(cartID);
        return View(vm);
    }

    [HttpPost("add", Name = "AddToCart")]
    public async Task<IActionResult> Add(int productID, int quantity)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Redirect("core/login");
        }
        await _cartItemService.AddProductToCartAsync(productID, userId, quantity);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int cartItemID)
    {
        if (ModelState.IsValid)
        {
            await _cartItemService.DeleteCartItemByIDAsync(cartItemID);

        }
        return RedirectToAction(nameof(Index));
    }
    
}