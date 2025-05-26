
using LexiconExercise2.MenuHelpers;

namespace LexiconExercise2
{
	internal class CinemaPricingHelper : ICinemaPricingHelper
	{
		//TODO: use uint when none negative int input is required

		/// <summary>
		/// Enum representing the different age pricing categories for cinema tickets.
		/// </summary>
		private enum AgePricing
		{
			Youth = 80,
			Standard = 120,
			Senior = 90,
			Free = 0
		}

		///<inheritdoc/>
		public void CinemaPricingMenu() 
		{
			bool returnToMainMenu = false;

			Console.Clear();
			 
			DisplayHeaders.DisplayHeaderText("Cinema Pricing! \nHere to help you find the correct pricing for individuals or groups!");
			
			do
			{
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("0: Return to main menu.");
				Console.WriteLine("1: Single visitor.");
				Console.WriteLine("2: Group of visitors.");
				Console.ResetColor();

				string input = Console.ReadLine();

				switch (input)
				{
					case CinemaPricingMenuHelpers.RETURN_TO_MAIN_MENU:
						return;
						break;
					case CinemaPricingMenuHelpers.SINGLE_VISITOR:
						DisplayPricing();
						break;
					case CinemaPricingMenuHelpers.GROUP_OF_VISITORS:
						int nrOfVisitors = RegisterVisitorsNumber();
						DisplayPricing(nrOfVisitors);
						break;
					default:
						ErrorMessages.InvalidIntInput(); 
						break;
				}
			}
			while (!returnToMainMenu);
		}

		/// <summary>
		/// Converts an integer value to a currency string format.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>String in currency format.</returns>
		private string IntToCurranty(int value) => value.ToString("C");

		///<inheritdoc/>
		public void DisplayPricing()
		{
			int age = RegisterVisitorAge();
			var pricing = EvaluateSingleVisitorPrice(age);

			if (pricing.Equals(AgePricing.Youth))
				Console.WriteLine("Youth price: {0}\n", IntToCurranty((int)pricing)); 
			else if (pricing.Equals(AgePricing.Senior))
				Console.WriteLine("Senior price: {0}\n", IntToCurranty((int)pricing));
			else
				Console.WriteLine("Standard price: {0}\n", IntToCurranty((int)pricing)); 
		}

		///<inheritdoc/>
		public void DisplayPricing(int visitor)
		{
			List<int> ages = new List<int>();

			// Registers the ages of the visitors based on user input
			for (int i = 0; i < visitor; i++)
			{
				Console.Write("Visitor {0} ", i+1);
				ages.Add(RegisterVisitorAge());
			}

			int totalPrice = 0;

			// Calculates the total price based on the ages of the visitors
			foreach (var age in ages)
				totalPrice += (int)EvaluateSingleVisitorPrice(age);
			
			Console.Clear();
			Console.WriteLine($"Visitors: {ages.Count}");
			Console.WriteLine($"Total price: {totalPrice.ToString("C")} \n");
		}


		private int RegisterVisitorsNumber()
		{
			Console.Clear();
			string input = string.Empty;

			while (true)
			{
				Console.Write("How many visitors: ");
				input = Console.ReadLine();

				// Validates the input to ensure that it is a positive integer
				if (int.TryParse(input, out int visitors) && visitors > 0)
					return visitors;
				else
					ErrorMessages.DisplayErrorMessage("Invalid input, must be a positive integer higher then 0. Try Again!");
			}
		}

		private int RegisterVisitorAge()
		{
			string input = string.Empty;

			while (true) 
			{ 
				Console.Write("What age is the visitor: ");	
				input = Console.ReadLine();

				// Validates the input to ensure that it is a valid age
				if (int.TryParse(input, out int age) && age > 0 && age < 180)
					return age;
				else
					ErrorMessages.InvalidAgeInput();
			}
		}

		private AgePricing EvaluateSingleVisitorPrice(int age)
		{
			if (age < 5)
				return AgePricing.Free;			// Free for children under 5
			if (age < 20)
				return AgePricing.Youth;        // Youth price for age 5 to 19
			else if (age > 64)
				return AgePricing.Senior;       // Senior price for age 65 to 100
			else if (age > 100)
				return AgePricing.Free;			// Free for seniors over 100
			
			return AgePricing.Standard;			// Standard price for ages 20 to 64
		}
	}
}