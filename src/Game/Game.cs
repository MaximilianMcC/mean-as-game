using Raylib_cs;

class Game
{
	public static void Start()
	{

	}

	public static void Update()
	{

	}

	public static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.Magenta);

		Raylib.DrawText("erhm", 10, 10, 32, Color.White);

		Raylib.EndDrawing();
	}

	public static void CleanUp()
	{

	}
}