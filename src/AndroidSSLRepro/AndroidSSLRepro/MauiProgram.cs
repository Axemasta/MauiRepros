using AndroidSSLRepro.Pages;
using AndroidSSLRepro.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace AndroidSSLRepro;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddHttpClient("UrlVerifierClient", options =>
        {
            options.Timeout = TimeSpan.FromSeconds(15);
        })
        .ConfigurePrimaryHttpMessageHandler(() =>
        {
            var handler = new HttpClientHandler();
            // handler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
            return handler;
        });
        
        builder.Services.AddTransient<TestUrlViewModel>();
        builder.Services.AddTransient<TestUrlPage>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}