using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2
{
	internal static class DisplayHeaders
	{
		/// <summary>
		/// Displays header text in yellow color.
		/// </summary>
		/// <param name="message">The string message to display.</param>
		public static void DisplayHeaderText(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
}
