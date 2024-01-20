using System.Numerics;
using Raylib_cs;

class Grass : TerrainTile
{
	public Grass(Vector2 position) : base(position)
	{
		TextureIndex = Raylib.GetRandomValue(0, 1);
	}
}