namespace Doppelganger.App.Services.Abstract
{
    public interface ITextService
    {
        string Welcome();
        string NewGame();
        string Instructions();
        string Exit();
        string Stats();
        string Actions();
        string Back();
        string GetInfoOn();
        string AttackInfo();
        string HPInfo();
        string SpeedInfo();
        string AboutAlly();
        string AboutOpponent();
        string Fight();
        string WelcomeToFight();
        string YourScoreIs();
        string FightWhom();
        string StayHowLong();
        string FightInfo();
        string PickOpponentInfo();
        string PickAllyInfo();
        string Id();
        string Attack();
        string Speed();
        string HP();
        string MaxHP();
        string PickAlly();
    }
}