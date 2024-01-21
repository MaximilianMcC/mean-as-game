using Raylib_cs;

class AssetManager
{
	public static List<Texture2D> TerrainTextures;
	public static List<Texture2D> ResourceTextures;
	public static Texture2D SelectionTexture;

	// Load in all of the textures that the game needs
	// TODO: Make it so that tiles and stuff can be made in JSON so no hardcoding or something
	public static void LoadTextures()
	{
		// Load in all of the terrain textures
		TerrainTextures = new List<Texture2D>()
		{
			Raylib.LoadTexture("./assets/tiles/terrain/grass.png"),
			Raylib.LoadTexture("./assets/tiles/terrain/grass2.png"),
			Raylib.LoadTexture("./assets/tiles/terrain/dirt.png")
		};

		// Load in all of the resource textures
		ResourceTextures = new List<Texture2D>()
		{
			Raylib.LoadTexture("./assets/tiles/resources/iron-ore1.png"),
			Raylib.LoadTexture("./assets/tiles/resources/iron-ore2.png"),
			Raylib.LoadTexture("./assets/tiles/resources/iron-ore3.png")
		};

		// Load in the selection texture
		SelectionTexture = Raylib.LoadTexture("./assets/ui/select.png");
	}

	// Unload all of the textures
	public static void UnloadTextures()
	{
		// Terrain textures
		foreach (Texture2D texture in TerrainTextures)
		{
			Raylib.UnloadTexture(texture);
		}

		// Selection texture
		Raylib.UnloadTexture(SelectionTexture);
	}
}