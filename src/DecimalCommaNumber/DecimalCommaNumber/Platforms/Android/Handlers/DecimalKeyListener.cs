using System.Linq;
using Android.Text;
using Android.Text.Method;
using Java.Lang;

namespace DecimalCommaNumber.Handlers;

/// <summary>
/// A <see cref="NumberKeyListener"/> that always accepts digits plus both '.' and ','
/// as decimal separator characters, while only ever allowing a single separator to be
/// present in the text at once.
/// </summary>
/// <remarks>
/// On some devices/locales (e.g. Slovak), the default numeric key listener
/// assigned to an <c>EditText</c> only accepts the decimal separator character derived
/// from the current locale. When the on-screen keyboard's decimal key sends a different
/// character than the one the listener accepts, the key press is silently dropped and no
/// <c>TextChanged</c> event is raised at all, so a <see cref="ITextWatcher"/> never gets a
/// chance to normalize it. Accepting both separator characters up-front ensures the
/// keystroke always reaches the text buffer, regardless of locale/keyboard quirks.
/// </remarks>
public class DecimalKeyListener : NumberKeyListener
{
    private static readonly char[] AcceptedChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ','];
    private static readonly char[] SeparatorChars = ['.', ','];

    public override InputTypes InputType =>
        InputTypes.ClassNumber | InputTypes.NumberFlagDecimal;

    protected override char[] GetAcceptedChars() => AcceptedChars;

    public override ICharSequence? FilterFormatted(
        ICharSequence? source,
        int start,
        int end,
        ISpanned? dest,
        int dstart,
        int dend)
    {
        var filtered = base.FilterFormatted(source, start, end, dest, dstart, dend);

        var incoming = filtered?.ToString() ?? source?.SubSequenceFormatted(start, end)?.ToString() ?? string.Empty;

        if (incoming.IndexOfAny(SeparatorChars) < 0)
            return filtered;

        var existing = dest?.ToString() ?? string.Empty;

        // The text that will remain once the [dstart, dend) range is replaced.
        var remainder = dend > dstart && dend <= existing.Length
            ? existing.Remove(dstart, dend - dstart)
            : existing;

        if (remainder.IndexOfAny(SeparatorChars) < 0)
            return filtered; // No separator outside the edited range yet: allow it through.

        // A separator already exists elsewhere in the text: strip any further separators
        // from the incoming text so only one can ever be present.
        var stripped = new string(incoming.Where(c => Array.IndexOf(SeparatorChars, c) < 0).ToArray());

        return new Java.Lang.String(stripped);
    }
}

