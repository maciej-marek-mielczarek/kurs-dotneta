using System;
using Doppelganger.App.Helpers;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Managers.Concrete
{
    public class FightManager : IFightManager
    {
        private readonly ITextService _textService;
        private readonly IDamageService _damageService;
        private ICreatureService CreatureService { get; }

        public FightManager(ITextService textService, ICreatureService creatureService)
        {
            _textService = textService;
            CreatureService = creatureService;
            _damageService = new DamageService();
        }

        public void FightMenu()
        {
            Console.WriteLine(_textService.WelcomeToFight());

            Console.Write(_textService.Id().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + i).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.Attack().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(
                    ("|" + CreatureService.GetCreatureAttackById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.Speed().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(
                    ("|" + CreatureService.GetCreatureSpeedById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.MaxHP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(
                    ("|" + CreatureService.GetCreatureMaxHPById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            PickAllyMenu();
        }

        private void PickAllyMenu()
        {
            Console.Write(_textService.PickAlly());
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
            if (choice != 'x')
            {
                int chosenAlly = HelperMethods.CharDigitToInt(choice);
                CreatureService.MakeGivenCreatureFriendly(chosenAlly);
                PickOppMenu();
            }
            else
            {
                HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
                //now return control upwards
            }
        }

        private void PickOppMenu()
        {
            HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
            Console.Write(_textService.FightWhom());
            string possibleChoices = "x" + ValidNewOppNumbers();

            char choice = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
            while (choice != 'x')
            {
                int chosenOppId = HelperMethods.CharDigitToInt(choice);
                bool continueGame = FightSubMenu(chosenOppId, 0);
                if (!continueGame)
                {
                    break;
                }

                HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
                Console.Write(_textService.FightWhom());
                possibleChoices = "x" + ValidNewOppNumbers();
                choice = HelperMethods.GetChar(possibleChoices);
                HelperMethods.ClearLine();
            }

            HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
            //now return control upwards
        }

        private string ValidNewOppNumbers()
        {
            string validNewOppNumbers = "";
            for (int id = 0; id < DisplaySettings.NumberOfOpps; id++)
            {
                if (!CreatureService.IsCreatureDead(id))
                {
                    validNewOppNumbers += id;
                }
            }

            return validNewOppNumbers;
        }

        private bool FightSubMenu(int chosenOppId, int turnNumber)
        {
            HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
            Console.Write(_textService.StayHowLong());
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
            bool gameIsOver = false;
            while (choice != '0' && choice != 'x')
            {
                int chosenFightLength = HelperMethods.CharDigitToInt(choice);
                int allysId = CreatureService.GetAllysId();
                turnNumber = FightSimulation(chosenOppId, allysId, chosenFightLength, turnNumber);
                HelperMethods.ClearLine();
                //Player dies - game over.
                bool playerIsDead = CreatureService.IsCreatureDead(allysId);
                //No hostile creatures left to hit - also game over.
                bool allOppsAreDead = CreatureService.CountDeadOpps() + 1 == DisplaySettings.NumberOfOpps;
                gameIsOver = playerIsDead || allOppsAreDead;
                if (gameIsOver)
                {
                    break;
                }

                bool oppIsDead = CreatureService.IsCreatureDead(chosenOppId);
                if (oppIsDead)
                {
                    CreatureService.SwitchBodiesWith(chosenOppId);
                    break;
                }

                HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
                Console.Write(_textService.StayHowLong());
                choice = HelperMethods.GetChar(possibleChoices);
                HelperMethods.ClearLine();
            }

            return !(choice == 'x' || gameIsOver);
        }

        private int FightSimulation(int chosenOppId, int allysId, int chosenFightLength, int turnNumber)
        {
            bool playerDied = false, oppDied = false;
            int turnsLeft = chosenFightLength;

            while (0 < turnsLeft && !playerDied && !oppDied)
            {
                //Next turn starts.
                ++turnNumber;
                --turnsLeft;
                //Play out this turn of fight.
                FightTurnSimulation(chosenOppId, turnNumber, allysId);
                //See if anyone died.
                playerDied = CreatureService.IsCreatureDead(allysId);
                oppDied = CreatureService.IsCreatureDead(chosenOppId);
            }

            return turnNumber;
        }

        private void FightTurnSimulation(int chosenOppId, int turnNumber, int allysId)
        {
            byte playersStrike = _damageService.DamageDealtInCombatTurn(allysId, turnNumber, CreatureService);
            byte oppsStrike = _damageService.DamageTakenInCombatTurn(chosenOppId, turnNumber, CreatureService);

            if (playersStrike > 0)
            {
                CreatureService.RegisterHit(playersStrike, chosenOppId);
            }

            if (oppsStrike > 0)
            {
                CreatureService.RegisterHit(oppsStrike, allysId);
            }
        }

        public void Initialize()
        {
            CreatureService.GenerateNewCrts();
        }

        public int CalculateScore()
        {
            int score = 0;
            for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; ++creatureId)
            {
                int creatureScore = (int) Math.Floor(10m - 10m * CreatureService.GetCreatureCurrentHPById(creatureId) /
                    CreatureService.GetCreatureMaxHPById(creatureId));
                score += creatureScore;
            }

            return score;
        }
    }
}