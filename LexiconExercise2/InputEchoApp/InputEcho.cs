using LexiconExercise2.MenuHelpers;
using LexiconExercise2.Util;
using LexiconExercise2.Util.DisplayTextClasses;

namespace LexiconExercise2.InputEchoApp
{
	internal class InputEcho : IInputEcho
	{
		private readonly IReadAndWriteToConsole _readAndWriteToConsole;
		private readonly DisplayTextWrapper _displayTextWrapper;
		private readonly IValidateTextInput _validateTextInput;

		public InputEcho(
			IReadAndWriteToConsole readAndWriteToConsole,
			DisplayTextWrapper displayTextWrapper,
			IValidateTextInput validateTextInput)
		{
			_readAndWriteToConsole = readAndWriteToConsole;
			_displayTextWrapper = displayTextWrapper;
			_validateTextInput = validateTextInput;
		}

		///<inheritdoc/>
		public void InputEchoMenu()
		{
			Console.Clear();
			_displayTextWrapper.DisplayHeaders.DisplayHeaderText(
				"This is the chamber of echoes!\n" +
				"Input your desired echo and how many times it is to be echoed.\n" +
				"If no desired number of echoes is inputted, then the chamber will echo ten times.\n\n"
			);

			bool returnToMainMenu = false;

			do
			{
				string input = _validateTextInput.ValidateMenuInput(
					"Do you which to shout into the chamber of echoes?\n" +
					"1: Shout into the chamber of echoes.\n" +
					"0: Return to main menu.\n",
					rangeMin: 0,
					rangeMax: 1
				);

				Console.ResetColor();

				switch (input)
				{
					case InputEchoMenuHelpers.RETURN_TO_MAIN_MENU:
						return;
					case InputEchoMenuHelpers.SHOUT_INTO_CHAMBER:
						RegisterInput();
						break;
					default:
						break;
				}
			}
			while (!returnToMainMenu);
		}

		///<inheritdoc/>
		public void EchoInputMultipleTimes(string input, uint numberOfEchoes = 10)
		{
			for (int i = 0; i < numberOfEchoes; i++)
			{
				_readAndWriteToConsole.Print(input);
			}

			// Adds an empty line after the echoes for better visibility.
			_readAndWriteToConsole.PrintLine("");		
		}


		///<inheritdoc>
		public void RegisterInput()
		{
			// Prompt the user for input to echo.
			string input = _validateTextInput.ValidateStringInput(
				requestMessage: "What do you want to echo: "
			);

			// Register how often the input should be echoed.
			// 0 represents a default value of 10.
			uint numberOfEchoes = _validateTextInput.ValidateTextIntInput(
				requestMessage: "How many times do you want it echoed (0 = default 10): "
			);
			
			if (numberOfEchoes > 0)
				EchoInputMultipleTimes(input, numberOfEchoes);
			else
				EchoInputMultipleTimes(input);
		}
	}
}