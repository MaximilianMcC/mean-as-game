using System.Numerics;

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

	public static int TileSize = 64;
	public static int TileScale = 3;

	public World()
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
}