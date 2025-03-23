using ShopApp.Models.Core;
using ShopApp.Repositories.Core.Interfaces;
using ShopApp.Services.Core.Interfaces;

namespace ShopApp.Services.Core;

public class ApplicationRoleService : IApplicationRoleService
{
    private readonly IApplicationRoleRepository _applicationRoleRepository;

    public ApplicationRoleService(IApplicationRoleRepository applicationRoleRepository)
    {
        _applicationRoleRepository = applicationRoleRepository;
    }
    
    public async Task<IEnumerable<ApplicationRole>> GetAllApplicationRolesAsync()
    {
        return await  _applicationRoleRepository.GetAllAsync();
    }

    public async Task<ApplicationRole> GetApplicationRoleByIdAsync(int id)
    {
        return await _applicationRoleRepository.GetByIdAsync(id);
    }

    public async Task AddApplicationRoleAsync(ApplicationRole applicationRole)
    {
        await _applicationRoleRepository.AddAsync(applicationRole);
        await _applicationRoleRepository.SaveChangesAsync();
    }

    public async Task UpdateApplicationRoleAsync(ApplicationRole applicationRole)
    {
        await _applicationRoleRepository.UpdateAsync(applicationRole);
        await _applicationRoleRepository.SaveChangesAsync();
    }

    public async Task DeleteApplicationRoleAsync(ApplicationRole applicationRole)
    {
        await _applicationRoleRepository.DeleteAsync(applicationRole);
        await _applicationRoleRepository.SaveChangesAsync();
    }
}