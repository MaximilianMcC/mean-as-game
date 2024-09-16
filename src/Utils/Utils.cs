using System.Numerics;
using Raylib_cs;

class Utils
{
	// TODO: Don't initialize things here
	public static Random Random = new Random();

	public static string RandomElement(string[] array)
	{
		return array[Random.Next(0, array.Length)];
	}

	public static void DrawTextureOnRectangle(Texture2D texture, Rectangle rectangle)
	{
		Raylib.DrawTexturePro(
			texture,
			GetTextureRectangle(texture),
			rectangle,
			Vector2.One,
			0f,
			Color.White
		);
	}

	
	public static void DrawTextureOnRectangle(Texture2D texture, Rectangle rectangle, int xDirection, int yDirection)
	{
		// Get the texture dimensions
		Rectangle textureRectangle = GetTextureRectangle(texture);

		// Calculate the destination rectangle dimensions
		float destWidth = rectangle.Width * xDirection;
		float destHeight = rectangle.Height * yDirection;

		// Ensure that the destination width and height are positive
		destWidth = Math.Abs(destWidth);
		destHeight = Math.Abs(destHeight);

		// Create the destination rectangle
		Rectangle destRec = new Rectangle(
			rectangle.Position.X - (destWidth - rectangle.Width) / 2,
			rectangle.Position.Y - (destHeight - rectangle.Height) / 2,
			destWidth,
			destHeight
		);

		// Adjust the source rectangle based on flipping
		Rectangle sourceRec = new Rectangle(
			textureRectangle.X + (textureRectangle.Width * (1 - xDirection)) / 2,
			textureRectangle.Y + (textureRectangle.Height * (1 - yDirection)) / 2,
			textureRectangle.Width * xDirection,
			textureRectangle.Height * yDirection
		);

		// Draw the texture
		Raylib.DrawTexturePro(
			texture,
			sourceRec,
			destRec,
			Vector2.One,
			0f,
			Color.White
		);
	}


	public static Rectangle GetWindowRectangle()
	{
		return new Rectangle(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
	}


	public static Rectangle GetTextureRectangle(Texture2D texture)
	{
		return new Rectangle(0, 0, new Vector2(texture.Width, texture.Height));
	}
}