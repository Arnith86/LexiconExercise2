namespace LexiconExercise2.Util
{
	/// <summary>
	/// This static class supplies generic error messages that can be used throughout the application.
	/// </summary>
	internal static class ErrorMessages
	{

		/// <summary>
		/// Used to inform that input supplied was either not a number or outside the expected range.
		/// </summary>
		internal static void InvalidIntInput()
		{
			DisplayErrorMessage("You supplied an invalid input! \nOnly integers within the menus range are allowed, try again!");
		}

		/// <summary>
		/// Used to inform that input supplied was not a valid age.
		/// </summary>
		internal static void InvalidAgeInput()
		{
			DisplayErrorMessage("Not a valid or reasonable age, try again!");
		}

		/// <summary>
		/// Displays the supplied error message in red text on the console.
		/// </summary>
		/// <param name="message">The string message to display.</param>
		public static void DisplayErrorMessage(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}