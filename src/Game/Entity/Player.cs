using System.Numerics;
using Raylib_cs;

class Player : Entity
{
	private float speed = 400f;
	private float jumpForce = 600f;
	private float direction;

	public override void Start()
	{
		// Set the hitbox size
		Hitbox = new Rectangle(50, 10, 100f, 80f);

		// Load the animations
		Animations.Add("walk", new Animation("./assets/player-walk.png", 128, 10));
	}

	public override void Update()
	{
		Movement();
		Animations["walk"].Animate();
	}

	private void Movement()
	{
		// Get the direction that the player
		// wants to move in
		// TODO: Move all the gravity stuff up to the top then only run x movement if we move yk
		direction = 0;
		if (Raylib.IsKeyDown(KeyboardKey.Left)) direction = -1;
		if (Raylib.IsKeyDown(KeyboardKey.Right)) direction = 1;

		// Apply speed to the direction to get the movement
		// then check for collisions and move bro
		float xMovement = (direction * speed) * Raylib.GetFrameTime();
		CheckCollisionAndMove(Vector2.UnitX * xMovement);

		// If we're on the ground then jump
		// (don't want bro to jump mid air)
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
		if (direction == 0) direction = 1;
		Utils.DrawTextureOnRectangle(Animations["walk"].GetFrame(), Hitbox, (int)direction, 1);


		Raylib.DrawTextEx(Ui.TimesNewRoman, $"position: {Hitbox.Position}\n\nY velocity: {yVelocity}\n\nground: {OnGround}", new Vector2(10, 400), 35f, (35f / 10f), Color.White);
	}
}