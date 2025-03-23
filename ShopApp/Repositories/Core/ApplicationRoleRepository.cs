using ShopApp.Data;
using ShopApp.Models.Core;
using ShopApp.Repositories.Core.Interfaces;

namespace ShopApp.Repositories.Core;

public class ApplicationRoleRepository : Repository<ApplicationRole>, IApplicationRoleRepository
{
    public ApplicationRoleRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}