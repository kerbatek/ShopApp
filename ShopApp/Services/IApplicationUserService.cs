using ShopApp.Models;

namespace ShopApp.Services;

public interface IApplicationUserService
{
    Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync();
    Task<ApplicationUser> GetApplicationUserByIdAsync(int id);
    Task AddApplicationUserAsync(ApplicationUser applicationUser);
    Task UpdateApplicationUserAsync(ApplicationUser applicationUser);
    Task DeleteApplicationUserAsync(ApplicationUser applicationUser);
}