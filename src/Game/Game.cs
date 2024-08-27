using System.Numerics;
using Raylib_cs;

class Game
{
	public static void Start()
	{
		Ui.Load();
	}

	public static void Update()
	{

	}

	public static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.Magenta);

		// Raylib.DrawText("erhm", 10, 10, 32, Color.White);
		Raylib.DrawTextEx(Ui.TimesNewRoman, "erhm", new Vector2(10), 35f, (35f / 10f), Color.White);

		Raylib.EndDrawing();
	}

	public static void CleanUp()
	{
		Ui.CleanUp();
	}
}