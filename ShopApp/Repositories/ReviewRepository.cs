using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}