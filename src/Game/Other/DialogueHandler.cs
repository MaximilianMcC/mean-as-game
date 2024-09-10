using System.Numerics;
using Raylib_cs;

class DialogueHandler
{
	// TODO: Chuck this in a settings class or something
	public static bool ShowCaptions = true;

	// TODO: Don't initialize outside of method
	private static List<Caption> captions = new List<Caption>();


	public static void DisplayCaption(string text, float lettersPerSecond, float lifetime)
	{
		if (ShowCaptions == false) return;

		// Add the new caption to the list
		captions.Add(new Caption()
		{
			Text = text,
			LettersPerSecond = lettersPerSecond,
			Lifetime = lifetime
		});
	}

	public static void RenderCaptions()
	{
		if (ShowCaptions == false) return;

		// TODO: Put all this stuff in settings
		const float fontSize = 20f;
		const float fontSpacing = fontSize / 10;
		const float lineSpacing = fontSize / 2;
		Color boxColor = new Color(0, 0, 0, 128);

		// Get the width allowed for the caption
		const float captionBoxPadding = 50f;
		const float captionBoxMargin = 50f;
		float boxWidth = Raylib.GetScreenWidth() - captionBoxPadding - captionBoxPadding;

		// Set the initial position to draw from the bottom of the screen
		// TODO: Make it so you can specify if caption goes on top or bottom
		float y = Raylib.GetScreenHeight() - captionBoxMargin;

		// Loop over every caption we're showing
		foreach (Caption caption in captions)
		{
			// Split the text into words and store out new output
			string[] words = caption.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			string output = "";

			// Loop through every word and determine where it 
			// should go and whatnot
			// TODO: Bake this then only update if you resize the window
			int lines = 1;
			foreach (string word in words)
			{
				// Add the new word to the output
				// and then measure it
				// TODO: Don't measure for every word
				string newOutput = output + word + " ";
				Vector2 textSize = Raylib.MeasureTextEx(Ui.Gabriola, newOutput, fontSize, fontSpacing);	

				// If we put in a newline then add the new line
				//? idk if this actually works
				if (word.Contains('\n')) lines++;

				// If we have enough room to add the new
				// word to the current line
				if (textSize.X < boxWidth) output = newOutput;
				else
				{
					// Drop down a line before adding the word
					// and also say what the current height is
					//? Using two newlines because raylib is broken or something idk
					output += "\n\n" + word + " ";
					lines++;
				}
			}
			
			// Calculation crap
			//? crazy height calculation crap because raylib broken 
			float height = ((fontSize + lineSpacing) * lines) - lineSpacing;
			Vector2 size = new Vector2(boxWidth, height);
			Vector2 position = new Vector2(captionBoxPadding, y);

			// Draw the box and text
			Raylib.DrawRectangleRounded(new Rectangle(position, size), 0.1f, 10, boxColor);
			Raylib.DrawTextEx(Ui.Gabriola, output, position, fontSize, fontSpacing, Color.White);

			// Increase the Y for the next caption in the queue
			y += height + captionBoxMargin;
		}
	}

	struct Caption
	{
		public string Text;
		public float LettersPerSecond;
		public float Lifetime;
	}
}