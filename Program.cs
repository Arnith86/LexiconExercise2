namespace LexiconExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, this is the main menu. \n" +
                "To test the features bellow input its corresponding number!\n");

            bool exitProgram = false;

            string input = string.Empty;

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("0: Exit the program.");
                Console.ResetColor();

                input = Console.ReadLine();

				switch (input)
				{
                    case "0": exitProgram = true;
                        break;

					default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You supplied an invalid input, try again!");
                        Console.ResetColor();
                        break;
				}
            }
            while (!exitProgram);
        }
    }
}
