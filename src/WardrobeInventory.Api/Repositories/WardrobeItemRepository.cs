using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Entities;
using WardrobeInventory.Repositories;
using WardrobeInventory.Api.Contexts;

namespace WardrobeInventory.Api.Repositories;

public class WardrobeItemRepository(WardrobeInventoryDbContext context) : IGenericRepository<WardrobeItem>
{
    public async Task<bool> CreateAsync(WardrobeItem request)
    {
        await context.WardrobeItems.AddAsync(request);
        
        var result = await SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await context.WardrobeItems.FindAsync(id);
        if (entity is not null)
        {
            context.WardrobeItems.Remove(entity);
        }

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

    public async Task<bool> UpdateAsync(WardrobeItem request)
    {
        var entity = await context.WardrobeItems.FindAsync(request.Id);
        if (entity is not null)
        {
            entity.Name = request.Name;
            if (!string.IsNullOrWhiteSpace(request.ImagePath))
            {
                entity.ImagePath = request.ImagePath;
            }
            entity.Color = request.Color;
            entity.Size = request.Size;
            entity.Material = request.Material;
            context.WardrobeItems.Update(entity);
        }

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
