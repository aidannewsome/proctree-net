using System;
using System.Collections.Generic;

namespace Proctree;

/// <summary>Every setting the generator reads, defaulted as the original defaults
/// them. The names are proctree.js's under C# conventions, with its one spelling
/// slip (initalBranchLength) corrected.</summary>
public sealed class Properties
{
	/// <summary>How tightly a fork's children hug their parent's direction, at
	/// most.</summary>
	public double ClumpMax { get; set; } = 0.8;

	/// <summary>The least a fork's children hug their parent's direction.</summary>
	public double ClumpMin { get; set; } = 0.5;

	/// <summary>How much shorter each fork's children come out.</summary>
	public double LengthFalloffFactor { get; set; } = 0.85;

	/// <summary>Bends the length falloff: below one, outer branches hold their
	/// length longer.</summary>
	public double LengthFalloffPower { get; set; } = 1;

	/// <summary>How hard the second child of a fork mirrors away from the
	/// first.</summary>
	public double BranchFactor { get; set; } = 2.0;

	/// <summary>How much thinner a fork's children come out.</summary>
	public double RadiusFalloffRate { get; set; } = 0.6;

	/// <summary>Each trunk segment's climb.</summary>
	public double ClimbRate { get; set; } = 1.5;

	/// <summary>How far each trunk segment kinks off the vertical.</summary>
	public double TrunkKink { get; set; } = 0.0;

	/// <summary>The trunk's radius at the ground.</summary>
	public double MaxRadius { get; set; } = 0.25;

	/// <summary>How many segments the trunk climbs before it is all crown, shedding
	/// one limb at each. Fractions count: 3.8 climbs four segments, the last one
	/// nearly done twisting.</summary>
	public double TreeSteps { get; set; } = 2;

	/// <summary>How much the trunk thins at each climbed segment.</summary>
	public double TaperRate { get; set; } = 0.95;

	/// <summary>How much each trunk segment's shed limb rotates around the
	/// trunk.</summary>
	public double TwistRate { get; set; } = 13;

	/// <summary>Vertices per branch ring. Even numbers only: forks weld half a ring
	/// to each child.</summary>
	public int Segments { get; set; } = 6;

	/// <summary>How many times branches fork.</summary>
	public int Levels { get; set; } = 3;

	/// <summary>A sideways lean the whole crown shares.</summary>
	public double SweepAmount { get; set; } = 0;

	/// <summary>The first branches' length; each fork's children shrink from
	/// there.</summary>
	public double InitialBranchLength { get; set; } = 0.85;

	/// <summary>Ground to the first fork.</summary>
	public double TrunkLength { get; set; } = 2.5;

	/// <summary>How much outer branches sag toward the ground; negative
	/// lifts.</summary>
	public double DropAmount { get; set; } = 0.0;

	/// <summary>How much the crown pushes up and out as it grows.</summary>
	public double GrowAmount { get; set; } = 0.0;

	/// <summary>Stretches bark texture coordinates along the branches.</summary>
	public double VMultiplier { get; set; } = 0.2;

	/// <summary>The size of the leaf quads at branch ends.</summary>
	public double TwigScale { get; set; } = 2.0;

	/// <summary>Fixes every random choice: the same settings and seed grow the same
	/// tree forever.</summary>
	public int Seed { get; set; } = 10;

	// The extensions. Each is unset by default, leaving the original's behaviour
	// untouched; setting one activates it.

	/// <summary>How branches pitch off the trunk: positive climbs, negative droops,
	/// strongest at the first branches and fading with each level, so the rest of
	/// the crown follows the first. Takes GrowAmount's place in the lift when
	/// set.</summary>
	public double? BranchPitch { get; set; }

	/// <summary>How much longer (above one) or shorter (below one) the trunk's
	/// branches grow with each climbed segment: the crown widening upward. Replaces
	/// TaperRate in the trunk's length falloff when set.</summary>
	public double? CrownExpansion { get; set; }

	/// <summary>The ground ring's spread as a multiple of the trunk radius. Unset,
	/// the original's radius over RadiusFalloffRate.</summary>
	public double? RootSpread { get; set; }

	/// <summary>Leaves per branch tip. Setting this generates geometric leaves,
	/// single triangles scattered around each branch end, sized by TwigScale, in
	/// LeafVertices, LeafFaces and LeafShades.</summary>
	public int? LeafCount { get; set; }

	/// <summary>Extra leaves thickening the canopy: each tip's count multiplies by
	/// one plus this.</summary>
	public double LeafDepth { get; set; }

	/// <summary>How far leaves reach out along their branch, as a multiplier on the
	/// scatter; one reaches about two TwigScales past the tip.</summary>
	public double LeafAspect { get; set; } = 1;

	/// <summary>How far leaves swirl around their branch's axis off their scattered
	/// position, up to about a radian and a half at one.</summary>
	public double LeafOrientation { get; set; }

	/// <summary>How far a frond's tip arcs toward the ground, in the tree's own
	/// units: the spine leaves straight and sags quadratically, the way palm fronds
	/// arch. Zero keeps fronds straight. Radial branching only.</summary>
	public double LeafDroop { get; set; }

