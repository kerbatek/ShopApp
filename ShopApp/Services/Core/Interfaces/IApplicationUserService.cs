using ShopApp.Models.Core;

namespace ShopApp.Services.Core.Interfaces;

public interface IApplicationUserService
{
    Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync();
    Task<ApplicationUser> GetApplicationUserByIdAsync(int id);
    Task AddApplicationUserAsync(ApplicationUser applicationUser);
    Task UpdateApplicationUserAsync(ApplicationUser applicationUser);
    Task DeleteApplicationUserAsync(ApplicationUser applicationUser);
    Task<Dictionary<string, string>> AuthenticateUserAsync(string email, string password);
    Task<Dictionary<string, string>> RegisterUserAsync(string email, string password, string firstName, string lastName, DateTime dateOfBirth);

}