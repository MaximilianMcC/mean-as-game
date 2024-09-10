using System.Numerics;
using Raylib_cs;

class Entity : GameObject
{
	public Rectangle Hitbox;
	public float yVelocity;
	public bool OnGround;

	// TODO: Actually resolve collisions
	protected bool CheckCollisionAndMove(Vector2 newPosition)
	{
		// Get the new hitbox based on the new position
		Rectangle newHitbox = Hitbox;
		newHitbox.Position += newPosition;

		// If there was no collision then use the new hitbox
		if (Map.CollisionWithMap(newHitbox, this) == false)
		{
			// There was no collision (Move)
			Hitbox = newHitbox;
			return false;
		}

		// There was collision (Don't move)
		return true;
	}

	// Apply gravity to the current entity
	protected void ApplyGravity()
	{
		// Apply gravity
		yVelocity += Map.Gravity * Raylib.GetFrameTime();

		// Resolve the collision
		Vector2 movement = Vector2.UnitY * yVelocity * Raylib.GetFrameTime();
		bool collision = CheckCollisionAndMove(movement);

		// Handle being on the ground and the
		// velocity and whatnot
		if (collision)
		{
			// Reset velocity and say that we're on the ground
			yVelocity = 0;
			OnGround = true;

		} else OnGround = false;
	}

	public override void Update()
	{
		// Jank as physics object thing idk
		// TODO: Make it so bro can push stuff around
		ApplyGravity();
	}

	public override void Render()
	{
		// Just draw the very first texture
		// thats loaded in the game object
		Utils.DrawTextureOnRectangle(Textures.FirstOrDefault().Value, Hitbox);
	}
}