	/// <summary>Where along a frond its leaflets start, as a fraction of the frond's
	/// length. The original's own conifers leave the inner two thirds bare, which is
	/// the default; a palm sets a smaller share, so leaflets run most of the frond and
	/// no bare stem shows through the crown.</summary>
	public double LeafZone { get; set; } = 2.0 / 3.0;

	/// <summary>How much fronds shrink climbing the stem, zero to one: one shrinks
	/// them to nothing at the top, the way a conifer tapers, zero keeps every whorl's
	/// fronds full, the way a palm's crown is all one age of leaf. Radial branching
	/// only.</summary>
	public double LeafTaper { get; set; } = 1;

	/// <summary>Grows whorls of straight limbs radiating from a single stem instead
	/// of forking branches: conifers and palms. Levels becomes limbs per whorl, the
	/// length settings shape each whorl's reach, BranchPitch and DropAmount lift or
	/// sink the limb tips, and leaves become paired leaflets along each
	/// frond.</summary>
	public bool RadialBranching { get; set; }

	/// <summary>How much the stem thins at each whorl. The original's own conifers
	/// hold a constant three quarters, which is the default; a palm sets one, so its
	/// trunk carries its full width all the way to the crown.</summary>
	public double StemTaper { get; set; } = 0.75;

	/// <summary>How far the whorls' rises fan apart, in the tree's own units: the
	/// lowest whorl sinks half of this and the highest climbs half. With whorls
	/// stacked tightly it grows a palm's crown of ages, young fronds climbing from
	/// the centre over old ones hanging at the rim. Zero keeps every whorl's rise
	/// the same. Radial branching only.</summary>
	public double BranchPitchRange { get; set; }

	internal double Rseed;

	/// <summary>The original's pure random: |cos(a + a²)|, falling back to a running
	/// seed when asked with zero.</summary>
	internal double Random(double at)
	{
		if (at == 0)
		{
			at = Rseed;
			Rseed += 1;
		}
		return Math.Abs(Math.Cos(at + at * at));
	}
}

/// <summary>One generated tree, grown once in the constructor: the bark mesh
/// (Vertices, Faces as quads between rings, Normals, UV) and the twig mesh of leaf quads at branch ends
/// (TwigVertices, TwigFaces, TwigNormals, TwigUV). A port of proctree.js
/// (Paul Brunt, BSD 3-Clause: see LICENSE).</summary>
public sealed class Tree
{
	readonly List<Vector3> vertices = [];
	readonly List<Face> faces = [];
	readonly List<Vector3> twigVertices = [];
	readonly List<Vector3> twigNormals = [];
	readonly List<Face> twigFaces = [];
	readonly List<Vector2> twigUV = [];
	readonly List<Vector3> leafVertices = [];
	readonly List<Face> leafFaces = [];
	readonly List<double> leafShades = [];
	Vector3[] normals;
	readonly Vector2[] uv;

	// A fixed shade sequence for leaves, cycling with the leaf counter: 0..19,
	// read as twentieths of the way from a foliage colour to its highlight.
	static readonly byte[] Shades =
	[
		2, 11, 16, 10, 10, 8, 7, 3, 8, 3, 3, 13, 15, 0, 12, 17, 3, 11, 4, 5, 14, 12,
		6, 14, 15, 8, 2, 15, 2, 13, 1, 11, 4, 8, 5, 15, 5, 7, 10, 1, 8, 12, 8, 3, 8,
		7, 4, 16, 19, 1, 19, 2, 4, 5, 18, 14, 10, 3, 16, 8, 13, 10, 4, 10, 10, 13, 5,
		16, 10, 17, 6, 17, 10, 7, 16, 3, 18, 7, 2, 4, 11, 6, 10, 14, 5, 3, 10, 16, 4,
		17, 18, 1, 14, 19, 8, 7, 7, 5, 11, 19, 19, 14, 0, 3, 5, 19, 17, 11, 6, 12, 15,
		6, 18, 2, 16, 11, 7, 7, 2, 19, 18, 5, 2, 2, 12, 3, 7, 9,
	];

	public Properties Properties { get; }

	public IReadOnlyList<Vector3> Vertices => vertices;

	public IReadOnlyList<Face> Faces => faces;

	public IReadOnlyList<Vector3> Normals => normals;

	public IReadOnlyList<Vector2> UV => uv;

	public IReadOnlyList<Vector3> TwigVertices => twigVertices;

	public IReadOnlyList<Face> TwigFaces => twigFaces;

	public IReadOnlyList<Vector3> TwigNormals => twigNormals;

	public IReadOnlyList<Vector2> TwigUV => twigUV;

	public IReadOnlyList<Vector3> LeafVertices => leafVertices;

	public IReadOnlyList<Face> LeafFaces => leafFaces;

	/// <summary>One value per leaf, 0..0.95 in twentieths: how far from the foliage
	/// colour toward its highlight the leaf shades.</summary>
	public IReadOnlyList<double> LeafShades => leafShades;

	/// <summary>The trunk's first branch, from which the whole forking skeleton hangs:
	/// each branch has its head, length, radius and two children. Null for radial
	/// branching, which builds whorls rather than a branch tree.</summary>
	public Branch Root { get; }

