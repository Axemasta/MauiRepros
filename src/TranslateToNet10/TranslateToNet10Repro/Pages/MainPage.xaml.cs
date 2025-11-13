namespace TranslateToNet10Repro.Pages;

public partial class MainPage : BaseModalPage
{
	private bool useAnimations = true;
	
	private const uint animationDuration = 250;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnFooterButtonClicked(object? sender, EventArgs e)
	{
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
		
		if (useAnimations)
		{
			var height = FooterView.Measure(FooterView.Width, double.PositiveInfinity).Height;
			FooterView.TranslationY = height;
			FooterView.IsVisible = true;
			await FooterView.TranslateToAsync(0, 0, animationDuration, Easing.CubicInOut);
		}
		else
		{
			FooterView.IsVisible = true;
		}
	}

	private async Task HideFooter()
	{
		if (!FooterView.IsVisible)
		{
			return;
		}

		if (useAnimations)
		{
			await FooterView.TranslateToAsync(0, FooterView.Height, animationDuration, Easing.CubicInOut);
		}
		
		FooterView.IsVisible = false;
	}
}