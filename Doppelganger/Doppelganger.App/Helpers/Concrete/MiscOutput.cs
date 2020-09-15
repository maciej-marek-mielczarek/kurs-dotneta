using System;

namespace Doppelganger.App.Helpers.Concrete
{
    public static class MiscOutput
    {
        public static void ClearLine(int lineLength = 80)
        {
            string enoughSpaces = new string(' ', lineLength);
            Console.Write('\r' + enoughSpaces + '\r');
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
