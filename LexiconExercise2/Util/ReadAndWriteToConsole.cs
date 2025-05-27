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
	public class ReadAndWriteToConsole : IReadAndWriteToConsole
	{
		/// <inheritdoc/>
		public void Print(string message) => Console.Write(message);

		/// <inheritdoc/>
		public void PrintLine(string message) => Console.WriteLine(message);
		
		/// <inheritdoc/>
		public string ReadInput() =>
			Console.ReadLine() ?? string.Empty;

	}
}
