using LexiconExercise2.MenuHelpers;
using LexiconExercise2.Util;
using LexiconExercise2.Util.DisplayTextClasses;

namespace LexiconExercise2.InputEchoApp
{
	internal class InputEcho : IInputEcho
	{
		IReadAndWriteToConsole _readAndWriteToConsole;
		DisplayTextWrapper _displayTextWrapper;

		public InputEcho(
			IReadAndWriteToConsole readAndWriteToConsole,
			DisplayTextWrapper displayTextWrapper)
		{
			_readAndWriteToConsole = readAndWriteToConsole;
			_displayTextWrapper = displayTextWrapper;
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
				_displayTextWrapper.DisplayMenu.DisplayMenuText(
					"Do you which to shout into the chamber of echoes?\n" +
					"1: Shout into the chamber of echoes.\n" +
					"0: Return to main menu.\n"
				);
				 
				Console.ResetColor();

				string input = _readAndWriteToConsole.ReadInput();

				switch (input)
				{
					case InputEchoMenuHelpers.RETURN_TO_MAIN_MENU:
						return;
						break;
					case InputEchoMenuHelpers.SHOUT_INTO_CHAMBER:
						RegisterInput();
						break;
					default:
						_displayTextWrapper.DisplayErrorMessages.InvalidIntInput();
						break;
				}
			}
			while (!returnToMainMenu);
		}

		///<inheritdoc/>
		public void EchoInputMultipleTimes(string input, int numberOfEchoes = 10)
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
			_readAndWriteToConsole.Print("What do you want to echo: ");
			string input = _readAndWriteToConsole.ReadInput();

			// Register how often the input should be echoed.
			// If no input or invalid input is given, then the default of 10 echoes will be used.			
			_readAndWriteToConsole.Print("How many times do you want it echoed (default 10): ");
			string numberInput = _readAndWriteToConsole.ReadInput();

			if (!string.IsNullOrEmpty(numberInput) && int.TryParse(numberInput, out int numberOfEchoes))
				EchoInputMultipleTimes(input, numberOfEchoes);
			else
				EchoInputMultipleTimes(input);		
		}
	}
}