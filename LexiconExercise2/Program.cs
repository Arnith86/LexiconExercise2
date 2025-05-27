using LexiconExercise2.CinemaPriceHelper;
using LexiconExercise2.InputEchoApp;
using LexiconExercise2.MenuHelpers;
using LexiconExercise2.ThirdWordStringSplitterApp;
using LexiconExercise2.Util;
using LexiconExercise2.Util.DisplayTextClasses;

namespace LexiconExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// Class used for reading and writing to and from console.
			IReadAndWriteToConsole readAndWriteToConsole = new ReadAndWriteToConsole();

			// Classes used in the display text wrapper
			DisplayHeaders displayHeaders = new DisplayHeaders(readAndWriteToConsole);
			DisplayMenu displayMenu = new DisplayMenu(readAndWriteToConsole);
			DisplayErrorMessages displayErrorMessages = new DisplayErrorMessages(readAndWriteToConsole);

			DisplayTextWrapper displayTextWrapper = new DisplayTextWrapper(displayMenu, displayHeaders, displayErrorMessages);

            // The mini applications are instantiated here.
            ICinemaPricingHelper cinemaPricingHelper = new CinemaPricingHelper(readAndWriteToConsole, displayTextWrapper);
			IInputEcho inputEcho = new InputEcho(readAndWriteToConsole, displayTextWrapper);
            IThirdWordStringSplitter thirdWordStringSplitter = new ThirdWordStringSplitter(readAndWriteToConsole, displayTextWrapper);
            
           
		    MainMenu mainMenu = new MainMenu(
                cinemaPricingHelper, 
                inputEcho, 
                thirdWordStringSplitter,
				readAndWriteToConsole,
                displayTextWrapper
            );

            // Starts the main menu of the application
            mainMenu.DisplayMainMenu();
        }
    }
}
