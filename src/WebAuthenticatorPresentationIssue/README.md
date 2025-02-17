# Web Authenticator Presentation Issue

[![Maui Issue Status](https://img.shields.io/github/issues/detail/state/dotnet/maui/27852)](https://github.com/dotnet/maui/issues/27852)

This reproduction demonstrates how after dismissing the web authenticator on iOS, there is a window where no alert can be presented on the view because the SFAuthenticationViewController has not fully dismissed therefore the alerts get pushed onto the alert view controller and cause the alerts to not appear.