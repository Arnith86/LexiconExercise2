using LexiconExercise2.Util.DisplayTextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Util
{
	internal class ValidateTextInput : IValidateTextInput
	{
		private readonly IReadAndWriteToConsole _readAndWriteToConsole;
		private readonly DisplayTextWrapper _displayTextWrapper;

		public ValidateTextInput(
			IReadAndWriteToConsole readAndWriteToConsole,
			DisplayTextWrapper displayTextWrapper
			)
		{
			_readAndWriteToConsole = readAndWriteToConsole;
			_displayTextWrapper = displayTextWrapper;
		}

		/// <inheritdoc/>
		public string ValidateStringInput(string requestMessage)
		{
			_readAndWriteToConsole.Print(requestMessage);

			string input = string.Empty;

			while (true)
			{
				input = _readAndWriteToConsole.ReadInput();

				if (string.IsNullOrWhiteSpace(input))
					_displayTextWrapper.DisplayErrorMessages.InvalidInputEmpty();
				else 
					break; // input is valid, exit loop.
			}

			return input;
		}

		/// <inheritdoc/>
		public uint ValidateTextIntInput(string requestMessage)
		{
			_readAndWriteToConsole.Print(requestMessage);

			string input = string.Empty;
			uint result = 0;

			while (true)
			{
				input = _readAndWriteToConsole.ReadInput();

				if (string.IsNullOrWhiteSpace(input))
					_displayTextWrapper.DisplayErrorMessages.InvalidInputEmpty();
				else if (!uint.TryParse(input, out uint uInt))
					_displayTextWrapper.DisplayErrorMessages.InvalidInputNegativeValue();
				else
				{
					result = uInt;
					break; // input is valid, exit loop.
				}
			}

			return result;
		}

		/// <inheritdoc/>
		public string ValidateMenuInput(string requestMessage, int rangeMin, int rangeMax)
		{
			_displayTextWrapper.DisplayMenu.DisplayMenuText(requestMessage);

			string input = string.Empty;
			
			while (true)
			{
				input = _readAndWriteToConsole.ReadInput();

				if (string.IsNullOrWhiteSpace(input))
				{
					_displayTextWrapper.DisplayErrorMessages.InvalidInputEmpty();
				}
				// Tries to convert input to int, and check if it is within menu range.
				else if (!int.TryParse(input, out int intInput) || IsInputOutOfRange(rangeMin, rangeMax, intInput))
				{
					_displayTextWrapper.DisplayErrorMessages.InvalidMenuInput();
				}
				else
					break; // input is valid, exit loop.
			}

			return input;
		}

		private bool IsInputOutOfRange(int rangeMin, int rangeMax, int input)
		{
			return 	input < rangeMin || input > rangeMax;
		}
	}
}
