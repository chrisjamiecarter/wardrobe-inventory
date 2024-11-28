using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WardrobeInventory.Blazor.Installers;

namespace WardrobeInventory.Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.AddPresentation();

        var app = builder.Build();
        await app.RunAsync();
    }
}
