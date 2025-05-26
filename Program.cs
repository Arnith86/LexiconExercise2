namespace LexiconExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {

			ICinemaPricingHelper cinemaPricingHelper = new CinemaPricingHelper();
            InputEcho inputEcho = new InputEcho();


            DisplayHeaders.DisplayHeaderText(
                "Welcome, this is the main menu. \n" +
                "To test the features bellow input its corresponding number!\n"
            );

            bool exitProgram = false;

            string input = string.Empty;

            do
            {
                //TODO: create menu display class.
                Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("0: Exit the program.");
                Console.WriteLine("1: Cinema Pricing.");
                Console.WriteLine("2: Input Echo. Writes back input 10 times.");
                Console.ResetColor();

                input = Console.ReadLine();

				switch (input)
				{
                    case "0": 
                        exitProgram = true;
                        break;
                    case "1":
                        cinemaPricingHelper.CinemaPricingMenu();
                        break;
                    case "2":

					default:
						ErrorMessages.InvalidIntInput();
                        break;
				}
            }
            while (!exitProgram);
        }
    }
}
