using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models.ECommerce;
using ShopApp.Repositories.ECommerce.Interfaces;

namespace ShopApp.Repositories.ECommerce;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<Cart?> GetCartByUserIdAsync(string userID)
    {
        return await DbSet
            .FirstOrDefaultAsync(c=>c.UserID == userID);
    }
}