using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

class Player : Entity
{
	//? moveForce is acceleration btw
	// TODO: Make coefficient between 0-1
	private float mass = 60f;
	private float moveForce = 80f;
	private float frictionCoefficient = 0.001f; 

	public override void Start()
	{
		// Set the hitbox size
		Hitbox = new Rectangle(10, 10, 100f, 80f);

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

		// Get a movement force based on the direction
		float force = ((mass * moveForce) * xDirection) * deltaTime;
		Velocity.X += force;

		// Apply friction
		// TODO: Use friction = coefficient * normalForce (real formula irl)
		// TODO: Apply air resistance (y)
		//! This isn't EXACTLY frame independent, but its good enough
		Velocity.X *= MathF.Pow(frictionCoefficient, deltaTime);
		if (MathF.Abs(Velocity.X) < 0.1f) Velocity.X = 0f;

		// Get the new hitbox
		Rectangle newHitbox = Hitbox;
		newHitbox.Position += Velocity * deltaTime;

		// Check for if the new position is valid or not
		if (Map.IsCollidingX(newHitbox))
		{
			Velocity.X = 0f;
			return;
		}

		// Move bro
		Hitbox = newHitbox;
	}

	public override void Render()
	{
		Utils.DrawTextureOnRectangle(Textures["player"], Hitbox);
		Raylib.DrawTextEx(Ui.TimesNewRoman, $"velocity: {Velocity}", new Vector2(10, 500), 35f, (35f / 10f), Color.White);
	}
}