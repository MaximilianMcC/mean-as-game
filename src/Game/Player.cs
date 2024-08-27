using System.Numerics;
using Raylib_cs;

class Player : Entity
{
	//? moveForce is acceleration btw
	private float moveForce = 200f;
	private float frictionCoefficient = 0.9f;

	public override void Start()
	{
		// Set the hitbox size
		Hitbox = new Rectangle(0, 0, 50, 50);

		Textures.Add("player", AssetManager.LoadTexture("./assets/test.png"));
	}

	public override void Update()
	{
		// Check for if we wanna move and get the
		// direction to move in
		float xDirection = 0;
		if (Raylib.IsKeyDown(KeyboardKey.Left)) xDirection = -1;
		if (Raylib.IsKeyDown(KeyboardKey.Right)) xDirection = 1;

		// Convert the direction to a force
		// that we can use to actually move
		float force = (moveForce * xDirection) * Raylib.GetFrameTime();
		Velocity.X += force;

		// Apply friction to allow the player
		// to eventually stop
		// TODO: Make this frame independent
		//! make frame independent rn please (top priority)
		Velocity.X *= frictionCoefficient;
		if (MathF.Abs(Velocity.X) < 0.1f) Velocity.X = 0f;

		// Actually move
		Hitbox.Position += Velocity;
	}

	public override void Render()
	{
		Utils.DrawTextureOnRectangle(Textures["player"], Hitbox);
		Raylib.DrawText($"{Hitbox.Position}\t{Velocity}", 100, 100, 45, Color.White);
	}
}