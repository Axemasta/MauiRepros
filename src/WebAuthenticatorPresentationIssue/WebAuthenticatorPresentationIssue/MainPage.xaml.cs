using Microsoft.Extensions.Logging;

namespace WebAuthenticatorPresentationIssue;

public partial class MainPage : ContentPage
{
    private readonly ManualResetEventSlim loginLock = new(true);

    private readonly ILogger logger;
    
    public MainPage(ILogger<MainPage> logger)
    {
        this.logger = logger;
        InitializeComponent();
    }

    private async void OnLogin(object sender, EventArgs e)
    {
        logger.LogTrace("Waiting for lock");
        
        loginLock.Wait();
        loginLock.Reset();
        
        logger.LogTrace("Obtained lock");
    
        logger.LogDebug("Attempting login...");
    
        try
        {
            // This isn't setup to work...
            var login = await WebAuthenticator.Default.AuthenticateAsync(new WebAuthenticatorOptions()
            {
                Url = new Uri("https://www.google.com/"),
                CallbackUrl = new Uri("myapp://"),
            });
            
            await DisplayAlert("Login successful", $"You are now logged in.", "OK");
        }
        catch (TaskCanceledException)
        {
            // await Task.Delay(TimeSpan.FromSeconds(2));
            
            await DisplayAlert("Login cancelled", $"You login was cancelled", "OK");
        }
        finally
        {
            loginLock.Set();
            logger.LogTrace("Releasing lock");
        }
    }
}