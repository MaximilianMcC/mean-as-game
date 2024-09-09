using System.Numerics;
using Raylib_cs;

class Game
{
	private static Player player;
	private static List<GameObject> gameObjects;

	public static void Start()
	{
		Ui.Load();
		Map.Load();
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

		Map.Render();
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.Render();
		}

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