	public Tree(Properties properties = null)
	{
		Properties = properties ?? new Properties();
		Properties.Rseed = Properties.Seed;
		if (Properties.RadialBranching)
		{
			CreateWhorls(CreateStem());
			uv = new Vector2[vertices.Count];
			CalculateNormals();
			return;
		}
		var root = new Branch(new Vector3(0, Properties.TrunkLength, 0))
		{
			Length = Properties.InitialBranchLength,
		};
		Root = root;
		root.Split(Properties.Levels, Properties.TreeSteps, Properties);
		CreateForks(root, Properties.MaxRadius);
		CreateTwigs(root);
		if (Properties.LeafCount.HasValue)
			CreateLeaves(root);
		uv = new Vector2[vertices.Count];
		CreateFaces(root);
		CalculateNormals();
	}

	/// <summary>The radial stem: a ground ring, one ring per climbed segment, and a
	/// near-point top at the fractional last step, banded into a tube. Returns the
	/// ring centres for the whorls to sit on. An extension; the original forks
	/// only.</summary>
	List<Vector3> CreateStem()
	{
		var p = Properties;
		int whorlCount = (int)Math.Ceiling(p.TreeSteps);
		int segments = p.Segments;
		double segmentAngle = Math.PI * 2 / segments;
		double baseRadius = Math.Min(p.MaxRadius, p.InitialBranchLength);

		var centers = new List<Vector3> { new(0, 0, 0) };
		double cx = 0, cz = 0;
		for (int k = 0; k < whorlCount; k++)
		{
			cx += (p.Random(0) - 0.5) * p.TrunkKink;
			cz += (p.Random(0) - 0.5) * p.TrunkKink;
			centers.Add(new Vector3(cx, p.TrunkLength + p.ClimbRate * k, cz));
		}
		centers.Add(new Vector3(cx, p.TrunkLength + p.ClimbRate * p.TreeSteps, cz));
		for (int ring = 0; ring < centers.Count; ring++)
		{
			double radius = ring == 0
				? baseRadius * (p.RootSpread ?? 4.0 / 3.0)
				: Math.Max(baseRadius * Math.Pow(p.StemTaper, ring - 1), 0.001);
			for (int i = 0; i < segments; i++)
			{
				Vector3 vec = new Vector3(-1, 0, 0).AxisAngle(new Vector3(0, 1, 0), -segmentAngle * i);
				vertices.Add(centers[ring] + vec * radius);
			}
		}
		for (int ring = 0; ring + 1 < centers.Count; ring++)
			for (int i = 0; i < segments; i++)
			{
				int a = ring * segments + i;
				int b = ring * segments + (i + 1) % segments;
				int c = (ring + 1) * segments + i;
				int d = (ring + 1) * segments + (i + 1) % segments;
				faces.Add(new Face(a, b, d, c));
			}
		return centers;
	}

	/// <summary>The whorls: straight cone limbs radiating at each climbed segment,
	/// reaching a target radius that starts at four first-lengths and falls off by
	/// the length settings. Each limb tip rises by BranchPitch times ClimbRate plus
	/// DropAmount: the pitch rides the segment climb, which the original's exports
	/// prove exactly. Fronds march along each limb's ray from the stem's axis.</summary>
	void CreateWhorls(List<Vector3> centers)
	{
		var p = Properties;
		int whorlCount = (int)Math.Ceiling(p.TreeSteps);
		int segments = p.Segments;
		double segmentAngle = Math.PI * 2 / segments;
		double baseRadius = Math.Min(p.MaxRadius, p.InitialBranchLength);
		double crown = p.CrownExpansion ?? 1;
		double crownStep = crown < 1 ? crown : (1 + crown) / 2;
		double baseRise = (p.BranchPitch ?? 0) * p.ClimbRate + p.DropAmount;
		double reach = 4 * p.InitialBranchLength;
		int limbs = p.Levels;
		for (int k = 0; k < whorlCount; k++)
		{
			double rise = baseRise + p.BranchPitchRange
				* (whorlCount > 1 ? (double)k / (whorlCount - 1) - 0.5 : 0);
			reach = Math.Pow(reach, p.LengthFalloffPower) * p.LengthFalloffFactor * crownStep;
			double whorlBase = p.Random(0) * 2 * Math.PI + k * p.TwistRate;
			double limbRadius = baseRadius * Math.Pow(p.StemTaper, k + 1) * p.RadiusFalloffRate / 2;
			double leafSize = 1 - p.LeafTaper * ((double)k / p.TreeSteps);
			for (int j = 0; j < limbs; j++)
			{
				double azimuth = whorlBase + j * 2 * Math.PI / limbs + (p.Random(0) - 0.5) * 0.9;
				var flat = new Vector3(Math.Sin(azimuth), 0, Math.Cos(azimuth));
				Vector3 start = centers[k + 1] + flat * (baseRadius * Math.Pow(p.StemTaper, k + 1));
				var tip = new Vector3(flat.X * reach, centers[k + 1].Y + rise, flat.Z * reach);
				Vector3 dir = (tip - start).Normalized;
				Vector3 side = Vector3.Cross(new Vector3(0, 1, 0), dir).Normalized;
				Vector3 up = Vector3.Cross(dir, side);
				int ringStart = vertices.Count;
				for (int i = 0; i < segments; i++)
				{
					double angle = segmentAngle * i;
					vertices.Add(start + (side * Math.Cos(angle) + up * Math.Sin(angle)) * limbRadius);
				}
				int tipIndex = vertices.Count;
				vertices.Add(tip);
				for (int i = 0; i < segments; i++)
					faces.Add(new Face(ringStart + i, ringStart + (i + 1) % segments, tipIndex));

				if (p.LeafCount.HasValue)
				{
					// The frond rides the ray from the stem's axis through the tip,
					// not the woody limb, so short high limbs still carry full
					// fronds; the exports show exactly this. Age hangs low: the
					// lowest whorl bends the full LeafDroop, the youngest barely.
					var axis = new Vector3(0, centers[k + 1].Y, 0);
					Vector3 ray = (tip - axis).Normalized;
					Vector3 raySide = Vector3.Cross(new Vector3(0, 1, 0), ray).Normalized;
					double age = whorlCount > 1 ? 1 - (double)k / (whorlCount - 1) : 1;
					CreateFrond(axis, ray, raySide, Vector3.Cross(ray, raySide),
						(tip - axis).Length, leafSize, p.LeafDroop * age);
				}
			}
		}
	}

