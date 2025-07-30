using CommunityToolkit.Mvvm.ComponentModel;

namespace GroupHeaderResizingRepro.Models;

public partial class Animal : ObservableObject
{
    [ObservableProperty]
    public required partial string Name { get; set; }
    
    [ObservableProperty]
    public required partial string Location { get; set; }
    
    [ObservableProperty]
    public required partial string Details { get; set; }
    
    [ObservableProperty]
    public required partial string ImageUrl { get; set; }
}