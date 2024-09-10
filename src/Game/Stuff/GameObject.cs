using Raylib_cs;

abstract class GameObject
{
	protected Dictionary<string, Texture2D> Textures;
	protected Dictionary<string, Animation> Animations;

	public GameObject()
	{
		// Hold all of the textures/animations and map them
		// to a string so its a little easier to use them
		Textures = new Dictionary<string, Texture2D>();
		Animations = new Dictionary<string, Animation>();

		// Add the missing texture to be the first
		// texture that the game object holds
		Textures.Values.DefaultIfEmpty(Game.MissingTexture);

		// Automatically run the start method
		Start();
	}

	public virtual void Start() { }
	public virtual void Update() { }
	public virtual void Render() { }

	public virtual void CleanUp()
	{		
		// Unload all the textures
		foreach (KeyValuePair<string, Texture2D> texture in Textures)
		{
			Raylib.UnloadTexture(texture.Value);
		}

		// Unload all the animations
		foreach (KeyValuePair<string, Animation> animation in Animations)
		{
			animation.Value.Unload();
		}
	}
}