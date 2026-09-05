# Proctree

[![NuGet](https://img.shields.io/nuget/v/Proctree)](https://www.nuget.org/packages/Proctree)

A C# port of [proctree.js](https://github.com/supereggbert/proctree.js), Paul Brunt's
procedural tree generator, with the bark UV fix from Jari Komppa's
[C++ port](https://github.com/jarikomppa/proctree), and three extensions after Andrew
Marsh's [3D Tree Generator](https://drajmarsh.bitbucket.io/tree3d.html): crown shaping,
geometric leaves and radial branching for conifers. Every extension is off until set, and
until then the tree is proctree.js's. One file, no dependencies, .NET Standard 2.0.

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
documented in `Proctree.cs`. The bark's U runs once round each ring and the seam is split
into a duplicate vertex, the C++ port's fix, so a bark texture neither mirrors nor wraps;
the original ran U out and back. The extensions are BranchPitch and CrownExpansion for
the crown's shape, LeafCount with LeafDepth, LeafAspect and LeafOrientation for the
leaves, and RadialBranching for whorled conifers.

[presets.json](presets.json) holds settings for eleven species, with a typical height,
crown and trunk in metres and bark and foliage colours, as a starting point for
real-looking trees.
Found settings that make a good tree? See [Contributing](CONTRIBUTING.md).

## Licence

BSD 3-Clause, the original's licence, with its notice kept: see [LICENSE](LICENSE). The
port was checked against the original output for output, and the C++ port's UV fix is
under the same licence. The extensions follow Andrew Marsh's 3D Tree Generator, matched
from its exported meshes; its code was never read.