	/// <summary>One frond's leaflets: mirrored triangle pairs sharing spine
	/// segments, wings arcing to a peak mid-frond. The zone starts two thirds of
	/// the way out (never closer than a floor that keeps short high limbs leafy)
	/// and marches past the woody tip.</summary>
	void CreateFrond(Vector3 start, Vector3 dir, Vector3 side, Vector3 up, double length, double sizeScale, double droop)
	{
		var p = Properties;
		int count = p.LeafCount.Value;
		int pairs = Math.Max(1, (int)Math.Ceiling(count * (1 + p.LeafDepth)) - 1);
		double frondScale = sizeScale * (0.85 + 0.3 * p.Random(0));
		double span = 1.8 * p.TwigScale * p.LeafAspect / pairs * frondScale;
		double spacing = 0.95 * span;
		double wingReach = 0.9 * p.TwigScale * p.LeafAspect * frondScale;
		double zoneStart = Math.Max(length * p.LeafZone, 0.12 * p.LeafZone);
		double zone = spacing * (pairs - 1) + span;
		var sag = new Vector3(0, -droop, 0);
		for (int pair = 0; pair < pairs; pair++)
		{
			double at = zoneStart + spacing * pair;
			Vector3 Sagged(double along) =>
				start + dir * along
				+ sag * ((along - zoneStart) / zone * ((along - zoneStart) / zone));
			Vector3 spineA = Sagged(at);
			Vector3 spineB = Sagged(at + span);
			Vector3 mid = Sagged(at + span / 2);
			double wingLength = wingReach * Math.Sin(Math.PI * (pair + 1) / (pairs + 1));
			double wingAngle = -1.2374 * (1 - p.LeafOrientation) + (p.Random(0) - 0.5) * 0.4;
			Vector3 wing = (side * Math.Cos(wingAngle) + up * Math.Sin(wingAngle)) * wingLength;
			int at0 = leafVertices.Count;
			leafVertices.Add(spineA);
			leafVertices.Add(mid + wing);
			leafVertices.Add(spineB);
			leafVertices.Add(spineB);
			leafVertices.Add(mid - wing);
			leafVertices.Add(spineA);
			leafFaces.Add(new Face(at0, at0 + 1, at0 + 2));
			leafFaces.Add(new Face(at0 + 3, at0 + 4, at0 + 5));
			leafShades.Add(Shades[leafShades.Count % Shades.Length] / 20.0);
			leafShades.Add(Shades[leafShades.Count % Shades.Length] / 20.0);
		}
	}

