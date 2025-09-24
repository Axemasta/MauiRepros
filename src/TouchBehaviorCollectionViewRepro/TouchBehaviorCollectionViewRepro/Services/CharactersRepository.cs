using TouchBehaviorCollectionViewRepro.Models;

namespace TouchBehaviorCollectionViewRepro.Services;

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
            new JojoCharacterDisplayItem()
            {
                Name = "Noriaki Kakyoin",
                Stand = "Hierophant Green",
                StandType = StandType.LongRange,
                StandForm = StandForm.NaturalNonHumanoid,
                IsAlly = true,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "DIO",
                Stand = "The World",
                StandType = StandType.CloseRange,
                StandForm = StandForm.NaturalHumanoid,
                IsAlly = false,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Enrico Pucci",
                Stand = "Made in Heaven",
                StandType = StandType.Automatic,
                StandForm = StandForm.NaturalHumanoid,
                IsAlly = false,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Bruno Bucciarati",
                Stand = "Sticky Fingers",
                StandType = StandType.CloseRange,
                StandForm = StandForm.NaturalHumanoid,
                IsAlly = true,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Guido Mista",
                Stand = "Sex Pistols",
                StandType = StandType.LongRange,
                StandForm = StandForm.ArtificialNonHumanoid,
                IsAlly = true,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Yoshikage Kira",
                Stand = "Killer Queen",
                StandType = StandType.CloseRange,
                StandForm = StandForm.NaturalHumanoid,
                IsAlly = false,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Rohan Kishibe",
                Stand = "Heaven's Door",
                StandType = StandType.LongRange,
                StandForm = StandForm.NaturalHumanoid,
                IsAlly = true,
            },
            new JojoCharacterDisplayItem()
            {
                Name = "Giorno Giovanna",
                Stand = "Gold Experience",
                StandType = StandType.CloseRange,
                StandForm = StandForm.NaturalHumanoid,
                IsAlly = true,
            },
        };
    }
}