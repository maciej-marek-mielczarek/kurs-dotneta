using Doppelganger.App.Services.Abstract;

namespace Doppelganger.App.Services.Concrete
{
    public class DamageService: IDamageService
    {
        public byte DamageDealtInCombatTurn(int allysId, int turnNumber, ICreatureService creatureService)
        {
            byte damage = 0;
            if (turnNumber % creatureService.GetCreatureSpeedById(allysId) == 0)
            {
                damage = creatureService.GetCreatureAttackById(allysId);
            }

            return damage;
        }

        public byte DamageTakenInCombatTurn(int oppsId, int turnNumber, ICreatureService creatureService)
        {
            byte damage = 0;
            if (turnNumber % creatureService.GetCreatureSpeedById(oppsId) == 0 &&
                !creatureService.IsCreatureFriendly(oppsId))
            {
                damage = creatureService.GetCreatureAttackById(oppsId);
            }

            return damage;
        }
    }
}