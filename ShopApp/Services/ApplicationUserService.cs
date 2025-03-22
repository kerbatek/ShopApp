using ShopApp.Models;
using ShopApp.Repositories;

namespace ShopApp.Services;

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
}