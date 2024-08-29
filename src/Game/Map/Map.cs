using System.Numerics;
using Raylib_cs;

class Map
{
	// Store both the moving stuff (entities) and
	// not moving stuff (actual map and whatnot)
	public static List<Rectangle> StaticObjects;
	public static List<Entity> DynamicObjects;

	public static string Name;
	public static float Gravity;

	public static void Load(string filePath)
	{
		Name = filePath;
		Gravity = 0.5f;

		//! Hardcoding for now
		//TODO: Design file format thing
		//TODO: Make it so rectangles can be "flipped" where you use the inside for collision rather than the outside
		DynamicObjects = new List<Entity>();
		StaticObjects = new List<Rectangle>()
		{
			// some sort of a wall idk
			new Rectangle(600, 50, 15, 300),
			new Rectangle(10, 50, 15, 300),

			// Floor thingy
			new Rectangle(50, 300, 400, 15)
		};
	}

	public static void Render()
	{
		// Loop over everything in the map and draw it
		foreach (Rectangle thing in StaticObjects)
		{
			// TODO: Allocate some budget to this
			Raylib.DrawRectangleRec(thing, Color.White);
		}

		Raylib.DrawTextEx(Ui.TimesNewRoman, Name, new Vector2(10), 35f, (35f / 10f), Color.White);
	}

	public static float ResolveXCollisions(Rectangle current, Rectangle potential)
	{
		// Loop through everything in the map
		// TODO: Also do for dynamic things
		foreach (Rectangle mapObject in StaticObjects)
		{
			// Check for if there was any collision
			// (not in the mood to waste time fr)
			if (!Raylib.CheckCollisionRecs(potential, mapObject)) continue;

			// If there was collision then figure out how
			// much we need to adjust the hitbox so that its
			// just outside the collision area (not colliding)

			// Check for what direction we're moving
			// and resolve the collision for that direction
			if (potential.X < current.X)
			{
				// Moving left so we gotta shift the
				// thing over towards the right
				return (mapObject.X + mapObject.Width) - potential.X;
			}
			else if (potential.X > current.X)
			{
				// Moving right so we gotta shift the
				// thing over towards the left
				return mapObject.X - (potential.X + potential.Width);
			}
		}

		// There was no collision
		return 0f;
	}


	public static float ResolveYCollisions(Rectangle current, Rectangle potential)
	{
		return 0f;
	}
}