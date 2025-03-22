using ShopApp.Models;

namespace ShopApp.Services;

public interface IWishlistItemService
{
    Task<IEnumerable<WishlistItem>> GetAllWishlistItemsAsync();
    Task<WishlistItem> GetWishlistItemByIdAsync(int id);
    Task AddWishlistItemAsync(WishlistItem wishlistItem);
    Task UpdateWishlistItemAsync(WishlistItem wishlistItem);
    Task DeleteWishlistItemAsync(WishlistItem wishlistItem);
}