# Prism Select Tab Reproduction

[![Maui Issue Status](https://img.shields.io/github/issues/detail/state/PrismLibrary/Prism/3302)](https://github.com/PrismLibrary/Prism/issues/3302)

Reproduction app for the following question asked over on [prism](https://github.com/PrismLibrary/Prism/issues/3302)

## Solution

To select a tab in a tabbed page when it is wrapped in a `NavigationPage`, you must also specify that:

```csharp
var nav = await navigationService.CreateBuilder()
    .AddTabbedSegment(tabbed =>
    {
        tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageAViewModel>());
        tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageBViewModel>());
        tabbed.CreateTab(tab => tab.AddNavigationPage().AddSegment<PageCViewModel>());
        tabbed.SelectedTab("NavigationPage|PageB");
    })
    .NavigateAsync();
```

> Note: you cant use the viewmodel name here, it must be the name of the page itself!