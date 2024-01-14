using Raylib_cs;

class Game
{
	public static Player Player;
	public static World World;

	public static int MaxFps = 60;

	public static void Run()
	{
		// Raylib stuff
		Raylib.InitWindow(800, 600, "factorio cloen");
		Raylib.SetTargetFPS(MaxFps);
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);

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

		// Make a new seed for generating the world
		// int seed = Raylib.GetRandomValue(0, 99999999);
		int seed = 12345678;

		// Make the world
		World = new World(seed);
	}

	private static void Update()
	{
		Player.Update();
		World.Update();
		Debug.FPSGraph.Update();
	}

	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		World.Render();
		Player.Render();
		Debug.FPSGraph.Render();

		Raylib.EndDrawing();
	}
}