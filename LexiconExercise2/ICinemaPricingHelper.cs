namespace LexiconExercise2
{
	/// <summary>
	/// Defines helper methods for managing cinema pricing logic.
	/// </summary>
	public interface ICinemaPricingHelper
	{
		/// <summary>
		/// Displays the main and handles menu navigation.  
		/// </summary>
		void CinemaPricingMenu();

		/// <summary>
		/// Displays the pricing results for a single visitor.
		/// </summary>
		void DisplayPricing();
		
		/// <summary>
		/// Displays the pricing results based on the user input.
		/// </summary>
		void DisplayPricing(int visitors);
	}
}