using System.Numerics;

class Grass : TerrainTile
{
	public Grass(Vector2 position) : base(position)
	{
		// TODO: More grass textures, and get a random one
		TextureIndex = 0;
	}
}