using ShopApp.Models;

namespace ShopApp.Services;

public interface IWishlistService
{
    Task<IEnumerable<Wishlist>> GetAllWishlistsAsync();
    Task<Wishlist> GetWishlistByIdAsync(int id);
    Task AddWishlistAsync(Wishlist wishlist);
    Task UpdateWishlistAsync(Wishlist wishlist);
    Task DeleteWishlistAsync(Wishlist wishlist);
}