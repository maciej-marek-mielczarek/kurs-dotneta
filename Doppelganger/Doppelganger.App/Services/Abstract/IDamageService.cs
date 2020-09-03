namespace Doppelganger.App.Services.Abstract
{
    public interface IDamageService
    {
        byte DamageDealtInCombatTurn(int allysId, int turnNumber, ICreatureService creatureService);
        byte DamageTakenInCombatTurn(int oppsId, int turnNumber, ICreatureService creatureService);
    }
}