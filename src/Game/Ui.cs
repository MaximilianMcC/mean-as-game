using Raylib_cs;

class Ui
{
	public static Font TimesNewRoman;
	public static Font Gabriola;

	public static void Load()
	{
		TimesNewRoman = AssetManager.LoadFont("./assets/ui/times.ttf");
		Gabriola = AssetManager.LoadFont("./assets/ui/gabriola.ttf");
	}

	public static void CleanUp()
	{
		Raylib.UnloadFont(TimesNewRoman);
		Raylib.UnloadFont(Gabriola);
	}
}