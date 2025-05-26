using LexiconExercise2.MenuHelpers;

namespace LexiconExercise2
{
	internal class InputEcho : IInputEcho
	{
		///<inheritdoc/>
		public void InputEchoMenu()
		{
			Console.Clear();
			DisplayHeaders.DisplayHeaderText(
				"This is the chamber of echoes!\n" +
				"Input your desired echo and how many times it is to be echoed.\n" +
				"If no desired number of echoes is inputted, then the chamber will echo ten times.\n\n");

			bool returnToMainMenu = false;

			do
			{
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("Do you which to shout into the chamber of echoes?");
				Console.WriteLine("0: Return to main menu.");
				Console.WriteLine("1: Shout into the chamber of echoes."); 
				Console.ResetColor();

				string input = Console.ReadLine();

				switch (input)
				{
					case InputEchoMenuHelpers.RETURN_TO_MAIN_MENU:
						return;
						break;
					case InputEchoMenuHelpers.SHOUT_INTO_CHAMBER:
						RegisterInput();
						break;
					default:
						ErrorMessages.InvalidIntInput();
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
				Console.Write(input);
			}

			// Adds an empty line after the echoes for better visibility.
			Console.WriteLine(); 
		}


		///<inheritdoc>
		public void RegisterInput()
		{
			// Prompt the user for input to echo.
			Console.Write("What do you want to echo: ");
			string input = Console.ReadLine();

			// Register how often the input should be echoed.
			// If no input or invalid input is given, then the default of 10 echoes will be used.			
			Console.Write("How many times do you want it echoed (default 10): ");
			string numberInput = Console.ReadLine();

			if (!string.IsNullOrEmpty(numberInput) && int.TryParse(numberInput, out int numberOfEchoes))
				EchoInputMultipleTimes(input, numberOfEchoes);
			else
				EchoInputMultipleTimes(input);		
		}
	}
}