using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

class Player : GameObject
{
	public static Camera2D Camera;
	public static Vector2 Position = Vector2.Zero;
	private static float speed = 1500f;

	public static float Width = 100f;

	public static Vector2 HighlightedTile;

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
		Camera.Target = Position - new Vector2((Raylib.GetScreenWidth() / 2) - (Width / 2 ), Raylib.GetScreenHeight() / 2);

		Highlight();
	}

	public override void Render()
	{
		// Draw the player
		Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Width, 100, Color.RED);

		// Draw the highlighted tile
		Raylib.DrawRectangle((int)HighlightedTile.X * World.TileSize, (int)HighlightedTile.Y * World.TileSize, World.TileSize * World.TileScale, World.TileSize * World.TileScale, new Color(0, 0, 255, 128));
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

	// Highlight the current tile that the player is on
	private void Highlight()
	{
		// Get the mouses coordinates, then convert them to world coordinates
		Vector2 screenCoordinates = Raylib.GetMousePosition();
		Vector2 worldCoordinates = Raylib.GetScreenToWorld2D(screenCoordinates, Camera);

		// Snap the world coordinates to the grid
		HighlightedTile = new Vector2(
			(int)worldCoordinates.X / World.TileSize,
			(int)worldCoordinates.Y / World.TileSize
		);
	}
}