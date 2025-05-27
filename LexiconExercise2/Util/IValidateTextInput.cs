using LexiconExercise2.Util.DisplayTextClasses;

namespace LexiconExercise2.Util
{
	internal interface IValidateTextInput
	{
		/// <summary>
		/// Validates input expected to have a minimum of one character. 
		/// </summary>
		/// <param name="requestMessage">The message displayed to user, requesting the specified input.</param>
		/// <returns>A validated string.</returns>
		string ValidateStringInput(string requestMessage);

		/// <summary>
		/// Validates input expected to be in uint format. 
		/// </summary>
		/// <param name="requestMessage">The message displayed to user, requesting the specified input.</param>
		/// <returns>uint converted from the string input.</returns>
		uint ValidateTextIntInput(string requestMessage);


		/// <summary>
		/// Validates input expected to be a menu selection, i.e. a number within a specified range.
		/// </summary>
		/// <param name="requestMessage">The message displayed to user, requesting the specified input.</param>
		/// <param name="rangeMin">Start value of the menu range.</param>
		/// <param name="rangeMax">End value of the menu range.</param>
		/// <returns>uint converted from the string input.</returns>
		string ValidateMenuInput(string requestMessage, int rangeMin, int rangeMax);
		
	}
}