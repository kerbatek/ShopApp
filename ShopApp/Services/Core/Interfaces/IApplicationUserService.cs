using Microsoft.AspNetCore.Identity;
using ShopApp.Models.Core;
using ShopApp.ViewModels;

namespace ShopApp.Services.Core.Interfaces;

public interface IApplicationUserService
{
    Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync();
    Task<ApplicationUser> GetApplicationUserByIdAsync(string id);
    Task<SignInResult> AuthenticateUserAsync(string email, string password);
    Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
    Task LogoutAsync();
}