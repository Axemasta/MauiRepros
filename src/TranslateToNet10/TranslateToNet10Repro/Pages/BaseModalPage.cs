using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using NavigationPage = Microsoft.Maui.Controls.NavigationPage;

namespace TranslateToNet10Repro.Pages;

public class BaseModalPage : ContentPage
{
    protected override void OnParentChanging(ParentChangingEventArgs args)
    {
        base.OnParentChanging(args);

        // What a bodge way to set this...
        // https://github.com/dotnet/maui/issues/20284
        if (args.NewParent is NavigationPage navigationPage)
        {
            navigationPage.On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.PageSheet);
        }
    }
}
