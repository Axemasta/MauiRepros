using System.Collections.ObjectModel;

namespace GroupHeaderResizingRepro.Models;

public class AnimalGroup(List<Animal> animals) : ObservableCollection<Animal>(animals)
{
    public required string Title { get; set; }
}