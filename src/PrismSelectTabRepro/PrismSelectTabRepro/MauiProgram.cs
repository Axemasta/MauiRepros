using System.Diagnostics;
using Microsoft.Extensions.Logging;
using PrismSelectTabRepro.Pages;
using PrismSelectTabRepro.ViewModels;

namespace PrismSelectTabRepro;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(prism =>
            {
                prism.RegisterTypes(container =>
                {
                    container.RegisterForNavigation<StaticTabbedPage>();
                    container.RegisterForNavigation<LandingPage, LandingViewModel>();
                    container.RegisterForNavigation<PageA, PageAViewModel>();
                    container.RegisterForNavigation<PageB, PageBViewModel>();
                    container.RegisterForNavigation<PageC, PageCViewModel>();
                });

                prism.CreateWindow(async navigationService =>
                {
                    var nav = await navigationService.CreateBuilder()
                        .AddNavigationPage()
                        .AddSegment<LandingViewModel>()
                        .NavigateAsync();

                    if (!nav.Success)
                    {
                        Debugger.Break();
                    }
                });
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}