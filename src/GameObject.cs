class GameObject
{
	public GameObject()
	{
		// Add the current game object to the list
		// of game objects so it ca be handled correctly
		Game.GameObjects.Add(this);
	}

	public virtual void Start() { }
	public virtual void Update() { }
	public virtual void Tick() { }
	public virtual void Render() { }
	public virtual void CleanUp() { }
}