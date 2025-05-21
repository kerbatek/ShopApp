using ShopApp.Models.ECommerce;
using ShopApp.ViewModels;

namespace ShopApp.Services.ECommerce.Interfaces;

public interface ICartItemService
{
    Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
    Task<CartItem> GetCartItemByIdAsync(int id);
    Task AddCartItemAsync(CartItem cartItem);
    Task UpdateCartItemAsync(CartItem cartItem);
    Task DeleteCartItemAsync(CartItem cartItem);
    Task<List<CartViewModel>> GetCartItemsByCartIdAsync(int cartId);
    Task AddProductToCartAsync(int productId, string userId, int quantity);
    Task DeleteCartItemByIdAsync(int cartItemId, string userId);
}