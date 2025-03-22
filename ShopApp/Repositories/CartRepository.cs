using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}