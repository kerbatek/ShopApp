using ShopApp.Data;
using ShopApp.Models.Core;
using ShopApp.Repositories.Core.Interfaces;

namespace ShopApp.Repositories.Core;

public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository
{
    public UserAddressRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}