using ShopApp.Models.Core;

namespace ShopApp.Repositories.Core.Interfaces;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    Task<ApplicationUser?> FindByEmailAsync(string email);
}