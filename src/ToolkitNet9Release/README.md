# Maui Community Toolkit .NET 9 Release Crash

[![Issue Status](https://img.shields.io/github/issues/detail/state/CommunityToolkit/Maui/2494)](https://github.com/CommunityToolkit/Maui/issues/2494)

This reproduction shows a release mode startup crash when using the maui community toolkit.

I have tried to add a linker file, have hard code references and even disable AOT but nothing seems to resolve the crash.

## Solution

Currently the latest 'stable' version does not work, you will need to download the build artifacts from [#2460 (99.0.0-build-2460.113811)](https://dev.azure.com/dotnet/CommunityToolkit/_build/results?buildId=113811&view=artifacts&pathAsName=false&type=publishedArtifacts) and reference in your project. This fixes the issue which can be verified by running this sample app.