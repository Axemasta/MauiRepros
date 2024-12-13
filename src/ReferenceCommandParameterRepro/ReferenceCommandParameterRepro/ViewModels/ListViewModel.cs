using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using ReferenceCommandParameterRepro.Models;

namespace ReferenceCommandParameterRepro.ViewModels;

public partial class ListViewModel : BaseViewModel
{
    public ObservableCollection<PersonDisplayItem> People { get; } = new([
        new()
        {
            FirstName = "Bob",
            LastName = "Belcher",
            Age = 46,
        },
        new()
        {
            FirstName = "Linda",
            LastName = "Belcher",
            Age = 44,
        },
        new()
        {
            FirstName = "Tina",
            LastName = "Belcher",
            Age = 13,
        },
        new()
        {
            FirstName = "Gene",
            LastName = "Belcher",
            Age = 11,
        },
        new()
        {
            FirstName = "Lousie",
            LastName = "Belcher",
            Age = 9,
        }
    ]);

    [RelayCommand]
    private async Task PersonSelected(PersonDisplayItem person)
    {
        await Shell.Current.DisplayAlert($"Selected {person.FirstName}", $"You selected {person.FirstName} {person.LastName}!", "Ok");
    }
}