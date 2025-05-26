using LexiconExercise2.CinemaPriceHelper;
using LexiconExercise2.InputEchoApp;
using LexiconExercise2.MenuHelpers;
using LexiconExercise2.ThirdWordStringSplitterApp;

namespace LexiconExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO: wrapper class for con in and con out, abstraction
            
			ICinemaPricingHelper cinemaPricingHelper = new CinemaPricingHelper();
			IInputEcho inputEcho = new InputEcho();
            IThirdWordStringSplitter thirdWordStringSplitter = new ThirdWordStringSplitter();

            MainMenu mainMenu = new MainMenu(cinemaPricingHelper, inputEcho, thirdWordStringSplitter);

            mainMenu.DisplayMainMenu();
        }
    }
}
