using System.Diagnostics;

namespace DecimalCommaNumber;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void InputView_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        Debug.WriteLine($"Text changed: {e.NewTextValue}");
    }
}