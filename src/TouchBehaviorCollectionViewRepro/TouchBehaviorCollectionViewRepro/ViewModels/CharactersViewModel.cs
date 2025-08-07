using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using TouchBehaviorCollectionViewRepro.Models;

namespace TouchBehaviorCollectionViewRepro.ViewModels;

public partial class CharactersViewModel(ILogger<CharactersViewModel> logger) : ObservableObject
{
    private readonly ILogger logger = logger;

    public ObservableCollection<JojoCharacterDisplayItem> Characters { get; } = new(CharactersRepository.GetCharacters());

    [RelayCommand]
    private void CharacterSelected(JojoCharacterDisplayItem? characterDisplayItem)
    {
        if (characterDisplayItem is null)
        {
            logger.LogDebug("Selected character was null...");
            return;
        }

        Shell.Current.DisplayAlert(characterDisplayItem.Name, $"{characterDisplayItem.Name} has the stand {characterDisplayItem.Stand}. This stand is of type {characterDisplayItem.StandType} and form {characterDisplayItem.StandForm}", "OK");
    }
}

public static class CharactersRepository
{
    public static List<JojoCharacterDisplayItem> GetCharacters()
    {
        return new List<JojoCharacterDisplayItem>
        {
            new JojoCharacterDisplayItem()
            {
                Name = "Jotaro Kujo",
                Stand = "Star Platinum",
                StandType = StandType.CloseRange,
                StandForm = StandForm.NaturalHumanoid,
                IsAlly = true,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Jean Pierre Polnareff",
                Stand = "Silver Chariot",
                StandType = StandType.CloseRange,
                StandForm = StandForm.ArtificalHumanoid,
                IsAlly = true,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Mohammed Avdol",
                Stand = "Magicians Red",
                StandType = StandType.CloseRange,
                StandForm = StandForm.NaturalNonHumanoid,
                IsAlly = true,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Joseph Joestar",
                Stand = "Hermit Purple",
                StandType = StandType.RangeIrrelevant,
                StandForm = StandForm.Phenomenon,
                IsAlly = true,
            },
        };
    }
}