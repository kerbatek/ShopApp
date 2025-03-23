using ShopApp.Data;
using ShopApp.Models.Core;
using ShopApp.Repositories.Core.Interfaces;

namespace ShopApp.Repositories.Core;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}