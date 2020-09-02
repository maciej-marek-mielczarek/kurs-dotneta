using Doppelganger.App.Services.Concrete;

namespace Doppelganger.App.Services.Abstract
{
    public interface IDamageService
    {
        byte DamageDealtInCombatTurn(int allysId, int turnNumber, ICreatureService creatureService);
    }
}