using AndroidSSLRepro.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace AndroidSSLRepro.ViewModels;

public partial class TestUrlViewModel(
    IHttpClientFactory httpClientFactory, 
    ILogger<TestUrlViewModel> logger) : ObservableObject
{
    private readonly HttpClient _verifyClient = httpClientFactory.CreateClient("UrlVerifierClient");
    
    [ObservableProperty] 
    public partial string Url { get; set; } = "https://www.google.com/";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(VerifyingUrl))]
    public partial bool CanVerifyUrl { get; set; } = true;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShowSuccess))]
    [NotifyPropertyChangedFor(nameof(ShowFailure))]
    public partial UrlVerificationResult? VerificationResult { get; set; }
    
    public bool ShowSuccess => VerificationResult?.Success == true;
    
    public bool ShowFailure => VerificationResult?.Success == false;
    
    public bool VerifyingUrl => !CanVerifyUrl;

    [RelayCommand(CanExecute = nameof(CanVerifyUrl))]
    private async Task VerifyUrl()
    {
        VerificationResult = null;
        CanVerifyUrl = false;
        
        try
        {
            VerificationResult = await VerifyUrl(Url);
        }
        finally
        {
            CanVerifyUrl = true;
        }
    }
    
    private async Task<UrlVerificationResult> VerifyUrl(string url)
    {
        try
        {
            var response =  await _verifyClient.GetAsync(url);

            return new UrlVerificationResult(response.IsSuccessStatusCode)
            {
                StatusCode = response.StatusCode,
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception occurred while verifying URL: {Url}", url);
            
            return new UrlVerificationResult(false)
            {
                Exception = ex,
            };
        }
    }
}