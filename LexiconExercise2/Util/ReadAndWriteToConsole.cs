using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Util
{
	/// <summary>
	/// This wrapper class provides methods for reading from and writing to the console.
	/// Will help to abstract console input and output operations, making it easier to test and maintain the code.
	/// </summary>
	public class ReadAndWriteToConsole
	{
		/// <summary>
		/// Prints the supplied message to the console.
		/// </summary>
		/// <param name="message">A string containing the message to print.</param>
		public void Print(string message) => Console.WriteLine(message);
		


		/// <summary>
		/// Reads input from the console and returns it as a string.
		/// If the input received is null, an empty string is returned instead.
		/// </summary>
		/// <returns>A string representing the input.</returns>
		public string ReadInput() =>
			Console.ReadLine() ?? string.Empty;

	}
}
