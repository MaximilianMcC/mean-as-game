using System.Numerics;
using Raylib_cs;

abstract class Tile
{
	// TODO: Add getters and setters
	public Vector2 Position;
	public Vector2 Rotation;
	public Texture2D Texture;

	public Tile(Vector2 position, Texture2D texture)
	{
		Position = position;
		Texture = texture;	
	}

	public virtual void Start() { }

	public virtual void Update() { }

	public virtual void Render()
	{
		Raylib.DrawTextureEx(Texture, Position * Game.World.TileSize, 0f, 1f, Color.WHITE);
	}

	public virtual void CleanUp() { }
}