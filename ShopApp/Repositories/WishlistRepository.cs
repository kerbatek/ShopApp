using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
{
    public WishlistRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}