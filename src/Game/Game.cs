using System.Numerics;
using Raylib_cs;

class Game
{
	private static Player player;
	private static List<GameObject> gameObjects;

	public static void Start()
	{
		Ui.Load();
		gameObjects = new List<GameObject>();

		player = new Player();
		gameObjects.Add(player);

	}

	public static void Update()
	{
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.Update();
		}
	}

	public static void Render()
	{
		Raylib.BeginDrawing();
		Raylib.ClearBackground(Color.Magenta);

		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.Render();
		}
		Raylib.DrawTextEx(Ui.TimesNewRoman, "erhm", new Vector2(10), 35f, (35f / 10f), Color.White);

		Raylib.EndDrawing();
	}

	public static void CleanUp()
	{
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.CleanUp();
		}

		Ui.CleanUp();
	}
}