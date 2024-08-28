using System.Numerics;
using Raylib_cs;

class Utils
{
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

	public static Rectangle GetTextureRectangle(Texture2D texture)
	{
		return new Rectangle(0, 0, new Vector2(texture.Width, texture.Height));
	}
}