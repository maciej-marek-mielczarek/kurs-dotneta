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

        private void FightSubMenu(int chosenOppId, int combatTurn)
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
                FightSimulation(chosenOppId, chosenFightLength, combatTurn);
            }
            else
            {
                HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
                //now return control upwards
            }
        }

        private void FightSimulation(int chosenOppId, int chosenFightLength, int combatTurn)
        {
            if (chosenFightLength == 0)
            {
                HelperMethods.ClearLine();
                FightSubMenu(chosenOppId, combatTurn);
            }
            else
            {
                ++combatTurn;
                byte playersStrike = 0, oppsStrike = 0;
                for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; ++creatureId)
                {
                    if (CreatureService.IsCreatureFriendly(creatureId))
                    {
                        if (combatTurn % CreatureService.GetCreatureSpeedById(creatureId) == 0)
                        {
                            playersStrike = CreatureService.GetCreatureAttackById(creatureId);
                        }
                    }
                    else if (creatureId == chosenOppId && combatTurn % CreatureService.GetCreatureSpeedById(creatureId) == 0)
                    {
                        oppsStrike = CreatureService.GetCreatureAttackById(creatureId);
                    }
                }
                
                bool playerDied = false, oppDied = false;
                byte deadOppsCount = 0;
                for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; ++creatureId)
                {
                    if (CreatureService.IsCreatureFriendly(creatureId))
                    {
                        CreatureService.RegisterHit(oppsStrike, creatureId);
                        if (CreatureService.IsCreatureDead(creatureId))
                        {
                            playerDied = true;
                        }
                    }
                    else if (CreatureService.IsCreatureDead(creatureId))
                    {
                        deadOppsCount++;
                    }

                    if (creatureId == chosenOppId)
                    {
                        CreatureService.RegisterHit(playersStrike, creatureId);
                        if (CreatureService.IsCreatureDead(creatureId))
                        {
                            deadOppsCount++;
                            oppDied = true;
                            if (CreatureService.IsCreatureFriendly(creatureId))
                            {
                                playerDied = true;
                            }
                        }
                    }
                }

                HelperMethods.ClearLine();
                if (playerDied)
                {
                    HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
                    //now return control upwards
                }
                else if (oppDied)
                {
                    if (deadOppsCount + 1 == DisplaySettings.NumberOfOpps)
                    {
                        HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
                        //now return control upwards
                    }
                    else
                    {
                        CreatureService.SwitchBodiesWith(chosenOppId);
                        PickOppMenu();
                    }
                }
                else
                {
                    if (chosenFightLength == 1)
                    {
                        FightSubMenu(chosenOppId, combatTurn);
                    }
                    else
                    {
                        chosenFightLength--;
                        FightSimulation(chosenOppId, chosenFightLength, combatTurn);
                    }
                }
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