using Doppelganger.App.Services.Abstract;

namespace Doppelganger.App.Services.Concrete
{
    public class FightService: IFightService
    {
        private void CalculateNextTurn(int chosenOppId, int turnNumber, int allysId, IDamageService damageService,
            ICreatureService creatureService)
        {
            byte playersStrike = damageService.DamageDealtInCombatTurn(allysId, turnNumber, creatureService);
            byte oppsStrike = damageService.DamageTakenInCombatTurn(chosenOppId, turnNumber, creatureService);

            if (playersStrike > 0)
            {
                creatureService.RegisterHit(playersStrike, chosenOppId);
            }

            if (oppsStrike > 0)
            {
                creatureService.RegisterHit(oppsStrike, allysId);
            }
        }

        public int FightSimulation(int chosenOppId, int allysId, int chosenFightLength, int turnNumber, IDamageService damageService,
            ICreatureService creatureService)
        {
            bool playerDied = false, oppDied = false;
            int turnsLeft = chosenFightLength;

            while (0 < turnsLeft && !playerDied && !oppDied)
            {
                //Next turn starts.
                ++turnNumber;
                --turnsLeft;
                //Play out this turn of fight.
                CalculateNextTurn(chosenOppId, turnNumber, allysId, damageService, creatureService);
                //See if anyone died.
                playerDied = creatureService.IsCreatureDead(allysId);
                oppDied = creatureService.IsCreatureDead(chosenOppId);
            }

            return turnNumber;
        }
    }
}