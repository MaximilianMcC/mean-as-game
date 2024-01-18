using Raylib_cs;

class Game
{
	public static List<GameObject> GameObjects;
	public static Player Player;
	public static World World;

	public static void Run()
	{
		// Create the raylib stuff
		Raylib.InitWindow(820, 480, "Factorio clon");
		Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
		Raylib.InitAudioDevice();
		Raylib.SetExitKey(KeyboardKey.KEY_NULL);
		Raylib.SetTargetFPS(60);

		// Load all of the assets
		// TODO: Loading screen
		AssetManager.LoadTextures();

		// Make the list of game objects to store everything
		GameObjects = new List<GameObject>();

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
		// Create/load the world
		World = new World();

		// Instantiate all of the needed game objects
		Player = new Player();

		// Start all of the game objects
		foreach (GameObject gameObject in GameObjects)
		{
			gameObject.Start();
		}
	}

	private static void Update()
	{
		World.Update();
		foreach (GameObject gameObject in GameObjects)
		{
			gameObject.Update();
		}
	}

	private static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.MAGENTA);

		// Draw world stuff
		Raylib.BeginMode2D(Player.Camera);
		World.Render();
		foreach (GameObject gameObject in GameObjects)
		{
			gameObject.Render();
		}

		// Draw UI stuff
		Raylib.EndMode2D();

		Raylib.EndDrawing();
	}

	private static void CleanUp()
	{
		// Clean up Raylib stuff
		Raylib.CloseAudioDevice();
		Raylib.CloseWindow();

		// Game objects
		foreach (GameObject gameObject in GameObjects)
		{
			gameObject.CleanUp();
		}

		// Textures
		AssetManager.UnloadTextures();
	}

}