using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

class Player : GameObject
{
	public static Camera2D Camera;
	public static Vector2 Position = Vector2.Zero;
	private static float speed = 1500f;

	public override void Start()
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

	public override void Update()
	{
		// Update movement and make the camera track/follow the player
		// TODO: Make it so the camera stops when the player reaches the end of the world, so they can never see out
		Movement();
		Camera.Target = Position;
	}

	public override void Render()
	{
		Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 100, 100, Color.RED);
	}

	public override void CleanUp()
	{

	}

	private void Movement()
	{
		// Get the movement direction vector thing
		Vector2 movement = Vector2.Zero;
		if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y--;
		if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X--;
		if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y++;
		if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X++;

		// Normalize it to ensure speed is the same everywhere
		if (movement != Vector2.Zero) movement = Vector2.Normalize(movement);

		// Add speed and whatnot
		Vector2 newMovement = (movement * speed) * Raylib.GetFrameTime();
		Vector2 newPosition = Position + newMovement;

		// TODO: Collision detection

		// Apply the movement
		Position = newPosition;
	}
}