using CommunityToolkit.Mvvm.Input;

namespace ReferenceCommandParameterRepro.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [RelayCommand]
    private async Task Report(DateTime dateTime)
    {
        Shell.Current.DisplayAlert("Date Selected", $"The selected date was {dateTime}", "OK");
    }
}