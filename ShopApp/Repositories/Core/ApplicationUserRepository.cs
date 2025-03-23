using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models.Core;
using ShopApp.Repositories.Core.Interfaces;

namespace ShopApp.Repositories.Core;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(AppDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<ApplicationUser?> FindByEmailAsync(string email)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Email == email);
    }
}