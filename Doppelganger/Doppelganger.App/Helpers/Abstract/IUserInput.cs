namespace Doppelganger.App.Helpers.Abstract
{
    public interface IUserInput
    {
        char GetChar(string possibleChoices);
        int CharDigitToInt(char v);
    }
}