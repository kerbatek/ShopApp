using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
{
    public ShipmentRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}