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

		Map.Entities.Add(new Telly());
		Map.Entities.Add(new Player());

		//! debug
		string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
		DialogueHandler.DisplayCaption(text, 60d);
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
		DialogueHandler.UpdateCaptions();
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