using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Repositories;

public class ApplicationRoleRepository : Repository<ApplicationRole>, IApplicationRoleRepository
{
    public ApplicationRoleRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}