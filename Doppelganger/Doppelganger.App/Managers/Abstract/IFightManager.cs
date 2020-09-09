namespace Doppelganger.App.Managers.Abstract
{
    public interface IFightManager
    {
        bool PickAlly();
        void Initialize();
        int CalculateScore();
        void PickOpp();
        void EndFight();
    }
}