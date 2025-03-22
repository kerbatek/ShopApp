using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class TrackingRepository : Repository<Tracking>, ITrackingRepository
{
    public TrackingRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}