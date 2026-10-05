using System.Globalization;
using Android.Text;
using Android.Widget;

namespace DecimalCommaNumber.Handlers;

/// <summary>
/// Normalizes whichever decimal separator character ('.' or ',') was typed into the
/// one appropriate for <see cref="CultureInfo.CurrentCulture"/>, so the fix isn't
/// specific to any single culture.
/// </summary>
public class DecimalSeparatorTextWatcher(EditText editText) 
    : Java.Lang.Object, ITextWatcher
{
    private bool _updating;

    public void BeforeTextChanged(
        Java.Lang.ICharSequence? s,
        int start,
        int count,
        int after)
    {
    }

    public void OnTextChanged(
        Java.Lang.ICharSequence? s,
        int start,
        int before,
        int count)
    {
    }

    public void AfterTextChanged(IEditable? s)
    {
        if (_updating || s == null)
            return;

        var text = s.ToString();

        var correctSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        if (correctSeparator.Length != 1)
            return;

        var wrongSeparator = correctSeparator == "," ? '.' : ',';

        if (!text.Contains(wrongSeparator))
            return;

        _updating = true;

        var selection = editText.SelectionStart;

        var newText = text.Replace(wrongSeparator, correctSeparator[0]);

        editText.Text = newText;

        // Keep the cursor in roughly the same position.
        editText.SetSelection(
            Math.Min(selection, newText.Length));

        _updating = false;
    }
}