using System.Numerics;
using Raylib_cs;

class Player : Entity
{
	private float speed = 350f;
	private float jumpForce = 600f;

	//? Using sbyte (signed byte) because this is only -1, 0, or 1 (waste of bytes fr)
	private sbyte direction;
	private bool directionJustGotChanged;
	private bool justLandedOnGround;

	private string currentAnimation;
	private string currentTexture;
	private string[] idlePoses;
	private string[] airPoses;

	public override void Start()
	{
		// Set the hitbox size
		Hitbox = new Rectangle(50, 10, 60f, 100f);

		// Standing still stuff
		idlePoses = new string[] { "idle-1", "idle-2", "idle-3", "idle-4", "idle-5" };
		foreach (string pose in idlePoses) Textures.Add(pose, AssetManager.LoadTexture($"./assets/player/{pose}.png"));

		airPoses = new string[] { "air-1", "air-2", "air-3" };
		foreach (string pose in airPoses) Textures.Add(pose, AssetManager.LoadTexture($"./assets/player/{pose}.png"));

		// Walking animation
		Animations.Add("walk", new Animation("./assets/player/walk.png", 128, 8f));

		// Set the initial values
		//? Setting to air pose because bro spawns midair
		currentTexture = airPoses[0];
		currentAnimation = "walk";
	}

	public override void Update()
	{
		Movement();

		// If the direction has changed them
		// set a random idle texture
		// TODO: Do this with a state machine or something idk
		if ((directionJustGotChanged && OnGround) || justLandedOnGround) currentTexture = Utils.RandomElement(idlePoses);

	}

	private void Movement()
	{
		// Get the direction that the player
		// wants to move in
		// TODO: Move all the gravity stuff up to the top then only run x movement if we move yk
		sbyte previousDirection = direction;
		direction = 0;
		if (Raylib.IsKeyDown(KeyboardKey.Left)) direction = -1;
		if (Raylib.IsKeyDown(KeyboardKey.Right)) direction = 1;

		// Check for if the previous direction changed
		// TODO: Don't set every frame
		directionJustGotChanged = direction != previousDirection;

		// Apply speed to the direction to get the movement
		// then check for collisions and move bro
		float xMovement = (direction * speed) * Raylib.GetFrameTime();
		CheckCollisionAndMove(Vector2.UnitX * xMovement);

		// If we're on the ground then jump
		// (don't want bro to jump mid air)
		if ((Raylib.IsKeyPressed(KeyboardKey.Space) || Raylib.IsKeyPressed(KeyboardKey.Up)) && OnGround)
		{
			// Jump and say that we're not on the
			// ground anymore (jumping (in the air))
			yVelocity = -jumpForce;
			OnGround = false;

			// Set the texture to show that we're jumping
			// TODO: Don't do in here
			currentTexture = Utils.RandomElement(airPoses);
		}

		// Gravity
		bool previouslyOnGround = OnGround;
		ApplyGravity();
		justLandedOnGround = previouslyOnGround != OnGround;
	}

	public override void Render()
	{
		// Depending on our direction, draw the player
		if (direction == 0 || OnGround == false)
		{
			// Draw bro with the random idle image
			Utils.DrawTextureOnRectangle(Textures[currentTexture], Hitbox);
		}
		else
		{
			// Draw bro with the walking animation
			// TODO: Don't animate in Render(); Do in Update();
			Animations[currentAnimation].Animate();
			Utils.DrawTextureOnRectangle(Animations[currentAnimation].GetFrame(), Hitbox, direction, 1);
		}



		// Debug info
		Raylib.DrawTextEx(Ui.TimesNewRoman, $"position: {Hitbox.Position}\n\nY velocity: {yVelocity}\n\nground: {OnGround}", new Vector2(10, 500), 35f, (35f / 10f), Color.White);
	}
}