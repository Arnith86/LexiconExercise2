using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Util.DisplayTextClasses
{
	internal class DisplayHeaders
	{
		private readonly IReadAndWriteToConsole _readAndWriteToConsole;
		public DisplayHeaders(IReadAndWriteToConsole readAndWriteToConsole)
		{
			_readAndWriteToConsole = readAndWriteToConsole;
		}

		/// <summary>
		/// Displays header text in yellow color.
		/// </summary>
		/// <param name="message">The string message to display.</param>
		public void DisplayHeaderText(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			_readAndWriteToConsole.PrintLine(message);
			Console.ResetColor();
		}
	}
}
