namespace Doppelganger.App.Abstract
{
    public interface ITextService
    {
        public string Welcome();
        public string NewGame();
        public string Instructions();
        public string Exit();
        public string Stats();
        public string Actions();
        public string Back();
    }
}