using LexiconExercise2.MenuHelpers;
using LexiconExercise2.Util;
using LexiconExercise2.Util.DisplayTextClasses;
using System.Text.RegularExpressions;

namespace LexiconExercise2.ThirdWordStringSplitterApp
{
	/// <summary>
	/// A class that splits a string input into words and finds the third word in the input.
	/// </summary>
	internal class ThirdWordStringSplitter : IThirdWordStringSplitter
	{
		private readonly IReadAndWriteToConsole _readAndWriteToConsole;
		private readonly DisplayTextWrapper _displayTextWrapper;
		private readonly IValidateTextInput _validateTextInput;

		// Regex to match a single whitespace character, used to trim the excess whitespaces from the input
		/* 
		 *	@	: Verbatim string literal used to avoid escape backslashes
		 *	\s	: Matches any whitespace chars like " " "\t" "\n" "   " and so on. 
		 *	+	: Matches one or more occurrences of the preceding character.
		 */
		private Regex _singleWhiteSpaceRegex = new Regex(@"\s+");

		public ThirdWordStringSplitter(
			IReadAndWriteToConsole readAndWriteToConsole, 
			DisplayTextWrapper displayTextWrapper,
			IValidateTextInput validateTextInput)
		{
			_readAndWriteToConsole = readAndWriteToConsole;
			_displayTextWrapper = displayTextWrapper;
			_validateTextInput = validateTextInput;
		}


		///<inheritdoc/>
		public void ThirdWordStringSplitterMenu()
		{
			bool returnToMainMenu = false;

			Console.Clear();

			_displayTextWrapper.DisplayHeaders.DisplayHeaderText(
				"Which is the third word? \n" +
				"By giving a sentence or just strings separated by a space, I will find the third word grouping.\n" +
				"A minimum of 3 words/strings must be entered!"
			);

			do
			{
				string input = _validateTextInput.ValidateMenuInput(
					"1: Start the input process.\n" +
					"0: Return to main menu.\n",
					rangeMin: 0, 
					rangeMax: 1
				);
	
				switch (input)
				{
					case ThirdWordStringSplitterMenuHelpers.RETURN_TO_MAIN_MENU:
						return;
					case ThirdWordStringSplitterMenuHelpers.FIND_THIRD_WORD:
						RegisterInput();
						break;
					default:
						break;
				}
			}
			while (!returnToMainMenu);
		}

		/// <inheritdoc>
		public void FindThirdWord(string[] input) => 
			_readAndWriteToConsole.PrintLine(input[2]);					
		

		///<inheritdoc/>
		public void RegisterInput()
		{
			bool enoughWords = false;
			
			do
			{
			    _readAndWriteToConsole.PrintLine(
					"Please enter a sentence comprising a minimum of three words separated by a single space: "
				);

				// Register input and trims start and end whitespaces.
				var input = _readAndWriteToConsole.ReadInput().Trim();

				// Splits input into separate strings in an array.
				// Replaces any instances of multiple whitespace characters with a single space.
				var singleSpaceInput = _singleWhiteSpaceRegex.Replace(input, " ").Split(' ');

				// There is a minimum requirement of three words in the input string.
				if (singleSpaceInput.Length >= 3)
				{
					FindThirdWord(singleSpaceInput);
					enoughWords = true;
				}
				else
					_displayTextWrapper.DisplayErrorMessages.DisplayErrorMessage("Not enough words!");

			} while (!enoughWords);
		}

	}
}