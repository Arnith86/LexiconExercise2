using LexiconExercise2.MenuHelpers;
using System.Text.RegularExpressions;

namespace LexiconExercise2.ThirdWordStringSplitter
{
	internal class ThirdWordStringSplitter : IThirdWordStringSplitter
	{
		// Regex to match a single whitespace character, used to trim the excess whitespaces from the input
		/* 
		 * @	: Verbatim string literal used to avoid escape backslashes
		 * \s	: Matches any whitespace chars like " " "\t" "\n" "   " and so on. 
		 * +	: Matches one or more occurrences of the preceding character.
		*/
		Regex _singleWhiteSpaceRegex = new Regex(@"\s+");

		public void FindThirdWord(string[] input)
		{
			Console.WriteLine(input[2]);					
		}

		///<inheritdoc/>
		public void RegisterInput()
		{
			bool enoughWords = false;

			do
			{
				Console.WriteLine("Please enter a sentence comprising a minimum of three words separated by a single space: ");

				// Register input and trims start and end whitespaces.
				var input = Console.ReadLine().Trim();

				// Splits input into separate strings in an array.
				// Replaces any instances of multiple whitespace characters with a single space.
				var singleSpaceInput = _singleWhiteSpaceRegex.Replace(input, " ").Split(' ');

				if (singleSpaceInput.Length >= 3)
				{
					FindThirdWord(singleSpaceInput);
					enoughWords = true;
				}
				else
					ErrorMessages.DisplayErrorMessage("Not enough words!");

			} while (!enoughWords);
		}

		///<inheritdoc/>
		public void ThirdWordStringSplitterMenu()
		{
			bool returnToMainMenu = false;

			Console.Clear();

			DisplayHeaders.DisplayHeaderText(
				"Which is the third word? \n" +
				"By giving a sentence or just strings separated by a space, I will find the third word grouping." +
				"A minimum of 3 words/strings must be entered!");

			do
			{
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("0: Return to main menu.");
				Console.WriteLine("1: Start the input process.");
				Console.ResetColor();

				string input = Console.ReadLine();

				switch (input)
				{
					case ThirdWordStringSplitterMenuHelpers.RETURN_TO_MAIN_MENU:
						return;
						break;
					case ThirdWordStringSplitterMenuHelpers.FIND_THIRD_WORD:
						RegisterInput();
						break;
					default:
						ErrorMessages.InvalidIntInput();
						break;
				}
			}
			while (!returnToMainMenu);
		}
	}
}