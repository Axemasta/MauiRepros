using System.Diagnostics;

namespace TranslateToNet10Repro.Pages;

public partial class MainPage : BaseModalPage
{
	private bool useAnimations = true;
	
	private const uint animationDuration = 250;

	public MainPage()
	{
		InitializeComponent();

#if USE_NET_10
		NetTargetButton.Text = ".NET 10 (Deadlock)";
#else
		NetTargetButton.Text = ".NET 9 (Working)";
#endif
	}

	private void OnFooterButtonClicked(object? sender, EventArgs e)
	{
		Debug.WriteLine("OnFooterButtonClicked");
		if (!FooterView.IsVisible)
		{
			Dispatcher.DispatchAsync(ShowFooter);
		}
		else
		{
			Dispatcher.DispatchAsync(HideFooter);
		}
	}

	private async Task ShowFooter()
	{
		if (FooterView.IsVisible)
		{
			return;
		}
		
		Debug.WriteLine("Showing Footer");
		
		if (useAnimations)
		{
			var height = FooterView.Measure(FooterView.Width, double.PositiveInfinity).Height;
			FooterView.TranslationY = height;
			FooterView.IsVisible = true;
#if USE_NET_10
			await FooterView.TranslateToAsync(0, 0, animationDuration, Easing.CubicInOut);
#else
			await FooterView.TranslateTo(0, 0, animationDuration, Easing.CubicInOut);
#endif
		}
		else
		{
			FooterView.IsVisible = true;
		}
		
		Debug.WriteLine("Footer is now displayed");
	}

	private async Task HideFooter()
	{
		if (!FooterView.IsVisible)
		{
			return;
		}
		
		Debug.WriteLine("Hiding Footer");

		if (useAnimations)
		{
			
#if USE_NET_10
			await FooterView.TranslateToAsync(0, FooterView.Height, animationDuration, Easing.CubicInOut);
#else
			await FooterView.TranslateTo(0, FooterView.Height, animationDuration, Easing.CubicInOut);
#endif
		}
		
		FooterView.IsVisible = false;
		
		Debug.WriteLine("Footer is now hidden");
	}
}