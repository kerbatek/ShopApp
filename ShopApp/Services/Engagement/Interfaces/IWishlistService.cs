using ShopApp.Models.Engagement;

namespace ShopApp.Services.Engagement.Interfaces;

public interface IWishlistService
{
    Task<IEnumerable<Wishlist>> GetAllWishlistsAsync();
    Task<Wishlist> GetWishlistByIdAsync(int id);
    Task AddWishlistAsync(Wishlist wishlist);
    Task UpdateWishlistAsync(Wishlist wishlist);
    Task DeleteWishlistAsync(Wishlist wishlist);
}