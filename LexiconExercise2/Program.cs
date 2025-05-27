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
			// Classes used for reading and writing text to and from console.
			IReadAndWriteToConsole readAndWriteToConsole = new ReadAndWriteToConsole();

			// Classes used in the display text wrapper
			DisplayHeaders displayHeaders = new DisplayHeaders(readAndWriteToConsole);
			DisplayMenu displayMenu = new DisplayMenu(readAndWriteToConsole);
			DisplayErrorMessages displayErrorMessages = new DisplayErrorMessages(readAndWriteToConsole);

			DisplayTextWrapper displayTextWrapper = new DisplayTextWrapper(displayMenu, displayHeaders, displayErrorMessages);

			// The class used to validate text input.
			IValidateTextInput validateTextInput = new ValidateTextInput(readAndWriteToConsole, displayTextWrapper);
            
            // The mini applications are instantiated here.
            ICinemaPricingHelper cinemaPricingHelper = new CinemaPricingHelper(
                readAndWriteToConsole, 
                displayTextWrapper, 
                validateTextInput
            );
			IInputEcho inputEcho = new InputEcho(
                readAndWriteToConsole, 
                displayTextWrapper, 
                validateTextInput
            );
            IThirdWordStringSplitter thirdWordStringSplitter = new ThirdWordStringSplitter(
                readAndWriteToConsole, 
                displayTextWrapper,
                validateTextInput
            );
            

           
		    MainMenu mainMenu = new MainMenu(
                cinemaPricingHelper, 
                inputEcho, 
                thirdWordStringSplitter,
				readAndWriteToConsole,
                displayTextWrapper,
                validateTextInput
            );

            // Starts the main menu of the application
            mainMenu.DisplayMainMenu();
        }
    }
}