	void CreateForks(Branch branch, double radius)
	{
		branch.Radius = radius;
		if (radius > branch.Length)
			radius = branch.Length;

		int segments = Properties.Segments;
		double segmentAngle = Math.PI * 2 / segments;

		if (branch.Parent == null)
		{
			// The ring the tree stands on.
			branch.Root = [];
			var axis = new Vector3(0, 1, 0);
			double ringRadius = Properties.RootSpread.HasValue
				? radius * Properties.RootSpread.Value
				: radius / Properties.RadiusFalloffRate;
			for (int i = 0; i < segments; i++)
			{
				Vector3 vec = new Vector3(-1, 0, 0).AxisAngle(axis, -segmentAngle * i);
				branch.Root.Add(vertices.Count);
				vertices.Add(vec * ringRadius);
			}
		}

		if (branch.Child0 != null)
		{
			Vector3 axis = branch.Parent != null
				? (branch.Head - branch.Parent.Head).Normalized
				: branch.Head.Normalized;

			Vector3 axis1 = (branch.Head - branch.Child0.Head).Normalized;
			Vector3 axis2 = (branch.Head - branch.Child1.Head).Normalized;
			Vector3 tangent = Vector3.Cross(axis1, axis2).Normalized;
			branch.Tangent = tangent;

			Vector3 axis3 = Vector3.Cross(tangent, (axis1 * -1 + axis2 * -1).Normalized).Normalized;
			var dir = new Vector3(axis2.X, 0, axis2.Z);
			Vector3 centerloc = branch.Head + dir * (-Properties.MaxRadius / 2);

			var ring0 = branch.Ring0 = [];
			var ring1 = branch.Ring1 = [];
			var ring2 = branch.Ring2 = [];

			double scale = Properties.RadiusFalloffRate;
			if (branch.Child0.Trunk || branch.Trunk)
				scale = 1 / Properties.TaperRate;

			// The fork's shared ring: half welds to each child, the two linch
			// vertices to both.
			int linch0 = vertices.Count;
			ring0.Add(linch0);
			ring2.Add(linch0);
			vertices.Add(centerloc + tangent * (radius * scale));

			int start = vertices.Count - 1;
			Vector3 d1 = tangent.AxisAngle(axis2, 1.57);
			Vector3 d2 = Vector3.Cross(tangent, axis).Normalized;
			double s = 1 / Vector3.Dot(d1, d2);
			for (int i = 1; i < segments / 2; i++)
			{
				Vector3 vec = tangent.AxisAngle(axis2, segmentAngle * i);
				ring0.Add(start + i);
				ring2.Add(start + i);
				vec = vec.ScaleInDirection(d2, s);
				vertices.Add(centerloc + vec * (radius * scale));
			}
			int linch1 = vertices.Count;
			ring0.Add(linch1);
			ring1.Add(linch1);
			vertices.Add(centerloc + tangent * (-radius * scale));
			for (int i = segments / 2 + 1; i < segments; i++)
			{
				Vector3 vec = tangent.AxisAngle(axis1, segmentAngle * i);
				ring0.Add(vertices.Count);
				ring1.Add(vertices.Count);
				vertices.Add(centerloc + vec * (radius * scale));
			}
			ring1.Add(linch0);
			ring2.Add(linch1);
			start = vertices.Count - 1;
			for (int i = 1; i < segments / 2; i++)
			{
				Vector3 vec = tangent.AxisAngle(axis3, segmentAngle * i);
				ring1.Add(start + i);
				ring2.Add(start + (segments / 2 - i));
				vertices.Add(centerloc + vec * (radius * scale));
			}

			double radius0 = radius * Properties.RadiusFalloffRate;
			double radius1 = radius * Properties.RadiusFalloffRate;
			if (branch.Child0.Trunk)
				radius0 = radius * Properties.TaperRate;
			CreateForks(branch.Child0, radius0);
			CreateForks(branch.Child1, radius1);
		}
		else
		{
			// The tip of an unsplit branch.
			branch.End = vertices.Count;
			vertices.Add(branch.Head);
		}
	}

	void CreateTwigs(Branch branch)
	{
		if (branch.Child0 == null)
		{
			Vector3 tangent = Vector3.Cross(
				branch.Parent.Child0.Head - branch.Parent.Head,
				branch.Parent.Child1.Head - branch.Parent.Head).Normalized;
			Vector3 binormal = (branch.Head - branch.Parent.Head).Normalized;

			double twigScale = Properties.TwigScale;
			int vert1 = twigVertices.Count;
			twigVertices.Add(branch.Head + tangent * twigScale + binormal * (twigScale * 2 - branch.Length));
			int vert2 = twigVertices.Count;
			twigVertices.Add(branch.Head + tangent * -twigScale + binormal * (twigScale * 2 - branch.Length));
			int vert3 = twigVertices.Count;
			twigVertices.Add(branch.Head + tangent * -twigScale + binormal * -branch.Length);
			int vert4 = twigVertices.Count;
			twigVertices.Add(branch.Head + tangent * twigScale + binormal * -branch.Length);

			int vert8 = twigVertices.Count;
			twigVertices.Add(branch.Head + tangent * twigScale + binormal * (twigScale * 2 - branch.Length));
			int vert7 = twigVertices.Count;
			twigVertices.Add(branch.Head + tangent * -twigScale + binormal * (twigScale * 2 - branch.Length));
			int vert6 = twigVertices.Count;
			twigVertices.Add(branch.Head + tangent * -twigScale + binormal * -branch.Length);
			int vert5 = twigVertices.Count;
			twigVertices.Add(branch.Head + tangent * twigScale + binormal * -branch.Length);

			twigFaces.Add(new Face(vert1, vert2, vert3));
			twigFaces.Add(new Face(vert4, vert1, vert3));
			twigFaces.Add(new Face(vert6, vert7, vert8));
			twigFaces.Add(new Face(vert6, vert8, vert5));

			Vector3 normal = Vector3.Cross(
				twigVertices[vert1] - twigVertices[vert3],
				twigVertices[vert2] - twigVertices[vert3]).Normalized;
			Vector3 normal2 = Vector3.Cross(
				twigVertices[vert7] - twigVertices[vert6],
				twigVertices[vert8] - twigVertices[vert6]).Normalized;

			twigNormals.Add(normal);
			twigNormals.Add(normal);
			twigNormals.Add(normal);
			twigNormals.Add(normal);
			twigNormals.Add(normal2);
			twigNormals.Add(normal2);
			twigNormals.Add(normal2);
			twigNormals.Add(normal2);

			twigUV.Add(new Vector2(0, 1));
			twigUV.Add(new Vector2(1, 1));
			twigUV.Add(new Vector2(1, 0));
			twigUV.Add(new Vector2(0, 0));
			twigUV.Add(new Vector2(0, 1));
			twigUV.Add(new Vector2(1, 1));
			twigUV.Add(new Vector2(1, 0));
			twigUV.Add(new Vector2(0, 0));
		}
		else
		{
			CreateTwigs(branch.Child0);
			CreateTwigs(branch.Child1);
		}
	}

