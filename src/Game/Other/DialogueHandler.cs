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

		// Get the width allowed for the caption
		const float captionBoxPadding = 50f;
		float boxWidth = Raylib.GetScreenWidth() - captionBoxPadding - captionBoxPadding;

		// Loop over every caption we're showing
		foreach (Caption caption in captions)
		{
			// Grab a copy of the text since we're
			// gonna be manipulating it a bit
			string text = caption.Text;

			// Measure the text
			// TODO: Put font size and whatnot in settings
			const float fontSize = 30f;
			Vector2 textSize = Raylib.MeasureTextEx(Ui.Gabriola, text, fontSize, (fontSize / 10f));

			// Figure out where we need to insert line breaks
			// so that the text doesn't spill out of the box
			//? +1 is to account for any more space added from the wrapping
			int lineBreaks = (int)MathF.Round(textSize.X / boxWidth) + 1;
			int charactersPerLine = text.Length / lineBreaks;

			// Break the text where needed
			// TODO: Break the text at the start of the current word
			// TODO: so that the text isn't cut off in the middle of
			// TODO: a word (not very readable (rinky))
			for (int i = 0; i < lineBreaks; i++)
			{
				// Add the new lines
				//? Using two newlines because raylib is broken or something idk
				text = text.Insert(charactersPerLine * i, "\n\n");
			}

			// Draw the caption box
			// Raylib.DrawRectangleV()
			
			// Draw the text
			Raylib.DrawTextEx(Ui.Gabriola, text, new Vector2(captionBoxPadding), fontSize, (fontSize / 10f), Color.White);
		}
	}

	struct Caption
	{
		public string Text;
		public float LettersPerSecond;
		public float Lifetime;
	}
}