using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace ModalPresentationIssue.Pages;

public partial class SecondPage : ContentPage
{
    public SecondPage()
    {
        On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FormSheet);
        InitializeComponent();
    }

    private async void OnClose(object? sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}