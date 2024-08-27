using Raylib_cs;

class Ui
{
	public static Font TimesNewRoman;

	public static void Load()
	{
		TimesNewRoman = AssetManager.LoadFont("./assets/ui/times.ttf");
	}

	public static void CleanUp()
	{
		Raylib.UnloadFont(TimesNewRoman);
	}
}