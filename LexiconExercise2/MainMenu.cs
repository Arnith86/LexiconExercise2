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
using LexiconExercise2.Util.DisplayTextClasses;

namespace LexiconExercise2
{
	internal class MainMenu
	{
		private ICinemaPricingHelper _cinemaPricingHelper;
		private IInputEcho _inputEcho;
		private IThirdWordStringSplitter _thirdWordStringSplitter;
		private readonly IReadAndWriteToConsole _readAndWriteToConsole;
		private readonly DisplayTextWrapper _displayTextWrapper;
		private readonly IValidateTextInput _validateTextInput;

		public MainMenu(
			ICinemaPricingHelper cinemaPricingHelper, 
			IInputEcho inputEcho, 
			IThirdWordStringSplitter thirdWordStringSplitter,
			IReadAndWriteToConsole readAndWriteToConsole,
			DisplayTextWrapper displayTextWrapper, 
			IValidateTextInput validateTextInput)
		{
			_cinemaPricingHelper = cinemaPricingHelper;
			_inputEcho = inputEcho;
			_thirdWordStringSplitter = thirdWordStringSplitter;
			_readAndWriteToConsole = readAndWriteToConsole;
			_displayTextWrapper = displayTextWrapper;
			_validateTextInput = validateTextInput;
		}

		public void DisplayMainMenu()
		{
			_displayTextWrapper.DisplayHeaders.DisplayHeaderText(
			   "Welcome, this is the main menu. \n" +
			   "To test the features bellow input its corresponding number!\n"
		    );

			bool exitProgram = false;

			string input = string.Empty;

			do
			{
				input = _validateTextInput.ValidateMenuInput(
					"1: Cinema Pricing.\n" +
					"2: Input Echo. Writes back input multiple times.\n" +
					"3: String Splitter - Which is the third word?\n" +
					"0: Exit the program.\n",
					rangeMin: 0,
					rangeMax: 3
				);
				

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
						break;
				}
			}
			while (!exitProgram);
		}
	}
}
