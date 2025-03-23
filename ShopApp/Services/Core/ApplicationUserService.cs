using ShopApp.Models.Core;
using ShopApp.Repositories.Core.Interfaces;
using ShopApp.Services.Core.Interfaces;

namespace ShopApp.Services.Core;

public class ApplicationUserService : IApplicationUserService
{
    private readonly IApplicationUserRepository _applicationUserRepository;

    public ApplicationUserService(IApplicationUserRepository applicationUserRepository)
    {
        _applicationUserRepository = applicationUserRepository;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync()
    {
        return await _applicationUserRepository.GetAllAsync();
    }

    public async Task<ApplicationUser> GetApplicationUserByIdAsync(int id)
    {
        return await _applicationUserRepository.GetByIdAsync(id);
    }

    public async Task AddApplicationUserAsync(ApplicationUser applicationUser)
    {
        await _applicationUserRepository.AddAsync(applicationUser);
        await _applicationUserRepository.SaveChangesAsync();
    }

    public async Task UpdateApplicationUserAsync(ApplicationUser applicationUser)
    {
        await _applicationUserRepository.UpdateAsync(applicationUser);
        await _applicationUserRepository.SaveChangesAsync();
    }

    public async Task DeleteApplicationUserAsync(ApplicationUser applicationUser)
    {
        await _applicationUserRepository.DeleteAsync(applicationUser);
        await _applicationUserRepository.SaveChangesAsync();
    }

    public async Task<Dictionary<string, string>> AuthenticateUserAsync(string email, string password)
    {
        var user = await _applicationUserRepository.FindByEmailAsync(email);
        if (user == null)
        {
            return new Dictionary<string, string>
            {
                {"error", "User not found"},
            };
        }

        if (password == user.PasswordHash)
        {
            return new Dictionary<string, string>
            {
                {"FirstName", user.FirstName},
                {"LastName", user.LastName},
            };
        }
        return new Dictionary<string, string>
        {
            {"error", "Authentication failed"},
        };
    }

    public async Task<Dictionary<string, string>> RegisterUserAsync(string email, string password, string firstName,
        string lastName, DateTime dateOfBirth)
    {
        if (await _applicationUserRepository.FindByEmailAsync(email) != null)
        {
            return new Dictionary<string, string>
            {
                {"error", "User  with this email already exists"},
            };
        }
        ApplicationUser userToSave = new ApplicationUser
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = DateTime.SpecifyKind(dateOfBirth, DateTimeKind.Utc),
            PasswordHash = password
        };
        await _applicationUserRepository.AddAsync(userToSave);
        await _applicationUserRepository.SaveChangesAsync();
        return new Dictionary<string, string>
        {
            {"status", "Success"},
        };
    }
}