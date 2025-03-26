using Microsoft.AspNetCore.Identity;
using ShopApp.Models.Core;

namespace ShopApp.Services.Core.Interfaces;

public interface IApplicationUserService
{
    Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync();
    Task<ApplicationUser> GetApplicationUserByIdAsync(string id);
    //Task AddApplicationUserAsync(ApplicationUser applicationUser);
    //Task UpdateApplicationUserAsync(ApplicationUser applicationUser);
    //Task DeleteApplicationUserAsync(ApplicationUser applicationUser);
    Task<SignInResult> AuthenticateUserAsync(string email, string password);
    Task<IdentityResult> RegisterUserAsync(string email, string password, string firstName, string lastName, DateTime dateOfBirth);
    Task LogoutAsync();
}