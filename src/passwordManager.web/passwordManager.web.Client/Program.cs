using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PasswordManager.Web.Client.Services;
using Blazored.LocalStorage;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddBlazoredLocalStorage();

        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(builder.Configuration["ApiUrl"] ?? builder.HostEnvironment.BaseAddress)
        });

        var host = builder.Build();

        var authService = host.Services.GetRequiredService<IAuthService>();
        var httpClient = host.Services.GetRequiredService<HttpClient>();

        Console.WriteLine($"API URL configured as: {httpClient.BaseAddress}");

        await host.RunAsync();
    }
}