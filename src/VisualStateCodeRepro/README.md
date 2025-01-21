# Visual State Code Repro

[![Maui Issue Status](https://img.shields.io/github/issues/detail/state/dotnet/maui/26620)](https://github.com/dotnet/maui/issues/26620)
[![MCT Issue Status](https://img.shields.io/github/issues/detail/state/CommunityToolkit/Maui/2408)](https://github.com/CommunityToolkit/Maui/issues/2408)

Reproduction app for the following issue raised on maui & maui community toolkit

Maui issue:
Lack of public api available to set `AppThemeBinding` through code

MCT issue:
Using a `Setter` in code with an `AppThemeColor` does not apply colors correctly

## Solution

You need to call `GetBinding()` before passing the `AppThemeColor` to your setters, this will not be called automatically:

```diff
new VisualState()
{
    Name = "Normal",
    Setters =
    {
        new Setter()
        {
            Property = Editor.TextColorProperty,
-            Value = new AppThemeColor() { Light = Colors.White, Dark = Colors.Black},
+            Value = new AppThemeColor() { Light = Colors.White, Dark = Colors.Black}.GetBinding(),
        }
    }
}
```