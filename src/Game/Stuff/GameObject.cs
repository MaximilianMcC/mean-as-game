using Raylib_cs;

abstract class GameObject
{
	protected Dictionary<string, Texture2D> Textures;

	public GameObject()
	{
		// Hold all of the textures and map them
		// to a string so its a little easier to use them
		Textures = new Dictionary<string, Texture2D>();

		// Automatically run the start method
		Start();
	}

	public virtual void Start() { }
	public virtual void Update() { }
	public virtual void Render() { }

	public virtual void CleanUp()
	{
		// Unload all of the textures
		foreach (KeyValuePair<string, Texture2D> texture in Textures)
		{
			Raylib.UnloadTexture(texture.Value);
		}
	}
}