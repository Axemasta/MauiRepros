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
        var normalTheme = CreateAppTheme(Colors.Lime, Colors.Gold);
        var disabledTheme = CreateAppTheme(Colors.DarkGreen, Color.FromArgb("#CCAC00"));

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
                                //Value = normalTheme, // Works
                                Value = new AppThemeColor() // Doesnt work
                                {
                                    Default = Colors.Lime,
                                    Light = Colors.Lime,
                                    Dark = Colors.Gold,
                                }
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
                                //Value = disabledTheme, // Works
                                Value = new AppThemeColor() // Doesnt work
                                {
                                    Default = Colors.DarkGreen,
                                    Light = Colors.DarkGreen,
                                    Dark = Color.FromArgb("#CCAC00"),
                                }
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

    private object CreateAppTheme(Color light, Color dark)
    {
        var mauiAssembly = typeof(Microsoft.Maui.Controls.AbsoluteLayout).Assembly;

        var appThemeType = mauiAssembly.GetType("Microsoft.Maui.Controls.AppThemeBinding");

        if (appThemeType is null)
        {
            throw new InvalidOperationException($"Unable to find type AppThemeBinding in assembly {mauiAssembly.FullName}");
        }

        var appThemeBinding = Activator.CreateInstance(appThemeType);

        if (appThemeBinding is null)
        {
            throw new InvalidOperationException("Unable to create instance of AppThemeBinding");
        }

        var lightProperty = appThemeType.GetProperty("Light");

        if (lightProperty is null)
        {
            throw new InvalidOperationException("Unable to find property Light on type AppThemeBinding");
        }

        var darkProperty = appThemeType.GetProperty("Dark");

        if (darkProperty is null)
        {
            throw new InvalidOperationException("Unable to find property Dark on type AppThemeBinding");
        }

        lightProperty.SetValue(appThemeBinding, light);
        darkProperty.SetValue(appThemeBinding, dark);

        return appThemeBinding;
    }
}