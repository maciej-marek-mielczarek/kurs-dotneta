using System;
using Doppelganger.App.Helpers;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Services.Abstract;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Managers.Concrete
{
    public class FightManager : IFightManager
    {
        private readonly ITextService _textService;
        private ICreatureService CreatureService { get; }

        public FightManager(ITextService textService, ICreatureService creatureService)
        {
            _textService = textService;
            CreatureService = creatureService;
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
                Console.Write(("|" + CreatureService.GetCreatureAttackById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.Speed().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + CreatureService.GetCreatureSpeedById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.MaxHP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + CreatureService.GetCreatureMaxHPById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
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
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
            if (choice != 'x')
            {
                int chosenOppId = HelperMethods.CharDigitToInt(choice);
                if (CreatureService.IsCreatureDead(chosenOppId))
                {
                    PickOppMenu();
                }
                else
                {
                    FightSubMenu(chosenOppId, 0);
                }
            }
            else
            {
                HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
                //now return control upwards
            }
        }

        private void FightSubMenu(int chosenOppId, int turnNumber)
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
            if (choice == '0')
            {
                PickOppMenu();
            }
            else if (choice != 'x')
            {
                int chosenFightLength = HelperMethods.CharDigitToInt(choice);
                int allysId = CreatureService.GetAllysId();
                turnNumber = FightSimulation(chosenOppId, allysId, chosenFightLength, turnNumber);
                bool playerDied = CreatureService.IsCreatureDead(allysId);
                bool oppDied = CreatureService.IsCreatureDead(chosenOppId);
                byte deadOppsCount = CreatureService.CountDeadOpps();
                HelperMethods.ClearLine();
                if (playerDied)
                {
                    HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
                    //now return control upwards to end the game
                }
                else if (oppDied)
                {
                    if (deadOppsCount + 1 == DisplaySettings.NumberOfOpps)
                    {
                        HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
                        //now return control upwards to end the game
                    }
                    else
                    {
                        CreatureService.SwitchBodiesWith(chosenOppId);
                        PickOppMenu();
                    }
                }
                else
                {
                    FightSubMenu(chosenOppId, turnNumber);
                }
            }
            else
            {
                HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
                //now return control upwards
            }
        }

        private byte DamageDealtInCombatTurn(int allysId, int turnNumber)
        {
            byte damage = 0;
            if (turnNumber % CreatureService.GetCreatureSpeedById(allysId) == 0)
            {
                damage = CreatureService.GetCreatureAttackById(allysId);
            }
            return damage;
        }

        private byte DamageTakenInCombatTurn(int chosenOppId, int turnNumber)
        {
            byte damage = 0;
            if (turnNumber % CreatureService.GetCreatureSpeedById(chosenOppId) == 0 &&
                !CreatureService.IsCreatureFriendly(chosenOppId))
            {
                damage = CreatureService.GetCreatureAttackById(chosenOppId);
            }
            return damage;
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
            byte playersStrike = DamageDealtInCombatTurn(allysId, turnNumber);
            byte oppsStrike = DamageTakenInCombatTurn(chosenOppId, turnNumber);

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
            for(int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; ++creatureId)
            {
                int creatureScore = (int) Math.Floor(10m - 10m * CreatureService.GetCreatureCurrentHPById(creatureId) /
                    CreatureService.GetCreatureMaxHPById(creatureId));
                score += creatureScore;
            }
            return score;
        }
    }
}