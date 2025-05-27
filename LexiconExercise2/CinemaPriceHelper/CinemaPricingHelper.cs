using LexiconExercise2.MenuHelpers;
using LexiconExercise2.Util;
using LexiconExercise2.Util.DisplayTextClasses;

namespace LexiconExercise2.CinemaPriceHelper
{
	internal class CinemaPricingHelper : ICinemaPricingHelper
	{
		private readonly IReadAndWriteToConsole _readAndWriteToConsole;
		private readonly DisplayTextWrapper _displayTextWrapper;
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

		public CinemaPricingHelper(IReadAndWriteToConsole readAndWriteToConsole, DisplayTextWrapper displayTextWrapper)
		{
			_readAndWriteToConsole = readAndWriteToConsole;
			_displayTextWrapper = displayTextWrapper;
		}
		
		///<inheritdoc/>
		public void CinemaPricingMenu() 
		{
			bool returnToMainMenu = false;

			Console.Clear();
			 
			_displayTextWrapper.DisplayHeaders.DisplayHeaderText(
				"Cinema Pricing! \nHere to help you find the correct pricing for individuals or groups!");
			
			do
			{
				_displayTextWrapper.DisplayMenu.DisplayMenuText(
					"1: Single visitor.\n" +
					"2: Group of visitors.\n" +
					"0: Return to main menu.\n"
				);
				

				string input = _readAndWriteToConsole.ReadInput();

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
						_displayTextWrapper.DisplayErrorMessages.InvalidIntInput(); 
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


		//TODO: dubblecheck that displayPricing still works
		///<inheritdoc/>
		public void DisplayPricing()
		{
			int age = RegisterVisitorAge();
			var pricing = EvaluateSingleVisitorPrice(age);

			string printOut = string.Empty;
			if (pricing.Equals(AgePricing.Youth))
				printOut = string.Format("Youth price: {0}\n", IntToCurranty((int)pricing));
			else if (pricing.Equals(AgePricing.Senior))
				printOut = string.Format("Senior price: {0}\n", IntToCurranty((int)pricing));
			else if (pricing.Equals(AgePricing.Standard))
				printOut = string.Format("Standard price: {0}\n", IntToCurranty((int)pricing));
			else
				printOut = string.Format("Free: {0}\n", IntToCurranty((int)pricing));
			
			_readAndWriteToConsole.Print(printOut);
		}

		///<inheritdoc/>
		public void DisplayPricing(int visitor)
		{
			List<int> ages = new List<int>();

			// Registers the ages of the visitors based on user input
			for (int i = 0; i < visitor; i++)
			{
				_readAndWriteToConsole.Print(
					string.Format("Visitor {0} ", i+1)
				);
				ages.Add(RegisterVisitorAge());
			}

			int totalPrice = 0;

			// Calculates the total price based on the ages of the visitors
			foreach (var age in ages)
				totalPrice += (int)EvaluateSingleVisitorPrice(age);
			
			Console.Clear();
			_readAndWriteToConsole.PrintLine($"Visitors: {ages.Count}");
			_readAndWriteToConsole.PrintLine($"Total price: {totalPrice.ToString("C")} \n");
		}


		private int RegisterVisitorsNumber()
		{
			Console.Clear();
			string input = string.Empty;

			while (true)
			{
				_readAndWriteToConsole.Print("How many visitors: ");
				input = _readAndWriteToConsole.ReadInput();

				// Validates the input to ensure that it is a positive integer
				if (int.TryParse(input, out int visitors) && visitors > 0)
					return visitors;
				else
					_displayTextWrapper.DisplayErrorMessages.DisplayErrorMessage(
						"Invalid input, must be a positive integer higher then 0. Try Again!"
					);
			}
		}

		private int RegisterVisitorAge()
		{
			string input = string.Empty;

			while (true) 
			{
				_readAndWriteToConsole.Print("What age is the visitor: ");	
				input = _readAndWriteToConsole.ReadInput();

				// Validates the input to ensure that it is a valid age
				if (int.TryParse(input, out int age) && age >= 0 && age < 180)
					return age;
				else
					_displayTextWrapper.DisplayErrorMessages.InvalidAgeInput();
			}
		}

		private AgePricing EvaluateSingleVisitorPrice(int age)
		{
			if (age < 5)
				return AgePricing.Free;			// Free for children under 5
			else if (age < 20)
				return AgePricing.Youth;        // Youth price for age 5 to 19
			else if (age > 64 && age <= 100)
				return AgePricing.Senior;       // Senior price for age 65 to 100
			else if (age > 100)
				return AgePricing.Free;			// Free for seniors over 100
			
			return AgePricing.Standard;			// Standard price for ages 20 to 64
		}
	}
}