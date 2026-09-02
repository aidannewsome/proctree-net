# Proctree

[![NuGet](https://img.shields.io/nuget/v/Proctree)](https://www.nuget.org/packages/Proctree)

A C# port of [proctree.js](https://github.com/supereggbert/proctree.js), Paul Brunt's
procedural tree generator, with geometric leaves, crown shaping and radial branching
added. One file, no dependencies, .NET Standard 2.0.

## Use

```
dotnet add package Proctree
```

A silver birch:

```csharp
var birch = new Proctree.Tree(new Proctree.Properties
{
    Seed = 262,
    Levels = 7,
    TreeSteps = 3.3,
    TrunkLength = 2.3,
    ClimbRate = 1.54,
    InitialBranchLength = 0.84,
    LengthFalloffFactor = 0.61,
    LengthFalloffPower = 0.51,
    ClumpMax = 0.0,
    ClumpMin = 0.555,
    BranchFactor = 1.35,
    DropAmount = 0.05,
    BranchPitch = 0.74,
    CrownExpansion = 0.48,
    TrunkKink = 0.05,
    TwistRate = 4.15,
    RadiusFalloffRate = 0.735,
    MaxRadius = 0.11,
    RootSpread = 4.0 / 3.0,
    TwigScale = 0.5,
    LeafCount = 5,
    LeafDepth = 0.654,
});

// Trunk and branches
birch.Vertices; birch.Faces; birch.Normals; birch.UV;

// Geometric leaves: many small triangles scattered around each branch tip, one leaf
// each, with a shade index from 0 to 19 to vary its colour. No texture needed.
// Made when LeafCount is set.
birch.LeafVertices; birch.LeafFaces; birch.LeafShades;

// Textured twigs, the alternative: one flat quad per branch tip to paint a leafy
// twig onto, with transparency around the leaves. Always made.
birch.TwigVertices; birch.TwigFaces; birch.TwigNormals; birch.TwigUV;
```

The tree is y-up in its own units; scale it to the height you want. Every property is
documented in `Proctree.cs`.

[presets.json](presets.json) holds settings for nine species, with a typical height, crown
and trunk in metres and bark and foliage colours, as a starting point for real-looking trees.

## Licence

BSD 3-Clause, the original's licence, with its notice kept: see [LICENSE](LICENSE). The
port was checked against the original output for output. The extensions follow Andrew
Marsh's [3D Tree Generator](https://drajmarsh.bitbucket.io/tree3d.html), matched from its
exported meshes; its code was never read.
