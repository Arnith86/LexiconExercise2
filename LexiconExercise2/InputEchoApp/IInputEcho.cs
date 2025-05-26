using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.InputEchoApp
{
	/// <summary>
	/// Defines an interface for echoing user input multiple times.
	/// </summary>
	internal interface IInputEcho
	{

		/// <summary>
		/// Displays the menu and handles menu navigation.  
		/// </summary>
		void InputEchoMenu();

		/// <summary>
		/// Register input to be repeated, and how many times it should be echoed.
		/// </summary>
		void RegisterInput();

		/// <summary>
		/// Echoes the inputted string a specified number of times.
		/// </summary>
		/// <param name="input">String to be echoed.</param>
		/// <param name="numberOfEchoes">The number of echoes to perform, 10 echoes is the default.</param>
		void EchoInputMultipleTimes(string input, int numberOfEchoes = 10);
	}
}
