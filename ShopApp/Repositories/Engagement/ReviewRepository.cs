using ShopApp.Data;
using ShopApp.Models.Engagement;
using ShopApp.Repositories.Engagement.Interfaces;

namespace ShopApp.Repositories.Engagement;

public class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}