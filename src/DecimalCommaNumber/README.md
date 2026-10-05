# Decimal Comma Entry Issue

[![Issue Status](https://img.shields.io/github/issues/detail/state/dotnet/maui/39091)](https://github.com/dotnet/maui/issues/39091)

This is an issue that occurs on Android devices with languages that use a decimal comma (e.g., Polish, Slovakian).

Depending on the device specific keyboard will determine the total impact however in all cases, the decimal key is presented
to the user however it is non functional, pressing it causes no decimal to be entered into the input field. Some devices
present a comma, which works again based on the device... Some work and allow the comma to be entered, some do not. On the Samsung
family of tablets, the comma key is disabled preventing the user from being able to enter decimals at all!

This reproduction app has a simple  numeric entry. To reproduce the issue, ensure the workaround mapper is commented out in the MauiProgram.cs

A workaround has been provided that adds a key listener to the Android `EditText` control. This will listen for decimals and insert
them as decimal commas, allowing the expected functionality to be restored.

