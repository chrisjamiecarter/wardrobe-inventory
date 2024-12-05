using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Api.Contexts;
using WardrobeInventory.Entities;
using WardrobeInventory.Repositories;

namespace WardrobeInventory.Api.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    public readonly WardrobeInventoryDbContext _context;

    public GenericRepository(WardrobeInventoryDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Entity => _context.Set<T>();

    public async Task<bool> CreateAsync(T entity)
    {
        await Entity.AddAsync(entity);

        var result = await SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        Entity.Remove(entity);

        var result = await SaveChangesAsync();
        return result > 0;
    }

    public async Task<IReadOnlyList<T>> ReturnAsync()
    {
        return await Entity.ToListAsync();
    }

    public async Task<T?> ReturnAsync(Guid id)
    {
        return await Entity.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        Entity.Update(entity);

        var result = await SaveChangesAsync();
        return result > 0;
    }

    private async Task<int> SaveChangesAsync()
    {
        try
        {
            var changes = await _context.SaveChangesAsync();
            return changes;
        }
        catch (Exception exception)
        {
            Trace.TraceWarning(exception.Message);
            return -1;
        }
    }
}
