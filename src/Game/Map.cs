using Raylib_cs;

class Map
{
	public static float Gravity = 1500f;
	private static List<Rectangle> platforms;

	public static void Load()
	{
		platforms = new List<Rectangle>()
		{
			// ground
			new Rectangle(0, 500, 600, 100),

			// platform thing
			new Rectangle(300, 350, 200, 20),
		};
	}

	public static bool CollisionWithMap(Rectangle hitbox)
	{
		// Loop over every platform in the map
		// and check for if there was collision
		foreach (Rectangle platform in platforms)
		{
			// If there was collision then return true
			if (Raylib.CheckCollisionRecs(hitbox, platform)) return true;
		}

		// There was no map collision
		return false;
	}

	public static void Render()
	{
		foreach (Rectangle rectangle in platforms)
		{
			Raylib.DrawRectangleRec(rectangle, Color.Beige);
		}
	}
}