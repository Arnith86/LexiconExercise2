using LexiconExercise2.CinemaPriceHelper;
using LexiconExercise2.MenuHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2
{
	internal class MainMenu
	{

		private ICinemaPricingHelper _cinemaPricingHelper;
		private IInputEcho _inputEcho;
		private IThirdWordStringSplitter _thirdWordStringSplitter;

		public MainMenu(ICinemaPricingHelper cinemaPricingHelper, IInputEcho inputEcho, IThirdWordStringSplitter thirdWordStringSplitter)
		{
			_cinemaPricingHelper = cinemaPricingHelper;
			_inputEcho = inputEcho;
			_thirdWordStringSplitter = thirdWordStringSplitter;
		}

		public void DisplayMainMenu()
		{
			DisplayHeaders.DisplayHeaderText(
			   "Welcome, this is the main menu. \n" +
			   "To test the features bellow input its corresponding number!\n"
		   );

			bool exitProgram = false;

			string input = string.Empty;

			do
			{
				//TODO: create menu display class.
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("0: Exit the program.");
				Console.WriteLine("1: Cinema Pricing.");
				Console.WriteLine("2: Input Echo. Writes back input multiple times.");
				Console.WriteLine("3: String Splitter - Which is the third word?");
				Console.ResetColor();

				input = Console.ReadLine();

				switch (input)
				{
					case MainManuHelpers.EXIT:
						exitProgram = true;
						break;
					case MainManuHelpers.CINEMA_PRICING:
						_cinemaPricingHelper.CinemaPricingMenu();
						break;
					case MainManuHelpers.INPUT_ECHO:
						_inputEcho.InputEchoMenu();
						break;
					case MainManuHelpers.THIRD_WORD_STRING_SPLITTER:
						_thirdWordStringSplitter.ThirdWordStringSplitterMenu();
						break;
					default:
						ErrorMessages.InvalidIntInput();
						break;
				}
			}
			while (!exitProgram);
		}
	}
}
