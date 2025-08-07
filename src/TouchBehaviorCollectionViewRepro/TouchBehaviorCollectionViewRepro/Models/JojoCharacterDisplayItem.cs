using CommunityToolkit.Mvvm.ComponentModel;

namespace TouchBehaviorCollectionViewRepro.Models;

public partial class JojoCharacterDisplayItem : ObservableObject
{
    public string Name { get; set; }

    public string Stand { get; set; }

    public StandType StandType { get; set; }

    public StandForm StandForm { get; set; }

    public bool IsAlly { get; set; }
}

public enum StandType
{
    CloseRange,
    LongRange,
    Automatic,
    RangeIrrelevant
}

public enum StandForm
{
    NaturalHumanoid,
    ArtificalHumanoid,
    NaturalNonHumanoid,
    ArtificialNonHumanoid,
    Phenomenon
}