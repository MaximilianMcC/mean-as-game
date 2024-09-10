using System.Numerics;
using Raylib_cs;

class Game
{
	private static List<GameObject> gameObjects;
	public static bool Paused = false;

	// TODO: Don't put this here
	public static Texture2D MissingTexture { get; private set; }

	public static void Start()
	{
		// Load in the missing texture thingy first
		MissingTexture = AssetManager.LoadTexture("./assets/missing.png");

		Ui.Load();
		Map.Load();

		gameObjects = new List<GameObject>()
		{
			new Player()
		};
	}

	public static void Update()
	{
		// Check for if we wanna toggle being paused
		if (Raylib.IsWindowFocused() == false) Paused = true;
		if (Raylib.IsKeyPressed(KeyboardKey.Escape)) Paused = !Paused;

		// Check for if we're paused
		if (Paused == true) return;

		// Update everything
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.Update();
		}
	}

	public static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.Magenta);

		// Draw everything
		Map.Render();
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.Render();
		}

		// If we're paused then darken the screen
		// and also say that we're paused
		if (Paused)
		{
			Vector2 screen = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
			Raylib.DrawRectangleV(Vector2.Zero, screen, new Color(0, 0, 0, 128));
			Raylib.DrawTextEx(Ui.TimesNewRoman, $"Paused rn", screen / 2, 35f, (35f / 10f), Color.White);
		}

		Raylib.EndDrawing();
	}

	public static void CleanUp()
	{
		// Get rid of all the game objects
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.CleanUp();
		}

		// Unload all of the ui
		Ui.CleanUp();

		// Unload the missing texture
		Raylib.UnloadTexture(MissingTexture);
	}
}