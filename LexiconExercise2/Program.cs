using LexiconExercise2.CinemaPriceHelper;
using LexiconExercise2.InputEchoApp;
using LexiconExercise2.MenuHelpers;
using LexiconExercise2.ThirdWordStringSplitterApp;
using LexiconExercise2.Util;

namespace LexiconExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICinemaPricingHelper cinemaPricingHelper = new CinemaPricingHelper();
			IInputEcho inputEcho = new InputEcho();
            IThirdWordStringSplitter thirdWordStringSplitter = new ThirdWordStringSplitter();
            IReadAndWriteToConsole readAndWriteToConsole = new ReadAndWriteToConsole();

		    MainMenu mainMenu = new MainMenu(
                cinemaPricingHelper, 
                inputEcho, 
                thirdWordStringSplitter,
				readAndWriteToConsole
            );

            mainMenu.DisplayMainMenu();
        }
    }
}
