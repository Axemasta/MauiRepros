using ModalPresentationIssue.Pages;
namespace ModalPresentationIssue;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        var firstPage = serviceProvider.GetRequiredService<FirstPage>();

        MainPage = new NavigationPage(firstPage);
    }
}