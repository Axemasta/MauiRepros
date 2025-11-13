using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace TranslateToNet10Repro;

public partial class BaseModalPageHandler : PageHandler
{
    protected override Microsoft.Maui.Platform.ContentView CreatePlatformView()
    {
        _ = VirtualView ??
            throw new InvalidOperationException($"{nameof(VirtualView)} must be set to create a LayoutView");
        _ = MauiContext ?? throw new InvalidOperationException($"{nameof(MauiContext)} cannot be null");

        if (ViewController == null)
            ViewController = new BaseModalPageViewController(VirtualView, MauiContext);

        if (ViewController is PageViewController pc && pc.CurrentPlatformView is Microsoft.Maui.Platform.ContentView pv)
            return pv;

        if (ViewController.View is Microsoft.Maui.Platform.ContentView cv)
            return cv;

        throw new InvalidOperationException(
            $"PageViewController.View must be a {nameof(Microsoft.Maui.Platform.ContentView)}");
    }
}

internal class BaseModalPageViewController(IView page, IMauiContext mauiContext)
	: PageViewController(page, mauiContext)
{
	public override void ViewDidAppear(bool animated)
	{
        base.ViewDidAppear(animated);
		this.SetModalInPresentation(true);
	}
}
