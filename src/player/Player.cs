using System.Numerics;
using Raylib_cs;

class Player
{
	public Camera2D Camera;
	public Vector2 Size;
	public Vector2 Position;

	private float moveSpeed = 1000f;

	public void Start()
	{
		Size = new Vector2(32, 64);
		Position = Vector2.Zero;

		// Make the camera
		Camera = new Camera2D()
		{
			Target = Size / 2,
			Offset = new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()) / 2,
			Rotation = 0f,
			Zoom = 1f
		};
	}

	public void Update()
	{
		Movement();
	}

	public void Render()
	{
		Raylib.DrawRectangleRec(new Rectangle(Position.X, Position.Y, Size.X, Size.Y), Color.RED);
		Raylib.DrawText(Position.ToString(), 10, 10, 20, Color.WHITE);
	}



	private void Movement()
	{
		Vector2 newPosition = Vector2.Zero;

		// Move the player
		// TODO: Make it physics based, or lerp it
		if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) newPosition.Y -= 1;
		if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) newPosition.Y += 1;
		if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) newPosition.X -= 1;
		if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) newPosition.X += 1;

		// Add speed and normalize if needed
		if (newPosition != Vector2.Zero) newPosition = Vector2.Normalize(newPosition);
		newPosition = (newPosition * moveSpeed) * Raylib.GetFrameTime();

		// TODO: Collision detection

		// Update the final position
		Position += newPosition;
	}
}