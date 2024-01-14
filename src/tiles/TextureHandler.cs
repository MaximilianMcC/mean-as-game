using Raylib_cs;

class TextureHandler
{
	public static Texture2D Grass;

	public static void LoadTextures()
	{
		Grass = LoadTexture("grass");
	}

	private static Texture2D LoadTexture(string name)
	{
		const string texturePath = "./assets/tiles/";
		return Raylib.LoadTexture(texturePath + name + ".png");
	}
}