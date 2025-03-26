using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models.Core; 
using ShopApp.Services.Core.Interfaces;

namespace ShopApp.Services.Core
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetApplicationUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            return user;
        }

        public async Task<IdentityResult> RegisterUserAsync(string email, string password, string firstName, string lastName, DateTime dateOfBirth)
        {
            if (email.Length < 4 || password.Length < 4 || firstName.Length < 4 || lastName.Length < 4 ||
                dateOfBirth.Year < 1900)
            {
                return IdentityResult.Failed();
            }
            
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,   
                LastName = lastName,
                DateOfBirth = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc),

            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task<SignInResult> AuthenticateUserAsync(string email, string password)
        {
            if (email.Length < 4 || password.Length < 4)
            {
                return SignInResult.Failed;
            }
            return await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
