using ShopApp.Models.ECommerce;

namespace ShopApp.Services.ECommerce.Interfaces;

public interface ICartItemService
{
    Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
    Task<CartItem> GetCartItemByIdAsync(int id);
    Task AddCartItemAsync(CartItem cartItem);
    Task UpdateCartItemAsync(CartItem cartItem);
    Task DeleteCartItemAsync(CartItem cartItem);
}