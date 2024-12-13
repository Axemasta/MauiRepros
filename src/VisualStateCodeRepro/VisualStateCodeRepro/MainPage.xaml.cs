using CommunityToolkit.Maui;

namespace VisualStateCodeRepro;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        
        StyleEditor();
    }

    private void StyleEditor()
    {
        // Not applicable in this case since we can't set this on a setter & we need 4 colors for the enabled/disabled appearance
        // CodeEditor.SetAppThemeColor(Editor.TextColorProperty, Colors.Black, Colors.Blue);

        VisualStateManager.SetVisualStateGroups(CodeEditor, [
            new VisualStateGroup()
            {
                Name = "CommonStates",
                States =
                {
                    new VisualState()
                    {
                        Name = "Normal",
                        Setters =
                        {
                            new Setter()
                            {
                                Property = Editor.TextColorProperty,
                                Value = new AppThemeColor()
                                {
                                    Light = Colors.Lime,
                                    Dark = Colors.Gold,
                                    Default =  Colors.Lime,
                                },
                                // Value = Colors.Gold, // This works, but doesnt respond to themes
                            }
                        }
                    },
                    new VisualState()
                    {
                        Name = "Disabled",
                        Setters =
                        {
                            new Setter()
                            {
                                Property = Editor.TextColorProperty,
                                Value = new AppThemeColor()
                                {
                                    Light = Colors.DarkGreen,
                                    Dark = Color.FromArgb("#CCAC00"),
                                    Default = Colors.DarkGreen,
                                }
                                // Value = Color.FromArgb("#CCAC00"), // This works, but doesnt respond to themes
                            }
                        }
                    }
                }
            }
        ]);
    }

    private void OnChangeTheme(object? sender, EventArgs e)
    {
        switch (Application.Current!.RequestedTheme)
        {
            case AppTheme.Dark:
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                break;
            }

            default:
            case AppTheme.Light:
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
                break;
            }
        }
    }
}