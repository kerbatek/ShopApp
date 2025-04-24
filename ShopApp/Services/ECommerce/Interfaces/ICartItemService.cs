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
    Task<List<CartViewModel>> GetCartItemsByCartIDAsync(int cartID);
    Task AddProductToCartAsync(int productID, string userID, int quantity);
    Task DeleteCartItemByIDAsync(int cartItemID);
}