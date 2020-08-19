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
        public string GetInfoOn();
        public string AttackInfo();
        public string HPInfo();
        public string SpeedInfo();
        public string AboutAlly();
        public string AboutOpponent();
        public string Fight();
        public string WelcomeToFight();
        public string YourScoreIs();
        public string FightWhom();
        public string StayHowLong();
    }
}