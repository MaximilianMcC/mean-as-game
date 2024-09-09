using System.Numerics;
using Raylib_cs;

class Player : Entity
{
	private float speed = 400f;
	private float jumpForce = 800f;

	public override void Start()
	{
		// Set the hitbox size and load the player texture
		Hitbox = new Rectangle(50, 10, 100f, 80f);
		Textures.Add("player", AssetManager.LoadTexture("./assets/test.png"));
	}

	public override void Update()
	{
		Movement();
	}

	private void Movement()
	{
		// Get the direction that the player
		// wants to move in
		// TODO: Move all the gravity stuff up to the top then only run x movement if we move yk
		float direction = 0;
		if (Raylib.IsKeyDown(KeyboardKey.Left)) direction = -1;
		if (Raylib.IsKeyDown(KeyboardKey.Right)) direction = 1;

		// Apply speed to the direction to get the movement
		// then check for collisions and move bro
		float xMovement = (direction * speed) * Raylib.GetFrameTime();
		CheckCollisionAndMove(Vector2.UnitX * xMovement);

		// If we're on the ground then jump
		if (Raylib.IsKeyPressed(KeyboardKey.Space) && OnGround)
		{
			// Jump and say that we're not on the
			// ground anymore (jumping (in the air))
			yVelocity = -jumpForce;
			OnGround = false;
		}

		// Gravity
		ApplyGravity();
	}

	public override void Render()
	{
		Utils.DrawTextureOnRectangle(Textures["player"], Hitbox);
		Raylib.DrawTextEx(Ui.TimesNewRoman, $"position: {Hitbox.Position}\n\nY velocity: {yVelocity}\n\nground: {OnGround}", new Vector2(10, 400), 35f, (35f / 10f), Color.White);
	}
}