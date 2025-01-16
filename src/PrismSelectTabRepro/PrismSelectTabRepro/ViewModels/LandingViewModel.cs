using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrismSelectTabRepro.Pages;

namespace PrismSelectTabRepro.ViewModels;

public partial class LandingViewModel(
    INavigationService navigationService, 
    IPageDialogService pageDialogService) 
    : BaseViewModel(navigationService, "Tabbed Select Repro")
{
    [ObservableProperty] public partial bool SelectTab { get; set; }
    
    [ObservableProperty] public partial bool UseDynamicNavigation { get; set; }
    
    public List<string> AvailableTabs { get; } = [ nameof(PageA), nameof(PageB), nameof(PageC) ];
    
    [ObservableProperty] public partial string? SelectedTab { get; set; }

    public override void Initialize(INavigationParameters parameters)
    {
        SelectedTab = AvailableTabs.First();
    }

    [RelayCommand]
    private async Task Navigate()
    {
        INavigationResult nav;
        
        if (UseDynamicNavigation)
        {
            var builder = navigationService.CreateBuilder();
            
            builder.AddTabbedSegment(tabbed =>
            {
                tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageAViewModel>());
                tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageBViewModel>());
                tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageCViewModel>());
                
                if (SelectTab && SelectedTab is not null)
                {
                    tabbed.SelectedTab(SelectedTab);
                }
            });
            
            nav = await builder.NavigateAsync();
        }
        else
        {
            var destination = $"{nameof(StaticTabbedPage)}";
            
            if (SelectTab && SelectedTab is not null)
            {
                destination += $"?{KnownNavigationParameters.SelectedTab}={SelectedTab}";
            }

            nav = await navigationService.NavigateAsync(destination);
        }
        
        if (!nav.Success)
        {
            Debug.WriteLine(nav.Exception);
            await pageDialogService.DisplayAlertAsync("Navigation failed", nav.Exception?.ToString() ?? "Exception was null", "OK");
        }
    }

    [RelayCommand]
    private async Task ExpectedNavigation()
    {
        var nav = await navigationService.CreateBuilder()
            .AddTabbedSegment(tabbed =>
            {
                tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageAViewModel>());
                tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageBViewModel>());
                tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageCViewModel>());
                tabbed.SelectTab<PageBViewModel>(); // Comment out and this works!
            })
            .NavigateAsync();
        
        if (!nav.Success)
        {
            Debug.WriteLine(nav.Exception);
            await pageDialogService.DisplayAlertAsync("Navigation failed", nav.Exception?.ToString() ?? "Exception was null", "OK");
        }
    }
}