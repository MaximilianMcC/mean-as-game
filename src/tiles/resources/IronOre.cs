using System.Numerics;
using Raylib_cs;

class IronOre : ResourceTile
{
	public IronOre(Vector2 position) : base(position)
	{
		// TextureIndex = Raylib.GetRandomValue(0, 2);
		TextureIndex = 0;
	}
}