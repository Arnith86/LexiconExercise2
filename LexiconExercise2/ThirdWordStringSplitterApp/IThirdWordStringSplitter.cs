namespace LexiconExercise2.ThirdWordStringSplitterApp
{
	internal interface IThirdWordStringSplitter
	{
		/// <summary>
		/// Displays the menu and handles menu navigation.  
		/// </summary>
		void ThirdWordStringSplitterMenu();

		/// <summary>
		/// Prompts the user to input a string, and handles input. 
		/// There is a minimum requirement of three words in the input string.
		/// </summary>
		void RegisterInput();

		/// <summary>
		/// Finds and displays the third word in a given string input.
		/// </summary>
		/// <param name="input">The string that is searched.</param>
		void FindThirdWord(string[] input);
	}
}