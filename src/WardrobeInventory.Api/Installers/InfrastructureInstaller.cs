using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Api.Contexts;
using WardrobeInventory.Api.Repositories;
using WardrobeInventory.Repositories;

namespace WardrobeInventory.Api.Installers;

public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        var fileName = $"{nameof(WardrobeInventory)}.db";
        var filePath = Path.Combine(directoryPath, fileName);

        var connectionString = $"Data Source={filePath}";

        services.AddDbContext<WardrobeInventoryDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IWardrobeItemRepository, WardrobeItemRepository>();

        return services;
    }

    public static IServiceProvider SeedDatabase(this IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<WardrobeInventoryDbContext>();

        context.Database.EnsureCreated();

        return serviceProvider;
    }
}
