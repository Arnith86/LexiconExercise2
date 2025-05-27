namespace LexiconExercise2.Util.DisplayTextClasses
{
	/// <summary>
	/// This class supplies generic error messages that can be used throughout the application.
	/// </summary>
	internal class DisplayErrorMessages
	{
		IReadAndWriteToConsole _readAndWriteToConsole;

		public DisplayErrorMessages(IReadAndWriteToConsole readAndWriteToConsole)
		{
			_readAndWriteToConsole = readAndWriteToConsole;
		}

		/// <summary>
		/// Used to inform that input supplied was either not a number or outside the expected range.
		/// </summary>
		internal void InvalidIntInput()
		{
			DisplayErrorMessage("You supplied an invalid input! \nOnly integers within the menus range are allowed, try again!");
		}

		/// <summary>
		/// Used to inform that input supplied was not a valid age.
		/// </summary>
		internal void InvalidAgeInput()
		{
			DisplayErrorMessage("Not a valid or reasonable age, try again!");
		}

		/// <summary>
		/// Displays the supplied error message in red text on the console.
		/// </summary>
		/// <param name="message">The string message to display.</param>
		public void DisplayErrorMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			_readAndWriteToConsole.PrintLine(message);
			Console.ResetColor();
		}
	}
}