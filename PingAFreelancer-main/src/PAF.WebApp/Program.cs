using Microsoft.Extensions.Logging;
using PAF.MobileApp.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.AspNetCore.Components.WebView.Maui;
namespace PAF.MobileApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        // Add your existing services
        builder.Services.AddHttpClient<ApiClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5136/api/");
        });

        builder.Services.AddScoped<INavService, NavService>();
        builder.Services.AddScoped<JwtSecurityTokenHandler>();
        builder.Services.AddScoped<AuthenticationStateProvider>(provider => 
            provider.GetRequiredService<CustomAuthStateProvider>());
        builder.Services.AddScoped<CustomAuthStateProvider>();
        builder.Services.AddScoped<IFreelancerService, ApiClientService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddAuthorizationCore();

        return builder.Build();
    }
}
