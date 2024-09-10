using System.Numerics;
using Raylib_cs;

class Game
{
	public static bool Paused = false;

	// TODO: Don't put this here
	public static Texture2D MissingTexture { get; private set; }

	public static void Start()
	{
		// Load in the missing texture thingy first
		MissingTexture = AssetManager.LoadTexture("./assets/missing.png");

		Ui.Load();
		Map.Load();

		Map.Entities.Add(new Player());
		Map.Entities.Add(new Telly());

		//! debug
		string captionText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
		DialogueHandler.DisplayCaption(captionText, 10f, 30f);
	}

	public static void Update()
	{
		// Check for if we wanna toggle being paused
		if (Raylib.IsWindowFocused() == false) Paused = true;
		if (Raylib.IsKeyPressed(KeyboardKey.Escape)) Paused = !Paused;

		// Check for if we're paused
		if (Paused == true) return;

		// Update everything
		Map.Update();
	}

	public static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.Magenta);

		// Draw everything
		Map.Render();
		DialogueHandler.RenderCaptions();

		// TODO: Put this in debug class thingy
		Raylib.DrawFPS(10, 10);

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
		Ui.CleanUp();
		Map.CleanUp();

		// Unload the missing texture
		Raylib.UnloadTexture(MissingTexture);
	}
}