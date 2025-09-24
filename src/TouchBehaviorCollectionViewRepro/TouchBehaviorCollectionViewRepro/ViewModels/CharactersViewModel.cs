using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using TouchBehaviorCollectionViewRepro.Models;
using TouchBehaviorCollectionViewRepro.ObjectModel;
using TouchBehaviorCollectionViewRepro.Services;

namespace TouchBehaviorCollectionViewRepro.ViewModels;

public partial class CharactersViewModel : ObservableObject
{
    private readonly ILogger _logger;
    private readonly List<JojoCharacterDisplayItem> _unfilteredCharacters;

    public ObservableRangeCollection<JojoCharacterDisplayItem> Characters { get; } = [];
    
    public CharactersViewModel(ILogger<CharactersViewModel> logger)
    {
        _logger = logger;
        _unfilteredCharacters = CharactersRepository.GetCharacters();

        Characters.AddRange(_unfilteredCharacters);
    }
    
    
    [RelayCommand]
    private void CharacterSelected(JojoCharacterDisplayItem? characterDisplayItem)
    {
        if (characterDisplayItem is null)
        {
            _logger.LogDebug("Selected character was null...");
            return;
        }

        Shell.Current.DisplayAlert(characterDisplayItem.Name, $"{characterDisplayItem.Name} has the stand {characterDisplayItem.Stand}. This stand is of type {characterDisplayItem.StandType} and form {characterDisplayItem.StandForm}", "OK");
    }

    [RelayCommand]
    private void OrderCharacters(string orderType)
    {
        var filteredCharacters = _unfilteredCharacters;
        
        switch (orderType)
        {
            case OrderConstants.AlphabeticallyAscending:
            {
                filteredCharacters = filteredCharacters
                    .OrderByDescending(c => c.Name)
                    .ToList();
                break;
            }
            
            case OrderConstants.AlphabeticallyDescending:
            {
                filteredCharacters = filteredCharacters
                    .OrderBy(c => c.Name)
                    .ToList();
                break;
            }

            case OrderConstants.Shuffle:
            {
                var rnd = Random.Shared;
                filteredCharacters = filteredCharacters
                    .OrderBy(_ => rnd.Next())
                    .ToList();
                break;
            }
        }
        
        Characters.ReplaceRange(filteredCharacters);
    }
}