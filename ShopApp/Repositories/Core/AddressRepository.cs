using ShopApp.Data;
using ShopApp.Models.Core;
using ShopApp.Repositories.Core.Interfaces;

namespace ShopApp.Repositories.Core;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}