using System.Numerics;
using Raylib_cs;

class Player : Entity
{
	//? moveForce is acceleration btw
	private float moveForce = 200f;
	private float frictionCoefficient = 0.8f;

	public override void Start()
	{
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
		Velocity.X *= frictionCoefficient;

		// Actually move
		Hitbox.Position += Velocity;
	}

	public override void Render()
	{
		Raylib.DrawTextureV(Textures["player"], Hitbox.Position, Color.White);
		Raylib.DrawText($"{Hitbox.Position}\t{Velocity}", 100, 100, 45, Color.White);
	}
}