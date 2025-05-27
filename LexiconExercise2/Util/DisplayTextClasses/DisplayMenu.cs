using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Util.DisplayTextClasses
{
	internal class DisplayMenu
	{
		private readonly IReadAndWriteToConsole _readAndWriteToConsole;

		public DisplayMenu(IReadAndWriteToConsole readAndWriteToConsole) 
		{
			_readAndWriteToConsole = readAndWriteToConsole;
		}

		/// <summary>
		/// Class used to format menu related text
		/// Displays menu text in dark gray color.
		/// </summary>
		/// <param name="message">The string message to display.</param>
		public void DisplayMenuText(string message)
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			_readAndWriteToConsole.PrintLine(message);
			Console.ResetColor();
		}
	}
}
