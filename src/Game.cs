using Raylib_cs;

class Game
{
	public static Player Player;

	public static void Run()
	{
		// Raylib stuff
		Raylib.InitWindow(800, 600, "factorio cloen");

		Start();
		while (!Raylib.WindowShouldClose())
		{
			Update();
			Render();
		}

		Raylib.CloseWindow();
	}

	private static void Start()
	{
		Player = new Player();
		Player.Start();
	}

	private static void Update()
	{
		Player.Update();
	}

	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		Player.Render();

		Raylib.EndDrawing();
	}
}