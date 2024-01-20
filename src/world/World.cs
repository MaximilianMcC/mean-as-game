using System.Numerics;
using Raylib_cs;

class World
{
	// All of the different tiles
	public static TerrainTile[] Terrain { get; set; }
	public static ResourceTile[] Resources { get; set; }
	public static MachineTile[] Machines { get; set; }
	public static BuildTile[] Builds { get; set; }

	// World properties and stuff
	//? Grid size btw, not physical size
	public static int Width;
	public static int Height;

	// Size stuff
	public static int TileSize = 32;
	public static int TileScale = 2;
	public static readonly int TileMultiplier = TileSize * TileScale;

	public World(int seed)
	{
		// Set world properties
		Width = 16;
		Height = 16;
		int gridArea = Width * Height;

		// Make all of the grids for the map
		Terrain = new TerrainTile[gridArea];
		Resources = new ResourceTile[gridArea];
		Machines = new MachineTile[gridArea];
		Builds = new BuildTile[gridArea];


		// Create the perlin noise for the terrain using the seed
		GenerateTerrain(seed);


		// Populate the terrain one with grass for now
		// TODO: Use perlin noise based off a seed to make the world
		for (int i = 0; i < gridArea; i++)
		{
			// Get the current coordinates
			int x = i % Width;
			int y = i / Width;

			// Grass
			Terrain[i] = new Grass(new Vector2(x, y));
		}
	}

	public static void Update()
	{
		foreach (TerrainTile tile in Terrain) tile.Update();
		// foreach (ResourceTile tile in Resources) tile.Update();
		// foreach (MachineTile tile in Machines) tile.Update();
		// foreach (BuildTile tile in Builds) tile.Update();
	}

	public static void Render()
	{
		foreach (TerrainTile tile in Terrain) tile.Render();
		// foreach (ResourceTile tile in Resources) tile.Render();
		// foreach (MachineTile tile in Machines) tile.Render();
		// foreach (BuildTile tile in Builds) tile.Render();
	}




	//! unsafe
	// TODO: Don't do unsafe
	private static unsafe void GenerateTerrain(int seed)
	{
		//! idk if this is the correct way to use the seed, but it works
		Image perlinNoise = Raylib.GenImagePerlinNoise(Width * TileMultiplier, Height * TileMultiplier, seed, seed, 1f);
		Color* pixels = Raylib.LoadImageColors(perlinNoise);

		for (int i = 0; i < Width * Height; i++)
		{
			// Get the coordinates of the current pixel
			int x = i % Width;
			int y = i / Width;
			
			// Get the pixels brightness (0 - 255)
			// TODO: Maybe change brightness to a float from 0 - 1, but this should be good for now
			//! I don't think that this is 100% accurate, but it doesn't need to be 100% accurate
			float brightness = (pixels[i].R + pixels[i].G + pixels[i].B) / 3;
		}
	}
}