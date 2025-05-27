using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Util
{
	internal static class DisplayMenu
	{
		/// <summary>
		/// Static class used to format menu related text
		/// Displays menu text in dark gray color.
		/// </summary>
		/// <param name="message">The string message to display.</param>
		public static void DisplayMenuText(string message)
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
