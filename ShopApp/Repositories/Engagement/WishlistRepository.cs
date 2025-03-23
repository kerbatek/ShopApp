using ShopApp.Data;
using ShopApp.Models.Engagement;
using ShopApp.Repositories.Engagement.Interfaces;

namespace ShopApp.Repositories.Engagement;

public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
{
    public WishlistRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}