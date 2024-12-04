using Scalar.AspNetCore;

namespace WardrobeInventory.Api.Installers;

public static class ApiInstaller
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }

    public static WebApplication AddMiddleware(this WebApplication app)
    {
        app.MapOpenApi();

        if (app.Environment.IsDevelopment())
        {
            app.MapScalarApiReference(options =>
            {
                options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.RestSharp);
            });
        }
        app.UseCors(options =>
        {
            options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    public static WebApplication SetUpDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;
        services.SeedDatabase();

        return app;
    }

}
