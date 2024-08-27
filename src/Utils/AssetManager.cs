using System.Reflection;
using Raylib_cs;

class AssetManager
{
	private static readonly string Namespace = "mean_as_game";

	private static byte[] GetAssetBytes(string assetPath, out string extension)
	{
		// Get the current assembly and namespace
		// so we can extract the assets and whatnot
		Assembly assembly = Assembly.GetExecutingAssembly();

		// Get the path to the asset and its file extension
		assetPath = assetPath.Replace("./", "").Replace("/", ".");
		string path = $"{Namespace}.{assetPath}";
		extension = Path.GetExtension(assetPath);

		// Get the stream containing the assets data
		using (Stream stream = assembly.GetManifestResourceStream(path))
		{
			// Check for if there is a stream or not
			if (stream == null)
			{
				throw new Exception("Could not find embedded asset at " + path);
			}

			// Get the stream as a byte array
			byte[] bytes;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				// Extract the bytes
				stream.CopyTo(memoryStream);

				// Give them back
				bytes = memoryStream.ToArray();
				return bytes;
			}
		}

	}

	public static Texture2D LoadTexture(string path)
	{
		// Get the asset byte array and extension
		byte[] bytes = GetAssetBytes(path, out string extension);

		// Load the raylib image from the byte array
		// then load the raylib texture from the image
		Image image = Raylib.LoadImageFromMemory(extension, bytes);
		Texture2D texture = Raylib.LoadTextureFromImage(image);

		// Unload the image since we no longer need it
		Raylib.UnloadImage(image);

		// Give back the loaded texture
		return texture;
	}

	public static Sound LoadSound(string path)
	{
		// Get the asset byte array and extension
		byte[] bytes = GetAssetBytes(path, out string extension);

		// Load the wave data from the raw bytes then use
		// that to load the sound
		Wave wave = Raylib.LoadWaveFromMemory(extension, bytes);
		Sound sound = Raylib.LoadSoundFromWave(wave);

		// Unload the wave data because we don't need it anymore
		Raylib.UnloadWave(wave);

		// Give back the sound
		return sound;
	}

	public static Font LoadFont(string path)
	{
		// Get the asset byte array and extension
		byte[] bytes = GetAssetBytes(path, out string extension);

    	// Define the character set (e.g., ASCII characters 32-126)
    	int[] fontChars = Enumerable.Range(32, 95).ToArray(); // ASCII characters from 32 to 126

		// Load the font from the raw bytes
		Font font = Raylib.LoadFontFromMemory(extension, bytes, 32, fontChars, fontChars.Length);

		// Give back the font
		return font;
	}
}