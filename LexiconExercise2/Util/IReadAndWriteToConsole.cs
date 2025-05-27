namespace LexiconExercise2.Util
{
	public interface IReadAndWriteToConsole
	{

		/// <summary>
		/// Prints the supplied message to the console and breaks to new line.
		/// </summary>
		/// <param name="message">A string containing the message to print.</param>
		void PrintLine(string message);

		/// <summary>
		/// Prints the supplied message to the console, stays on the same row.
		/// </summary>
		/// <param name="message">A string containing the message to print.</param>
		void Print(string message);

		/// <summary>
		/// Reads input from the console and returns it as a string.
		/// If the input received is null, an empty string should be returned instead.
		/// </summary>
		/// <returns>A string representing the input.</returns>
		string ReadInput();
	}
}