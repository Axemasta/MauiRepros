# CollectionViewHandler2 Binding Issue

[![Maui Issue Status](https://img.shields.io/github/issues/detail/state/dotnet/maui/26620)](https://github.com/dotnet/maui/issues/26620)
This project contains a reproduction of a binding issue found when using `CollectionViewHandler2` on iOS.

> This project is called TouchBehaviorCollectionViewRepro because that is how I originally discovered the issue, however the issue is not specific to that behavior and can be reproduced with vanilla maui components, hence why it is raised against the main maui repro.

## Issue

After applying ordering to a collection, the data template bindings appear to stop working with respect to commands. The views will work properly upon first laod and execute their commands with the correct parameters, however once the collection gets modified and specifically a view that is already rendered has its place in the collection changed (either moved to another index or removed & readded), the command binding gets unset and the command can no longer execute.

This issue is resolved by switching back to the default CollectionView handler.

## Reproduction Steps

- Open this project
- Build & run on iOS (any device)
- Observe all items in the list can be interacted with and their commands execute properly
  <img src="assets/working-example.gif" width="400" />

- Either tap "A-Z" and then "Z-A" or tap "Shuffle" a few times, mix the collection up!
- Tap on any item

**Expected Result**
The item tap gesture command executes and the behavior works as it did initially

**Actual Result**
The item tap gesture command does not execute, nothing happens

<img src="assets/broken-example.gif" width="400" />

- In `MauiProgram.cs` comment out the `CollectionViewHandler2` line
- Rebuild and run the sample
- Perform the above steps
- Observe that the commands continue to work as expected even when the order of the collection is modified