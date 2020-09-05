namespace Doppelganger.App.Services.Abstract
{
    public interface IFightService
    {
        int FightSimulation(int chosenOppId, int allysId, int chosenFightLength, int turnNumber,
            IDamageService damageService, ICreatureService creatureService);
    }
}