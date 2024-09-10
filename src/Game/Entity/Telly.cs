using Raylib_cs;

class Telly : Entity
{
    public override void Start()
    {
		HasEntityCollision = false;
		Hitbox = new Rectangle(365, 300, 80, 80);

		// Load the actual tv
		Textures.Add("tv", AssetManager.LoadTexture("./assets/tv/tv.png"));

		// Load the screen animation and music
		Animations.Add("screen", new Animation("./assets/tv/screen.png", 198, 24));
		Music.Add("screen", AssetManager.LoadMusic("./assets/tv/screen.wav"));

		// Start the music
		//? Have to assign to variable because dictionary returns a copy of value
		Raylib.PlayMusicStream(Music["screen"]);
		Music music = Music["screen"];
		music.Looping = true;
    }

	public override void Update()
	{
		Animations["screen"].Animate();
		Raylib.UpdateMusicStream(Music["screen"]);
		base.Update();
	}

    public override void Render()
    {
		// Draw the screen behind the tv
		Rectangle screen = new Rectangle(Hitbox.Position, 75, 60);
		Utils.DrawTextureOnRectangle(Animations["screen"].GetFrame(), screen);

        // Draw the tv over the top
		Utils.DrawTextureOnRectangle(Textures["tv"], Hitbox);
    }
}