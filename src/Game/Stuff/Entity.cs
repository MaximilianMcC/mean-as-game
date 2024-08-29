using System.Numerics;
using Raylib_cs;

class Entity : GameObject
{
	public Rectangle Hitbox;
	public Vector2 Velocity;
	public bool OnGround;
}