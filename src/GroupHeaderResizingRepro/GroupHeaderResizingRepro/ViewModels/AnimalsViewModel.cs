using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using GroupHeaderResizingRepro.Models;

namespace GroupHeaderResizingRepro.ViewModels;

public partial class AnimalsViewModel : ObservableObject
{
    public ObservableCollection<AnimalGroup> AnimalGroups { get; }

    public AnimalsViewModel()
    {
        var bears = new List<Animal>()
        {
            new()
            {
                Name = "American Black Bear",
                Location = "North America",
                Details = "Details about the bear go here.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzbär.jpg"
            },
            new()
            {
                Name = "Asian Black Bear",
                Location = "Asia",
                Details = "Details about the bear go here.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG/180px-Ursus_thibetanus_3_%28Wroclaw_zoo%29.JPG"
            },
        };

        var monkeys = new List<Animal>()
        {
            new()
            {
                Name = "Baboon",
                Location = "Africa & Asia",
                Details = "Details about the monkey go here.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"
            },
            new()
            {
                Name = "Capuchin Monkey",
                Location = "Central & South America",
                Details = "Details about the monkey go here.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Capuchin_Costa_Rica.jpg/200px-Capuchin_Costa_Rica.jpg"
            },
            new()
            {
                Name = "Blue Monkey",
                Location = "Central and East Africa",
                Details = "Details about the monkey go here.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/BlueMonkey.jpg/220px-BlueMonkey.jpg"
            },
        };

        AnimalGroups = new ObservableCollection<AnimalGroup>(
        [
            new AnimalGroup(bears)
            {
                Title = "Bears",
            },
            new AnimalGroup(monkeys)
            {
                Title = "Monkeys",
            }
        ]);
    }
}