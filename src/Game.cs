using Raylib_cs;

class Game
{
	public static void Run()
	{
		// Create the raylib stuff
		Raylib.InitWindow(854, 480, "Factorio clon");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.InitAudioDevice();
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);
		Raylib.SetTargetFPS(60);

		// Main game loop
		Start();
		while (!Raylib.WindowShouldClose())
		{
			// TODO: Also have a Tick() method that will run slower than update. Use this for stuff like machines and whatnot to lower stress on pc
			Update();
			Render();
		}
		CleanUp();
	}


	private static void Start()
	{
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

		// Draw world stuff
		Raylib.BeginMode2D(Player.Camera);
		Player.Render();

		// Draw UI stuff
		Raylib.EndMode2D();
		

		Raylib.EndDrawing();
	}

	private static void CleanUp()
	{
		// Clean up Raylib stuff
		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();

		Player.CleanUp();
	}

}