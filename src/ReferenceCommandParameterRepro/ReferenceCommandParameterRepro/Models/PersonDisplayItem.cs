using CommunityToolkit.Mvvm.ComponentModel;

namespace ReferenceCommandParameterRepro.Models;

public partial class PersonDisplayItem : ObservableObject
{
    [ObservableProperty]
    private string firstName;

    [ObservableProperty]
    private string lastName;

    [ObservableProperty]
    private int age;
}