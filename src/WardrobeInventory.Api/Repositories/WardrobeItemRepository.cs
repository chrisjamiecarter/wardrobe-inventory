using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Entities;
using WardrobeInventory.Repositories;
using WardrobeInventory.Api.Contexts;

namespace WardrobeInventory.Api.Repositories;

public class WardrobeItemRepository(WardrobeInventoryDbContext context) : IGenericRepository<WardrobeItem>
{
    public async Task<bool> CreateAsync(WardrobeItem entity)
    {
        await context.WardrobeItems.AddAsync(entity);
        
        var result = await SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(WardrobeItem entity)
    {
        context.WardrobeItems.Remove(entity);

        var result = await SaveChangesAsync();
        return result > 0;
    }

    public async Task<IReadOnlyList<WardrobeItem>> ReturnAsync()
    {
        return await context.WardrobeItems.ToListAsync();
    }

    public async Task<WardrobeItem?> ReturnAsync(Guid id)
    {
        return await context.WardrobeItems.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(WardrobeItem entity)
    {
        context.WardrobeItems.Update(entity);
        
        var result = await SaveChangesAsync();
        return result > 0;
    }

    private async Task<int> SaveChangesAsync()
    {
        try
        {
            var changes = await context.SaveChangesAsync();
            return changes;
        }
        catch (Exception exception)
        {
            Trace.TraceWarning(exception.Message);
            return -1;
        }
    }
}
