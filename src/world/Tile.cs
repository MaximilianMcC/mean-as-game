using System.Numerics;
using Raylib_cs;

interface ITile
{
	// Position (grid space)
	public Vector2 Position { get; set; }

	// Texture index on sprite sheet thing
	public int TextureIndex { get; set; }

	public void Update();
	public void Render();
}

// Terrain such as grass, sand, etc
class TerrainTile : ITile
{
	public Vector2 Position { get; set; }
	public int TextureIndex { get; set; }

	public TerrainTile(Vector2 position)
	{
		Position = position;
	}

	public void Update() { }
	public void Render()
	{
		Raylib.DrawTextureEx(AssetManager.TerrainTextures[TextureIndex], Position * World.TileSize * World.TileScale, 0f, World.TileScale, Color.WHITE);
	}
}

// Resources like trees, and ore deposits
class ResourceTile : ITile
{
	public Vector2 Position { get; set; }
	public int TextureIndex { get; set; }

	public void Update() { }
	public void Render() { }
}

// Machines like miners, furnaces, conveyor belts, etc
class MachineTile : ITile
{
	public Vector2 Position { get; set; }
	public int TextureIndex { get; set; }

	public void Update() { }
	public void Render() { }
}

// Buildings like floors and walls
class BuildTile : ITile
{
	public Vector2 Position { get; set; }
	public int TextureIndex { get; set; }

	public void Update() { }
	public void Render() { }
}