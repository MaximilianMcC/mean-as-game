using Raylib_cs;

class Player : GameObject
{
	public override void Start()
	{
		Textures.Add("player", AssetManager.LoadTexture("./assets/test.png"));
	}

	public override void Render()
	{
		Raylib.DrawTexture(Textures["player"], 0, 0, Color.White);
	}
}