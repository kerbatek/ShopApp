using ShopApp.Data;
using ShopApp.Models.Logistics;
using ShopApp.Repositories.Logistics.Interfaces;

namespace ShopApp.Repositories.Logistics;

public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
{
    public ShipmentRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}