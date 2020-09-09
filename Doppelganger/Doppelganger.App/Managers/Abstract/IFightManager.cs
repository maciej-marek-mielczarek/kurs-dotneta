namespace Doppelganger.App.Managers.Abstract
{
    public interface IFightManager
    {
        bool PickAlly();
        void Initialize();
        int CalculateScore();
        int PickOpp();
        void EndFight();
        bool FightSubMenu(int chosenOppId, int turnNumber);
    }
}