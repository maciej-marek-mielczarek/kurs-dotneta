using System;

namespace Doppelganger.App.Helpers
{
    public static class HelperMethods
    {
        public static char GetChar(string possibleChoices)
        {//Not "try to get a correct char", rather "try until you get a correct char".
            char choice;
            bool madeChoice;
            do
            {
                madeChoice = char.TryParse(Console.ReadKey().KeyChar.ToString(), out choice);
                Console.Write("\b \b");
            }
            while (!madeChoice || !possibleChoices.Contains(choice));
            return choice;
        }

        public static void ClearLine(int lineLength = 80)
        {
            string enoughSpaces = new string(' ', lineLength);
            Console.Write('\r' + enoughSpaces + '\r');
        }

        public static int CharDigitToInt(char v)
        {
            if (v >= '0' && v <= '9')
            {
                return v - '0';
            }
            else if (v >= 'a' && v <= 'z')
            {
                return v - 'a' + 10;
            }
            else if (v >= 'A' && v <= 'Z')
            {
                return v - 'A' + 10;
            }
            else
            {
                throw new ArgumentException("Expected a Latin character or a number, got: " + v);
            }
        }

        public static string Buttonize(string buttonText, char buttonKey)
        {
            if (buttonText == null)
            {
                throw new ArgumentException("Got null as string buttonText argument. Someone probably forgot to assign it a value. Note that an empty string would've been fine as it would've represented a clear intention to pass no text.");
            }
            if (buttonText.Length == 0)
            {
                return " [(" + buttonKey + ")] ";
            }
            int indexOfKey;
            if (buttonText.Contains(char.ToUpper(buttonKey)))
            {
                indexOfKey = buttonText.IndexOf(char.ToUpper(buttonKey));
            }
            else if(buttonText.Contains(char.ToLower(buttonKey)))
            {
                indexOfKey = buttonText.IndexOf(char.ToLower(buttonKey));
            }
            else
            {
                buttonText += " " + buttonKey;
                indexOfKey = buttonText.Length - 1;
            }
            buttonText = buttonText.Insert(indexOfKey + 1, ")");
            buttonText = buttonText.Insert(indexOfKey, "(");

            return " [" + buttonText + "] ";
        }
    }
}