	/// <summary>Geometric leaves: single random triangles scattered around each
	/// branch end, anchored between halfway back along the tip branch and
	/// LeafAspect reaches past it, sized by TwigScale, shaded from the fixed
	/// sequence. An extension; the original grows textured twigs only.</summary>
	void CreateLeaves(Branch branch)
	{
		if (branch.Child0 == null)
		{
			Vector3 tangent = Vector3.Cross(
				branch.Parent.Child0.Head - branch.Parent.Head,
				branch.Parent.Child1.Head - branch.Parent.Head).Normalized;
			Vector3 binormal = (branch.Head - branch.Parent.Head).Normalized;
			Vector3 normal = Vector3.Cross(tangent, binormal);

			double exact = Properties.LeafCount.Value * (1 + Properties.LeafDepth);
			int count = (int)exact;
			if (Properties.Random(0) < exact - count)
				count++;
			for (int leaf = 0; leaf < count; leaf++)
			{
				double reach = Properties.Random(0);
				double radius = Properties.Random(0) * Properties.TwigScale;
				double angle = Properties.Random(0) * 2 * Math.PI
					+ Properties.LeafOrientation * (Properties.Random(0) - 0.25) * 2;
				Vector3 anchor = branch.Head
					+ binormal * (-branch.Length / 2 + Properties.LeafAspect * reach * 2 * Properties.TwigScale)
					+ tangent * (Math.Cos(angle) * radius)
					+ normal * (Math.Sin(angle) * radius);
				int start = leafVertices.Count;
				leafVertices.Add(anchor);
				leafVertices.Add(anchor + Scatter(tangent, binormal, normal));
				leafVertices.Add(anchor + Scatter(tangent, binormal, normal));
				leafFaces.Add(new Face(start, start + 1, start + 2));
				leafShades.Add(Shades[leafShades.Count % Shades.Length] / 20.0);
			}
		}
		else
		{
			CreateLeaves(branch.Child0);
			CreateLeaves(branch.Child1);
		}
	}

	Vector3 Scatter(Vector3 tangent, Vector3 binormal, Vector3 normal) =>
		tangent * ((Properties.Random(0) - 0.5) * 1.2 * Properties.TwigScale)
		+ binormal * ((Properties.Random(0) - 0.5) * 1.2 * Properties.TwigScale)
		+ normal * ((Properties.Random(0) - 0.5) * 1.2 * Properties.TwigScale);

