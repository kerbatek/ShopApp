using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}