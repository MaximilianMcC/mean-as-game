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
		Gravity = 9.81f;

		//! Hardcoding for now
		//TODO: Design file format thing
		//TODO: Make it so rectangles can be "flipped" where you use the inside for collision rather than the outside
		DynamicObjects = new List<Entity>();
		StaticObjects = new List<Rectangle>()
		{
			// some sort of a wall idk
			new Rectangle(400, 50, 40, 300)
		};
	}

	public static void Render()
	{
		// Loop over every thing in the map and draw it
		foreach (Rectangle thing in StaticObjects)
		{
			// TODO: Allocate some budget to this
			Raylib.DrawRectangleRec(thing, Color.Red);
		}

		Raylib.DrawTextEx(Ui.TimesNewRoman, Name, new Vector2(10), 35f, (35f / 10f), Color.White);
	}

	// Check for if something is colliding with the map on the X axis
	public static bool IsCollidingX(Rectangle thingToCheck)
	{
		// Loop through everything in the map
		foreach (Rectangle thing in StaticObjects)
		{
			// Check for if there is X collision
			// TODO: Make this look nicer
			if (
				thingToCheck.X < thing.X + thing.Width &&
				thingToCheck.X + thingToCheck.Width > thing.X
			) return true;
		}

		// There was no collision
		return false;
	}

	// Check for if something is colliding with the map on the Y axis
	public static bool IsCollidingY(Rectangle thingToCheck)
	{
		// Loop through everything in the map
		foreach (Rectangle thing in StaticObjects)
		{
			// Check for if there is Y collision
			// TODO: Make this look nicer
			if (
				thingToCheck.Y < thing.Y + thing.Height &&
				thingToCheck.Y + thingToCheck.Height > thing.Y
			) return true;
		}

		// There was no collision
		return false;
	}
}