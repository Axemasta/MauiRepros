using DecimalCommaNumber.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace DecimalCommaNumber;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureMauiHandlers(handlers =>
            {
                // Remove this mapper to reveal the issue!
                EntryHandler.Mapper.AppendToMapping("CultureDecimal", (handler, view) =>
                {
                    if (view.Keyboard != Keyboard.Numeric)
                        return;

                    var editText = handler.PlatformView;

                    // Accept both '.' and ',' so the decimal key is never silently
                    // swallowed by the default locale-derived KeyListener.
                    editText.KeyListener = new DecimalKeyListener();

                    // Normalize whichever separator was typed into the one that is
                    // correct for the current culture.
                    editText.AddTextChangedListener(new DecimalSeparatorTextWatcher(editText));
                });
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}