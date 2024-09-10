using Raylib_cs;

class Radio : Entity
{
	public override void Start()
	{
		// Set the hitbox size and load the texture
		Hitbox = new Rectangle(320, 10, 80f, 80f);
		Textures.Add("radio", AssetManager.LoadTexture("./assets/radio.png"));

		// Load in the music then play it
		Music.Add("radio", AssetManager.LoadMusic("./assets/radio.wav"));
		Raylib.PlayMusicStream(Music["radio"]);
	}

	public override void Update()
	{
		Raylib.UpdateMusicStream(Music["radio"]);
		base.Update();
	}
}