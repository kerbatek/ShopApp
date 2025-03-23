using ShopApp.Models.Core;

namespace ShopApp.Services.Core.Interfaces;

public interface IApplicationRoleService
{
    Task<IEnumerable<ApplicationRole>> GetAllApplicationRolesAsync();
    Task<ApplicationRole> GetApplicationRoleByIdAsync(int id);
    Task AddApplicationRoleAsync(ApplicationRole applicationRole);
    Task UpdateApplicationRoleAsync(ApplicationRole applicationRole);
    Task DeleteApplicationRoleAsync(ApplicationRole applicationRole);
}