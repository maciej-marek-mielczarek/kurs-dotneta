namespace Doppelganger.App.Services.Abstract
{
    public interface ICreatureService
    {
        bool IsCreatureFriendly(int creatureId);
        byte GetCreatureAttackById(int creatureId);
        byte GetCreatureSpeedById(int creatureId);
        byte GetCreatureMaxHPById(int creatureId);
        byte GetCreatureCurrentHPById(int creatureId);
        bool IsCreatureDead(int creatureId);
        void GenerateNewCrts();
        void MakeGivenCreatureFriendly(int chosenAlly);
        void RegisterHit(byte damage, int creatureId);
        void SwitchBodiesWith(int chosenOppId);
        int GetAllysId();
        byte CountDeadOpps();
        string ValidNewOppNumbers();
    }
}