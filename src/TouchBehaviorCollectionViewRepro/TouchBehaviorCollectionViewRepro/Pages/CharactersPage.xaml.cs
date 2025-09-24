using TouchBehaviorCollectionViewRepro.ViewModels;

namespace TouchBehaviorCollectionViewRepro.Pages;

public partial class CharactersPage : ContentPage
{
	public CharactersPage(CharactersViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}