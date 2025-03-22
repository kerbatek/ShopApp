using ShopApp.Models;

namespace ShopApp.Services;

public interface ICartItemService
{
    Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
    Task<CartItem> GetCartItemByIdAsync(int id);
    Task AddCartItemAsync(CartItem cartItem);
    Task UpdateCartItemAsync(CartItem cartItem);
    Task DeleteCartItemAsync(CartItem cartItem);
}