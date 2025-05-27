using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Util.DisplayTextClasses
{
	/// <summary>
	/// A record that wraps multiple display text classes for ease of access.
	/// </summary>
	/// <param name="DisplayMenu">Class that handles the menu formatting.</param>
	/// <param name="DisplayHeaders">Class that handles the header formatting.</param>
	/// <param name="DisplayErrorMessages">Class that handles the error message formatting.</param>
	internal record DisplayTextWrapper(
		DisplayMenu DisplayMenu, 
		DisplayHeaders DisplayHeaders, 
		DisplayErrorMessages DisplayErrorMessages
	);
}
