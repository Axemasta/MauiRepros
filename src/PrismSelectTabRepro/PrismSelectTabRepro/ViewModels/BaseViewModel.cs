using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using IImage = Microsoft.Maui.IImage;

namespace PrismSelectTabRepro.ViewModels;

public partial class BaseViewModel(INavigationService navigationService, string title) : ObservableObject, INavigationAware, IInitialize
{
    // ReSharper disable once InconsistentNaming
    protected readonly INavigationService navigationService = navigationService;

    [ObservableProperty] public partial string Title { get; set; } = title;
    
    public virtual void OnNavigatedFrom(INavigationParameters parameters)
    {
        Debug.Write($"OnNavigatedFrom: {GetType().Name}");
    }

    public virtual void OnNavigatedTo(INavigationParameters parameters)
    {
        Debug.Write($"OnNavigatedTo: {GetType().Name}");
    }

    public virtual void Initialize(INavigationParameters parameters)
    {
    }
}