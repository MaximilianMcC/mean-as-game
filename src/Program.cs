using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		AssetManager.PrintEmbeddedAssets();

		Run();
	}

	private static void Run()
	{
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.InitWindow(800, 600, "mean as game (really cool (epic))");

		//! remove this once player is frame independent
		// TODO: Add a max fps slider in options or something
		Raylib.SetTargetFPS(60);

		Game.Start();
		while (!Raylib.WindowShouldClose())
		{
			Game.Update();
			Game.Render();
		}
		Game.CleanUp();
		Raylib.CloseWindow();
	}
}