	void CreateFaces(Branch branch)
	{
		int segments = Properties.Segments;

		if (branch.Parent == null)
		{
			// Band the ground ring to the first fork's ring, rotated to face it.
			Vector3 tangent = Vector3.Cross(
				branch.Child0.Head - branch.Head,
				branch.Child1.Head - branch.Head).Normalized;
			Vector3 normal = branch.Head.Normalized;
			double angle = Math.Acos(Vector3.Dot(tangent, new Vector3(-1, 0, 0)));
			if (Vector3.Dot(Vector3.Cross(new Vector3(-1, 0, 0), tangent), normal) > 0)
				angle = 2 * Math.PI - angle;
			int segOffset = (int)RoundHalfUp(angle / Math.PI / 2 * segments);
			for (int i = 0; i < segments; i++)
			{
				int v1 = branch.Ring0[i];
				int v2 = branch.Root[(i + segOffset + 1) % segments];
				int v3 = branch.Root[(i + segOffset) % segments];
				int v4 = branch.Ring0[(i + 1) % segments];

				faces.Add(new Face(v1, v4, v2, v3));
				uv[(i + segOffset) % segments] =
					new Vector2(Math.Abs(i / (double)segments - 0.5) * 2, 0);
				double len = (vertices[branch.Ring0[i]] - vertices[branch.Root[(i + segOffset) % segments]]).Length
					* Properties.VMultiplier;
				uv[branch.Ring0[i]] = new Vector2(Math.Abs(i / (double)segments - 0.5) * 2, len);
				uv[branch.Ring2[i]] = new Vector2(Math.Abs(i / (double)segments - 0.5) * 2, len);
			}
		}

		if (branch.Child0.Ring0 != null)
		{
			// Band each child's ring to its half of the fork ring, matching the
			// closest segment so the weld does not twist.
			int segOffset0 = 0, segOffset1 = 0;
			double match0 = 0, match1 = 0;
			bool found0 = false, found1 = false;

			Vector3 v1 = (vertices[branch.Ring1[0]] - branch.Head).Normalized;
			Vector3 v2 = (vertices[branch.Ring2[0]] - branch.Head).Normalized;

			v1 = v1.ScaleInDirection((branch.Child0.Head - branch.Head).Normalized, 0);
			v2 = v2.ScaleInDirection((branch.Child1.Head - branch.Head).Normalized, 0);

			for (int i = 0; i < segments; i++)
			{
				Vector3 d = (vertices[branch.Child0.Ring0[i]] - branch.Child0.Head).Normalized;
				double l = Vector3.Dot(d, v1);
				if (!found0 || l > match0)
				{
					found0 = true;
					match0 = l;
					segOffset0 = segments - i;
				}
				d = (vertices[branch.Child1.Ring0[i]] - branch.Child1.Head).Normalized;
				l = Vector3.Dot(d, v2);
				if (!found1 || l > match1)
				{
					found1 = true;
					match1 = l;
					segOffset1 = segments - i;
				}
			}

			double uvScale = Properties.MaxRadius / branch.Radius;

			for (int i = 0; i < segments; i++)
			{
				int f1 = branch.Child0.Ring0[i];
				int f2 = branch.Ring1[(i + segOffset0 + 1) % segments];
				int f3 = branch.Ring1[(i + segOffset0) % segments];
				int f4 = branch.Child0.Ring0[(i + 1) % segments];
				faces.Add(new Face(f1, f4, f2, f3));
				f1 = branch.Child1.Ring0[i];
				f2 = branch.Ring2[(i + segOffset1 + 1) % segments];
				f3 = branch.Ring2[(i + segOffset1) % segments];
				f4 = branch.Child1.Ring0[(i + 1) % segments];
				faces.Add(new Face(f1, f4, f2, f3));

				double len1 = (vertices[branch.Child0.Ring0[i]]
					- vertices[branch.Ring1[(i + segOffset0) % segments]]).Length * uvScale;
				Vector2 uv1 = uv[branch.Ring1[(i + segOffset0 - 1) % segments]];

				uv[branch.Child0.Ring0[i]] = new Vector2(uv1.X, uv1.Y + len1 * Properties.VMultiplier);
				uv[branch.Child0.Ring2[i]] = new Vector2(uv1.X, uv1.Y + len1 * Properties.VMultiplier);

				double len2 = (vertices[branch.Child1.Ring0[i]]
					- vertices[branch.Ring2[(i + segOffset1) % segments]]).Length * uvScale;
				Vector2 uv2 = uv[branch.Ring2[(i + segOffset1 - 1) % segments]];

				uv[branch.Child1.Ring0[i]] = new Vector2(uv2.X, uv2.Y + len2 * Properties.VMultiplier);
				uv[branch.Child1.Ring2[i]] = new Vector2(uv2.X, uv2.Y + len2 * Properties.VMultiplier);
			}

			CreateFaces(branch.Child0);
			CreateFaces(branch.Child1);
		}
		else
		{
			// Fan each child's half ring to its tip.
			for (int i = 0; i < segments; i++)
			{
				faces.Add(new Face(branch.Child0.End, branch.Ring1[(i + 1) % segments], branch.Ring1[i]));
				faces.Add(new Face(branch.Child1.End, branch.Ring2[(i + 1) % segments], branch.Ring2[i]));

				double len = (vertices[branch.Child0.End] - vertices[branch.Ring1[i]]).Length;
				uv[branch.Child0.End] =
					new Vector2(Math.Abs(i / (double)segments - 1 - 0.5) * 2, len * Properties.VMultiplier);
				len = (vertices[branch.Child1.End] - vertices[branch.Ring2[i]]).Length;
				uv[branch.Child1.End] =
					new Vector2(Math.Abs(i / (double)segments - 0.5) * 2, len * Properties.VMultiplier);
			}
		}
	}

	void CalculateNormals()
	{
		var gathered = new List<Vector3>[vertices.Count];
		for (int i = 0; i < vertices.Count; i++)
			gathered[i] = [];
		foreach (Face face in faces)
		{
			Vector3 norm = Vector3.Cross(
				vertices[face.B] - vertices[face.C],
				vertices[face.B] - vertices[face.A]).Normalized;
			gathered[face.A].Add(norm);
			gathered[face.B].Add(norm);
			gathered[face.C].Add(norm);
			if (face.IsQuad)
				gathered[face.D].Add(norm);
		}
		normals = new Vector3[vertices.Count];
		for (int i = 0; i < gathered.Length; i++)
		{
			var total = new Vector3(0, 0, 0);
			int count = gathered[i].Count;
			foreach (Vector3 norm in gathered[i])
				total += norm * (1.0 / count);
			normals[i] = total;
		}
	}

	// JavaScript's Math.round, which the original leans on: half rounds up, not to
	// even.
	static double RoundHalfUp(double value) => Math.Floor(value + 0.5);
}

/// <summary>One branch of the growing structure: a head position and, after
/// splitting, two children. The trunk is the chain of branches flagged Trunk.</summary>
public sealed class Branch
{
	public Vector3 Head;
	public Branch Parent;
	public Branch Child0;
	public Branch Child1;
	public double Length = 1;
	public bool Trunk;
	public double Radius;
	public Vector3 Tangent;
	public int End;
	public List<int> Root;
	public List<int> Ring0;
	public List<int> Ring1;
	public List<int> Ring2;

	public Branch(Vector3 head, Branch parent = null)
	{
		Head = head;
		Parent = parent;
	}

	Vector3 MirrorBranch(Vector3 vec, Vector3 norm, Properties properties)
	{
		Vector3 v = Vector3.Cross(norm, Vector3.Cross(vec, norm));
		double s = properties.BranchFactor * Vector3.Dot(v, vec);
		return new Vector3(vec.X - v.X * s, vec.Y - v.Y * s, vec.Z - v.Z * s);
	}

