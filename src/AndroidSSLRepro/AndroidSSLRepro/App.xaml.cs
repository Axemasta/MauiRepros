using AndroidSSLRepro.Pages;

namespace AndroidSSLRepro;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    
    public App(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var testUrlPage = _serviceProvider.GetRequiredService<TestUrlPage>();
        
        return new Window(new NavigationPage(testUrlPage));
    }
}