using LexiconExercise2.MenuHelpers;
using LexiconExercise2.Util;
using LexiconExercise2.Util.DisplayTextClasses;

namespace LexiconExercise2.CinemaPriceHelper
{
	internal class CinemaPricingHelper : ICinemaPricingHelper
	{
		private readonly IReadAndWriteToConsole _readAndWriteToConsole;
		private readonly DisplayTextWrapper _displayTextWrapper;
		private readonly IValidateTextInput _validateTextInput;
	
		///// <summary>
		///// Enum representing the different age pricing categories for cinema tickets.
		///// </summary>
		//private enum AgePricing
		//{
		//	Youth = 80,
		//	Standard = 120,
		//	Senior = 90,
		//	Free = 0
		//}

		public CinemaPricingHelper(
			IReadAndWriteToConsole readAndWriteToConsole, 
			DisplayTextWrapper displayTextWrapper,
			IValidateTextInput validateTextInput)
		{
			_readAndWriteToConsole = readAndWriteToConsole;
			_displayTextWrapper = displayTextWrapper;
			_validateTextInput = validateTextInput;
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
				string input = _validateTextInput.ValidateMenuInput(
					"1: Single visitor.\n" +
					"2: Group of visitors.\n" +
					"0: Return to main menu.\n",
					rangeMin: 0,
					rangeMax: 2
				);

				switch (input)
				{
					case CinemaPricingMenuHelpers.RETURN_TO_MAIN_MENU:
						return;
					case CinemaPricingMenuHelpers.SINGLE_VISITOR:
						DisplayPricing();
						break;
					case CinemaPricingMenuHelpers.GROUP_OF_VISITORS:
						int nrOfVisitors = RegisterVisitorsNumber();
						DisplayPricing(nrOfVisitors);
						break;
					default:
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
				uint visitors = _validateTextInput.ValidateTextIntInput("How many visitors: ");
			
				// Performs extra validation to ensure that the input is greater then 0.
				if (visitors > 0)
					return (int)visitors;
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
				// Registers and validates input. Checks parse and negative values
				uint age = _validateTextInput.ValidateTextIntInput("What age is the visitor: ");

				// Performs the final validation. Checks if age is within a reasonable range.
				if (IsReasonableAge(age))
					return (int)age;
				else
					_displayTextWrapper.DisplayErrorMessages.InvalidAgeInput();
			}
		}

		private bool IsReasonableAge(uint age)
		{
			return age >= 0 && age < 150;
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