using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Api.Contexts;
using WardrobeInventory.Api.Repositories;
using WardrobeInventory.Entities;
using WardrobeInventory.Repositories;

namespace WardrobeInventory.Api.Installers;

public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var connectionString = $"Data Source={nameof(WardrobeInventory)}.db";

        services.AddDbContext<WardrobeInventoryDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IGenericRepository<WardrobeItem>, WardrobeItemRepository>();

        return services;
    }

    public static IServiceProvider SeedDatabase(this IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<WardrobeInventoryDbContext>();

        context.Database.EnsureCreated();

        return serviceProvider;
    }
}
