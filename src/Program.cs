﻿using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Run();
	}

	private static void Run()
	{
		Raylib.SetTraceLogLevel(TraceLogLevel.Warning);
		Raylib.InitWindow(800, 600, "mean as game (really cool (epic))");

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