using Raylib_cs;

abstract class GameObject
{
	protected Dictionary<string, Texture2D> Textures;
	protected Dictionary<string, Animation> Animations;
	protected Dictionary<string, Sound> Sounds;
	protected Dictionary<string, Music> Music;

	public GameObject()
	{
		// Hold all of the assets and map them
		// to a string so its a little easier to use them
		Textures = new Dictionary<string, Texture2D>();
		Animations = new Dictionary<string, Animation>();
		Sounds = new Dictionary<string, Sound>();
		Music = new Dictionary<string, Music>();

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

		// Unload all the sounds
		foreach (KeyValuePair<string, Sound> sound in Sounds)
		{
			Raylib.UnloadSound(sound.Value);
		}

		// Unload all the music
		foreach (KeyValuePair<string, Music> music in Music)
		{
			Raylib.UnloadMusicStream(music.Value);
		}
	}
}