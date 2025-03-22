using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}