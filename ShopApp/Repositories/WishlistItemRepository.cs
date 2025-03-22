using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class WishlistItemRepository : Repository<WishlistItem>, IWishlistItemRepository
{
    public WishlistItemRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}