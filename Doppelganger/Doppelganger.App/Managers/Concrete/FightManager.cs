using System;
using System.Collections.Generic;
using Doppelganger.App.Helpers;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Services.Abstract.Abstract;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Managers.Concrete
{
    public class FightManager : IFightManager
    {
        private readonly ITextService _textService;
        public ICreatureService CreatureService { get; }

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

            List<Creature> creatures = CreatureService.GetCrts();
            Console.Write(_textService.Attack().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].Attack).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.Speed().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].Speed).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.MaxHP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].MaxHP).PadRight(DisplaySettings.OtherColumnsWidth));
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
            List<Creature> creatures = CreatureService.GetCrts();
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
                if (creatures[chosenOppId].CurrentHP == 0)
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
                List<Creature> creatures = CreatureService.GetCrts();
                ++combatTurn;
                byte playersStrike = 0, oppsStrike = 0;
                for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; ++creatureId)
                {
                    if (creatures[creatureId] is Ally)
                    {
                        if (combatTurn % creatures[creatureId].Speed == 0)
                        {
                            playersStrike = creatures[creatureId].Attack;
                        }
                    }
                    else if (creatureId == chosenOppId && combatTurn % creatures[creatureId].Speed == 0)
                    {
                        oppsStrike = creatures[creatureId].Attack;
                    }
                }
                
                bool playerDied = false, oppDied = false;
                byte deadOppsCount = 0;
                for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; ++creatureId)
                {
                    if (creatures[creatureId] is Ally)
                    {
                        CreatureService.RegisterHit(oppsStrike, creatureId);
                        creatures = CreatureService.GetCrts();
                        if (creatures[creatureId].CurrentHP <= 0)
                        {
                            playerDied = true;
                        }
                    }
                    else if (creatures[creatureId].CurrentHP == 0)
                    {
                        deadOppsCount++;
                    }

                    if (creatureId == chosenOppId)
                    {
                        CreatureService.RegisterHit(playersStrike, creatureId);
                        creatures = CreatureService.GetCrts();
                        if (creatures[creatureId].CurrentHP <= 0)
                        {
                            deadOppsCount++;
                            oppDied = true;
                            if (creatures[creatureId] is Ally)
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
            foreach (var creature in CreatureService.GetCrts())
            {
                int creatureScore = 0;
                if (creature is Ally ally)
                {
                    creatureScore = (int)Math.Floor(10m - 10m * ally.CurrentHP / ally.MaxHP);
                }
                else if (creature is Opponent opponent)
                {
                    creatureScore = (int)Math.Floor(10m - 10m * opponent.CurrentHP / opponent.MaxHP);
                }
                score += creatureScore;
            }
            return score;
        }
    }
}