using Microsoft.EntityFrameworkCore;
using ShopApp.Data;

namespace ShopApp.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _dbContext;
    protected readonly DbSet<T> DbSet;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        DbSet = _dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(object id)
    {
        return await DbSet.FindAsync(id) ?? throw new KeyNotFoundException();
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}