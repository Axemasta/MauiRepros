using CommunityToolkit.Mvvm.Input;

namespace PrismSelectTabRepro.ViewModels;

public partial class PageBViewModel(INavigationService navigationService) : BaseViewModel(navigationService, "Page B")
{
    [RelayCommand]
    private async Task GoToTabC()
    {
        await navigationService.SelectTabAsync("PageC");
    }
}