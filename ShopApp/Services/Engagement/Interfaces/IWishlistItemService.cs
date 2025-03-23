using ShopApp.Models.Engagement;

namespace ShopApp.Services.Engagement.Interfaces;

public interface IWishlistItemService
{
    Task<IEnumerable<WishlistItem>> GetAllWishlistItemsAsync();
    Task<WishlistItem> GetWishlistItemByIdAsync(int id);
    Task AddWishlistItemAsync(WishlistItem wishlistItem);
    Task UpdateWishlistItemAsync(WishlistItem wishlistItem);
    Task DeleteWishlistItemAsync(WishlistItem wishlistItem);
}