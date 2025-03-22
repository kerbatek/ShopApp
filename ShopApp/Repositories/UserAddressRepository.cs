using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository
{
    public UserAddressRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}