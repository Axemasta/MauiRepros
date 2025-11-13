using Microsoft.Extensions.DependencyInjection;
using TranslateToNet10Repro.Pages;

namespace TranslateToNet10Repro;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new NavigationPage(new MainPage()));
	}
}