using LexiconExercise2.MenuHelpers;

namespace LexiconExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO: wrapper class for con in and con out, abstraction
            //TODO: move code from program to a "main" class

			ICinemaPricingHelper cinemaPricingHelper = new CinemaPricingHelper();
            IInputEcho inputEcho = new InputEcho();
            IThirdWordStringSplitter thirdWordStringSplitter = new ThirdWordStringSplitter();

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
                Console.WriteLine("2: Input Echo. Writes back input multiple times.");
                Console.WriteLine("3: String Splitter - Which is the third word?");
                Console.ResetColor();

                input = Console.ReadLine();

				switch (input)
				{
                    case MainManuHelpers.EXIT: 
                        exitProgram = true;
                        break;
                    case MainManuHelpers.CINEMA_PRICING:
                        cinemaPricingHelper.CinemaPricingMenu();
                        break;
                    case MainManuHelpers.INPUT_ECHO:
                        inputEcho.InputEchoMenu();
                        break;
                    case MainManuHelpers.THIRD_WORD_STRING_SPLITTER:
                        thirdWordStringSplitter.ThirdWordStringSplitterMenu();
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
