using System.Numerics;
using Raylib_cs;

class Player : Entity
{
	private float moveForce = 400f;
	private float jumpForce = 100f;

	public override void Start()
	{
		// Set the hitbox size and load the player texture
		Hitbox = new Rectangle(50, 10, 100f, 80f);
		Textures.Add("player", AssetManager.LoadTexture("./assets/test.png"));
	}

	public override void Update()
	{
		// Get delta time right at the start for if
		// it changes while the method getting ran
		float deltaTime = Raylib.GetFrameTime();

		// Check for if we wanna move and get the
		// direction to move in
		float xDirection = 0;
		if (Raylib.IsKeyDown(KeyboardKey.Left)) xDirection = -1;
		if (Raylib.IsKeyDown(KeyboardKey.Right)) xDirection = 1;

		// Set the force based on the movement
		// TODO: Increase velocity, not assign
		float force = (moveForce * xDirection) * deltaTime;
		Velocity.X = force;

		// Apply gravity
		// Velocity.Y += Map.Gravity * deltaTime;

		// Get what the new position will be based
		// off the movement bros just done
		Rectangle newHitbox = Hitbox;
		newHitbox.Position += Velocity;

		// Check for X collisions
		newHitbox.X += Map.ResolveXCollisions(Hitbox, newHitbox);
		Hitbox.X = newHitbox.X;

		// Check for X and Y collision
		// Hitbox.X += Map.ResolveXCollisions(Hitbox, newHitbox);
		// Hitbox.Y += Map.ResolveYCollisions(Hitbox, newHitbox);
	}

	public override void Render()
	{
		Utils.DrawTextureOnRectangle(Textures["player"], Hitbox);
		Raylib.DrawTextEx(Ui.TimesNewRoman, $"position: {Hitbox.Position}\n\nvelocity: {Velocity}\n\nground: {OnGround}", new Vector2(10, 400), 35f, (35f / 10f), Color.White);
	}
}