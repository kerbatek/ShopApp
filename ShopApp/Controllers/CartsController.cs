using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize]
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var cart = await _cartService.GetUserCartAsync(userId);
        int cartID = cart.CartID;
        var vm = await _cartItemService.GetCartItemsByCartIDAsync(cartID);
        
        return View(vm);
    }
    
    [Authorize]
    [HttpPost("add", Name = "AddToCart")]
    public async Task<IActionResult> Add(int productID, int quantity)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        try
        {
            await _cartItemService.AddProductToCartAsync(productID, userId, quantity);
            return RedirectToAction(nameof(Index));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidOperationException)
        {
            return BadRequest();
        }
    }

    [Authorize]
    [HttpPost("delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int cartItemID)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _cartItemService.DeleteCartItemByIDAsync(cartItemID, userId);
                return RedirectToAction(nameof(Index));
            }
            
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            
            catch(UnauthorizedAccessException)
            {
                return Forbid();
            }
        }
        
        return RedirectToAction(nameof(Index));
    }
    
}