using Raylib_cs;

class AssetManager
{
	public static List<Texture2D> TerrainTextures;

	// Load in all of the textures that the game needs
	public static void LoadTextures()
	{
		// Load in all of the terrain textures
		// TODO: Make it so that tiles and stuff can be made in JSON so no hardcoding or something
		TerrainTextures = new List<Texture2D>()
		{
			Raylib.LoadTexture("./assets/tiles/terrain/grass.png"),
			Raylib.LoadTexture("./assets/tiles/terrain/dirt.png"),
		};
	}

	// Unload all of the textures
	public static void UnloadTextures()
	{
		// Terrain textures
		foreach (Texture2D texture in TerrainTextures)
		{
			Raylib.UnloadTexture(texture);
		}
	}
}