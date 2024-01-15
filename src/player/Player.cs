using System.Numerics;
using Raylib_cs;

class Player
{
	public static Camera2D Camera;

	public static void Start()
	{
		// Create a new camera
		Camera = new Camera2D()
		{
			Target = Vector2.Zero,
			Offset = Vector2.Zero,
			Rotation = 0f,
			Zoom = 1f
		};
	}

	public static void Update()
	{

	}

	public static void Render()
	{

	}

	public static void CleanUp()
	{

	}
}