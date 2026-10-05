using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Platform;

namespace DecimalCommaNumber.Handlers;

public static class EditTextExtensions
{
    internal static void SetInputTypeFixed(this EditText editText, ITextInput textInput)
    {
        var previousCursorPosition = editText.SelectionStart;
        var keyboard = textInput.Keyboard;

        editText.InputType = keyboard.ToInputType();

        // if (keyboard is not CustomKeyboard)
        // {
        //     editText.UpdateIsTextPredictionEnabled(textInput);
        //     editText.UpdateIsSpellCheckEnabled(textInput);
        // }

        if (keyboard == Keyboard.Numeric)
        {
            editText.KeyListener = LocalizedDigitsKeyListener.Create(editText.InputType);
        }

        if (textInput is IEntry entry)
        {
            if (entry.IsPassword)
            {
                if (editText.InputType.HasFlag(InputTypes.ClassText))
                    editText.InputType |= InputTypes.TextVariationPassword;

                if (editText.InputType.HasFlag(InputTypes.ClassNumber))
                    editText.InputType |= InputTypes.NumberVariationPassword;
            }
            else
            {
                if (editText.InputType.HasFlag(InputTypes.ClassText) &&
                    editText.InputType.HasFlag(InputTypes.TextVariationPassword))
                    editText.InputType &= ~InputTypes.TextVariationPassword;

                if (editText.InputType.HasFlag(InputTypes.ClassNumber) &&
                    editText.InputType.HasFlag(InputTypes.NumberVariationPassword))
                    editText.InputType &= ~InputTypes.NumberVariationPassword;
            }
        }

        if (textInput is IEditor)
            editText.InputType |= InputTypes.TextFlagMultiLine;

        if (textInput is IElement element)
        {
            var services = element.Handler?.MauiContext?.Services;

            if (services == null)
                return;

            var fontManager = services.GetRequiredService<IFontManager>();
            editText.UpdateFont(textInput, fontManager);
        }

        // If we implement the OnSelectionChanged method, this method is called after a keyboard layout change with SelectionStart = 0,
        // Let's restore the cursor position to its previous location.
        editText.SetSelection(previousCursorPosition);
    }
}