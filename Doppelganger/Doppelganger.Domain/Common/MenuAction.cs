namespace Doppelganger.Domain.Common
{
    public class MenuAction
    {
        public char KeyToChoose { get; }
        public string ActionName { get; }
        public string MenuName { get; }
        public MenuAction(char keyToChoose, string actionName, string menuName)
        {
            KeyToChoose = keyToChoose;
            ActionName = actionName;
            MenuName = menuName;
        }
    }
}
