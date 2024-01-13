using Raylib_cs;

class Game
{
	public static void Run()
	{
		// Raylib stuff
		Raylib.InitWindow(400, 300, "factorio cloen");


		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}

		Raylib.CloseWindow();
	}

	private static void Update()
	{
		
	}

	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		Raylib.DrawText("factor", 10, 10, 30, Color.WHITE);

		Raylib.EndDrawing();
	}
}