using ShopApp.Data;
using ShopApp.Models.Logistics;
using ShopApp.Repositories.Logistics.Interfaces;

namespace ShopApp.Repositories.Logistics;

public class TrackingRepository : Repository<Tracking>, ITrackingRepository
{
    public TrackingRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}