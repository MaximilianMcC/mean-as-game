using System.Numerics;
using Raylib_cs;

class World
{
	// World size (grid)
	// public int Width = 512;
	// public int Height = 512;
	public int Width = 16;
	public int Height = 16;

	// Tile stuff (goes in grid)
	public int TileSize = 64;
	public Tile[] Tiles;

	public World(int seed)
	{
		// Generate the world from the seed
		Tiles = new Tile[Width * Height];
		// TODO: Use the seed

		// Load all of the textures for the tiles
		// TODO: Don't do this here
		TextureHandler.LoadTextures();

		// Make the tile map
		//! DEBUG: filled with grass for now, but later use perlin noise to make something actually good
		for (int i = 0; i < Tiles.Length; i++)
		{
			// Get the coordinates of the current tile
			int x = i % Width;
			int y = i / Height;
			Vector2 coordinates = new Vector2(x, y);

			Tiles[i] = new Grass(coordinates, TextureHandler.Grass);
		}
	}

	public void Update()
	{
		// Update all of the tiles
		// TODO: Only update stuff thats on screen
		for (int i = 0; i < Tiles.Length; i++)
		{
			Tiles[i].Update();
		}
	}

	public void Render()
	{
		// Render all of the tiles
		// TODO: Only renders stuff thats on screen
		for (int i = 0; i < Tiles.Length; i++)
		{
			Tiles[i].Render();
		}
	}
}