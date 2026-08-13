using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using NavigationPage = Microsoft.Maui.Controls.NavigationPage;

namespace ModalPresentationIssue.Pages;

public partial class FirstPage : ContentPage
{
    private readonly IServiceProvider serviceProvider;
    
    public FirstPage(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private async void OnShowModalPage(object? sender, EventArgs e)
    {
        var secondPage = serviceProvider.GetRequiredService<SecondPage>();

        await Navigation.PushModalAsync(secondPage);
    }
    
    private async void OnShowModalNavPage(object? sender, EventArgs e)
    {
        var secondPage = serviceProvider.GetRequiredService<SecondPage>();

        var modal = new NavigationPage(secondPage);

        await Navigation.PushModalAsync(modal);
    }
    
    private async void OnShowModalNavPageWorkaround(object? sender, EventArgs e)
    {
        var secondPage = serviceProvider.GetRequiredService<SecondPage>();

        var modal = new NavigationPage(secondPage);

        // This isn't nice :(
        modal.On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);

        await Navigation.PushModalAsync(modal);
    }
}