	public void Split(int level, double steps, Properties properties, int l1 = 1, int l2 = 1)
	{
		int rLevel = properties.Levels - level;
		Vector3 po;
		if (Parent != null)
		{
			po = Parent.Head;
		}
		else
		{
			po = new Vector3(0, 0, 0);
			Trunk = true;
		}
		Vector3 so = Head;
		Vector3 dir = (so - po).Normalized;

		Vector3 normal = Vector3.Cross(dir, new Vector3(dir.Z, dir.X, dir.Y));
		Vector3 tangent = Vector3.Cross(dir, normal);
		double r = properties.Random(rLevel * 10 + l1 * 5 + l2 + properties.Seed);
		// The original draws a second value it never reads; drawing it keeps the
		// running-seed state identical.
		properties.Random(rLevel * 10 + l1 * 5 + l2 + 1 + properties.Seed);

		Vector3 adj = normal * r + tangent * (1 - r);
		if (r > 0.5)
			adj *= -1;

		double clump = (properties.ClumpMax - properties.ClumpMin) * r + properties.ClumpMin;
		Vector3 newDir = (adj * (1 - clump) + dir * clump).Normalized;

		Vector3 newDir2 = MirrorBranch(newDir, dir, properties);
		if (r > 0.5)
			(newDir, newDir2) = (newDir2, newDir);
		if (steps > 0)
		{
			double angle = steps / properties.TreeSteps * 2 * Math.PI * properties.TwistRate;
			newDir2 = new Vector3(Math.Sin(angle), r, Math.Cos(angle)).Normalized;
		}

		double grow = level * level / (double)(properties.Levels * properties.Levels)
			* (properties.BranchPitch ?? properties.GrowAmount);
		double drop = rLevel * properties.DropAmount;
		double sweep = rLevel * properties.SweepAmount;
		newDir = (newDir + new Vector3(sweep, drop + grow, 0)).Normalized;
		newDir2 = (newDir2 + new Vector3(sweep, drop + grow, 0)).Normalized;

		Vector3 head0 = so + newDir * Length;
		Vector3 head1 = so + newDir2 * Length;
		Child0 = new Branch(head0, this);
		Child1 = new Branch(head1, this);
		Child0.Length = Math.Pow(Length, properties.LengthFalloffPower) * properties.LengthFalloffFactor;
		Child1.Length = Math.Pow(Length, properties.LengthFalloffPower) * properties.LengthFalloffFactor;
		if (level > 0)
		{
			if (steps > 0)
			{
				Child0.Head = Head + new Vector3(
					(r - 0.5) * 2 * properties.TrunkKink,
					properties.ClimbRate,
					(r - 0.5) * 2 * properties.TrunkKink);
				Child0.Trunk = true;
				Child0.Length = Length * (properties.CrownExpansion ?? properties.TaperRate);
				Child0.Split(level, steps - 1, properties, l1 + 1, l2);
			}
			else
			{
				Child0.Split(level - 1, 0, properties, l1 + 1, l2);
			}
			Child1.Split(level - 1, 0, properties, l1, l2 + 1);
		}
	}
}

/// <summary>One face: four vertex indices for a quad, the last repeated for a
/// triangle, wound as the generator emitted them. Bark bands between rings are
/// quads; ring tips, fork caps and leaves are triangles.</summary>
public readonly struct Face
{
	public int A { get; }

	public int B { get; }

	public int C { get; }

	public int D { get; }

	public bool IsQuad => D != C;

	public Face(int a, int b, int c)
	{
		A = a;
		B = b;
		C = c;
		D = c;
	}

	public Face(int a, int b, int c, int d)
	{
		A = a;
		B = b;
		C = c;
		D = d;
	}
}

/// <summary>A three-part double vector, y up.</summary>
public readonly struct Vector3
{
	public double X { get; }

	public double Y { get; }

	public double Z { get; }

	public Vector3(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public static Vector3 operator +(Vector3 a, Vector3 b) =>
		new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

	public static Vector3 operator -(Vector3 a, Vector3 b) =>
		new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

	public static Vector3 operator *(Vector3 v, double s) =>
		new(v.X * s, v.Y * s, v.Z * s);

	public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);

	public Vector3 Normalized => this * (1 / Length);

	public static double Dot(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

	public static Vector3 Cross(Vector3 a, Vector3 b) =>
		new(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);

	/// <summary>This vector rotated around an axis by an angle: Rodrigues'
	/// formula.</summary>
	public Vector3 AxisAngle(Vector3 axis, double angle)
	{
		double cos = Math.Cos(angle);
		double sin = Math.Sin(angle);
		return this * cos + Cross(axis, this) * sin + axis * (Dot(axis, this) * (1 - cos));
	}

	/// <summary>This vector with its component along a direction scaled.</summary>
	public Vector3 ScaleInDirection(Vector3 direction, double scale)
	{
		double current = Dot(this, direction);
		return this + direction * (current * scale - current);
	}
}

/// <summary>A two-part double vector; texture coordinates.</summary>
public readonly struct Vector2
{
	public double X { get; }

	public double Y { get; }

	public Vector2(double x, double y)
	{
		X = x;
		Y = y;
	}
}
