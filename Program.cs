namespace LexiconExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {

			ICinemaPricingHelper cinemaPricingHelper = new CinemaPricingHelper();

            Console.WriteLine("Welcome, this is the main menu. \n" +
                "To test the features bellow input its corresponding number!\n");

            bool exitProgram = false;

            string input = string.Empty;

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("0: Exit the program.");
                Console.WriteLine("1: Cinema Pricing.");
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
					default:
						ErrorMessages.InvalidIntInput();
                        break;
				}
            }
            while (!exitProgram);
        }
    }
}
