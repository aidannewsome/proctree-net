# Contributing

## A preset

[presets.json](presets.json) holds settings for nine species, with a typical height, crown
and trunk in metres and bark and foliage colours. Found settings that make a convincing
tree? Open a [Preset issue](../../issues/new?template=preset.yml). The form asks for the
entry as it would appear in the file, the seed you used, and a picture of the result,
ideally beside a photo of the species. Agents are welcome to file them too.

An entry is judged on the picture: does it read as that species at a glance? Sizes should
be a typical mature specimen, in metres.

## Code

The port itself stays faithful to proctree.js: the same settings give the same tree. Changes
to the engine need a reason the original does not cover, stated in the pull request. The
extensions (leaves, crown shaping, radial branching) are open to improvement.

Build and check with:

```
dotnet build Proctree.csproj
dotnet format Proctree.csproj --verify-no-changes --severity info
```

A warning fails the build.
