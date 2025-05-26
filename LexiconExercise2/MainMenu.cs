using LexiconExercise2.CinemaPriceHelper;
using LexiconExercise2.InputEchoApp;
using LexiconExercise2.ThirdWordStringSplitterApp;
using LexiconExercise2.MenuHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexiconExercise2.Util;

namespace LexiconExercise2
{
	internal class MainMenu
	{
		//TODO: refactor code to use the readAndWriteToConsole class for all console input output
		private ICinemaPricingHelper _cinemaPricingHelper;
		private IInputEcho _inputEcho;
		private IThirdWordStringSplitter _thirdWordStringSplitter;
		private IReadAndWriteToConsole _readAndWriteToConsole;

		public MainMenu(
			ICinemaPricingHelper cinemaPricingHelper, 
			IInputEcho inputEcho, 
			IThirdWordStringSplitter thirdWordStringSplitter,
			IReadAndWriteToConsole readAndWriteToConsole)
		{
			_cinemaPricingHelper = cinemaPricingHelper;
			_inputEcho = inputEcho;
			_thirdWordStringSplitter = thirdWordStringSplitter;
			_readAndWriteToConsole = readAndWriteToConsole;
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
