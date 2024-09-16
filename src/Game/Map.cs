using Raylib_cs;

class Map
{
	public static float Gravity = 1500f;
	public static List<Entity> Entities;
	private static List<Rectangle> platforms;
	private static Texture2D background;

	public static void Load()
	{
		// Hardcode map
		platforms = new List<Rectangle>()
		{
			// ground
			new Rectangle(0, 500, 600, 100),

			// platform thing
			new Rectangle(300, 400, 200, 20),
		};

		// More hardcode stuff
		Entities = new List<Entity>();

		// Hardcode background
		background = AssetManager.LoadTexture("./assets/map/background.png");
	}

	public static bool CollisionWithMap(Rectangle hitbox, Entity entityCheckingCollision = null)
	{
		// Loop over every platform in the map
		// and check for if there was collision
		foreach (Rectangle platform in platforms)
		{
			// If there was collision then return true
			if (Raylib.CheckCollisionRecs(hitbox, platform)) return true;
		}

		// Loop over every entity in the map and
		// check for if there was collision
		foreach (Entity entity in Entities)
		{
			// Check for if the thingy even has collision
			if (entity.HasEntityCollision == false) continue;

			// Don't let bro collide with themself
			if (entity == entityCheckingCollision) continue;
			


			// If there was collision then return
			if (Raylib.CheckCollisionRecs(hitbox, entity.Hitbox)) return true;
		}

		// There was no map collision
		return false;
	}

	public static void Update()
	{
		// Update all the entities
		foreach (Entity entity in Entities)
		{
			entity.Update();
		}
	}

	public static void Render()
	{
		// Draw the background
		Utils.DrawTextureOnRectangle(background, Utils.GetWindowRectangle());

		// Draw all the platforms
		foreach (Rectangle rectangle in platforms)
		{
			Raylib.DrawRectangleRec(rectangle, Color.Beige);
		}

		// Draw all the entities
		foreach (Entity entity in Entities)
		{
			entity.Render();
		}
	}

	public static void CleanUp()
	{
		// Get rid of all the entities
		foreach (Entity entity in Entities)
		{
			entity.CleanUp();
		}

		// Unload the background
		// TODO: Use asset manager thingy idk
		Raylib.UnloadTexture(background);
	}
}