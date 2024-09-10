using System.Numerics;
using Raylib_cs;

class DialogueHandler
{
	// TODO: Chuck this in a settings class or something
	public static bool ShowCaptions = true;

	// TODO: Don't initialize outside of method
	private static List<Caption> captions = new List<Caption>();


	public static void DisplayCaption(string text, double lettersPerSecond, double expirationDate)
	{
		if (ShowCaptions == false) return;

		// Add the new caption to the list
		captions.Add(new Caption()
		{
			Text = text,
			LettersPerSecond = lettersPerSecond,
			ExpirationDate = expirationDate,
			BirthDay = Raylib.GetTime()
		});
	}

	public static void UpdateCaptions()
	{
		// Loop through every caption
		for (int i = 0; i < captions.Count; i++)
		{
			// Get the current caption
			Caption caption = captions[i];

			// Update the captions age
			double currentTime = Raylib.GetTime();
			caption.Age = currentTime - caption.BirthDay;

			// Check for if the caption has
			// expired and remove it
			if (caption.Age > caption.ExpirationDate) captions.Remove(captions[i]);
			else captions[i] = caption;
		}
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
		const float captionBoxMargin = 25f;
		float boxWidth = Raylib.GetScreenWidth() - captionBoxPadding - captionBoxPadding;

		// Set the initial position to draw from the bottom of the screen
		// TODO: Make it so you can specify if caption goes on top or bottom
		float y = Raylib.GetScreenHeight() - 50;

		// Loop over every caption we're showing
		foreach (Caption caption in captions)
		{
			// Get the text
			int lines;
			string text = WrapText(caption.Text, boxWidth, fontSize, fontSpacing, out lines);
			
			// Calculation crap
			//? crazy height calculation crap because raylib broken 
			float height = ((fontSize + lineSpacing) * lines) - lineSpacing;
			Vector2 size = new Vector2(boxWidth, height);
			Vector2 position = new Vector2(captionBoxPadding, y);

			// Draw the box and text
			Raylib.DrawRectangleRounded(new Rectangle(position, size), 0.1f, 10, boxColor);
			Raylib.DrawTextEx(Ui.Gabriola, text, position, fontSize, fontSpacing, Color.White);

			// Increase the Y for the next caption in the queue
			y -= height + captionBoxMargin;
		}
	}

	// TODO: Put this in Utils or something
	private static string WrapText(string text, float maxWidth, float fontSize, float fontSpacing, out int lines)
	{
		// Split the text into words and store out new output
		string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		string output = "";

		// Loop through every word and determine where it 
		// should go and whatnot
		// TODO: Bake this then only update if you resize the window
		lines = 1;
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
			if (textSize.X < maxWidth) output = newOutput;
			else
			{
				// Drop down a line before adding the word
				// and also say what the current height is
				//? Using two newlines because raylib is broken or something idk
				output += "\n\n" + word + " ";
				lines++;
			}
		}

		// Chuck them back the output
		return output;
	}

	struct Caption
	{
		// TODO: shown letters could be calculated from age
		// TODO: Don't use double (use float)
		public string Text;
		public double LettersPerSecond;

		public double BirthDay;
		public double ExpirationDate;
		public double Age;
	}
}