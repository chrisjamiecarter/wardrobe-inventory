
using WardrobeInventory.Api.Installers;

namespace WardrobeInventory.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddApi();
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure();
        
        var app = builder.Build();
        app.AddMiddleware();
        app.SetUpDatabase();
        app.Run();
    }
}
