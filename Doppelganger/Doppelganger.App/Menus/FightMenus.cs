using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Menus
{
    public static class FightMenus
    {
        public static void FightMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.WriteLine(textService.WelcomeToFight());

            Console.Write(textService.Id().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + i).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(textService.Attack().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].Attack).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(textService.Speed().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].Speed).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(textService.MaxHP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].MaxHP).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            PickAllyMenu(menuActionService, textService, creatures);
        }

        private static void PickAllyMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.PickAlly());
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            if (choice != 'x')
            {
                int chosenAlly = Helpers.Helpers.CharDigitToInt(choice);
                for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
                {
                    if (i == chosenAlly)
                    {
                        creatures[i] = new Ally(creatures[i]);
                    }
                    else
                    {
                        creatures[i] = new Opponent(creatures[i]);
                    }
                }

                PickOppMenu(menuActionService, textService, creatures);
            }
            else
            {
                BasicMenus.EndGameMenu(menuActionService, textService, creatures);
            }
        }

        private static void PickOppMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.HP().PadRight(DisplaySettings.FirstColumnWidth));
            foreach (var creature in creatures)
            {
                Console.Write(
                    ("|" + creature.CurrentHP + (creature is Ally ? "*" : "")).PadRight(DisplaySettings
                        .OtherColumnsWidth));
            }

            Console.Write(textService.FightWhom());
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.Helpers.GetChar(possibleChoices);
            if (choice != 'x')
            {
                Helpers.Helpers.ClearLine();
                int chosenOppId = Helpers.Helpers.CharDigitToInt(choice);
                if (creatures[chosenOppId].CurrentHP == 0)
                {
                    PickOppMenu(menuActionService, textService, creatures);
                }
                else
                {
                    FightSubMenu(menuActionService, chosenOppId, 0, textService, creatures);
                }
            }
            else
            {
                Console.WriteLine();
                BasicMenus.EndGameMenu(menuActionService, textService, creatures);
            }
        }

        private static void FightSubMenu(IMenuActionService menuActionService, int chosenOppId, int combatTurn,
            ITextService textService, List<Creature> creatures)
        {
            Console.Write(textService.HP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; ++i)
            {
                Console.Write(("|"
                               + creatures[i].CurrentHP
                               + (creatures[i] is Ally ? "*" : "")
                               + (i == chosenOppId ? "x" : ""))
                    .PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.Write(textService.StayHowLong());
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.Helpers.GetChar(possibleChoices);
            if (choice == 'x')
            {
                Console.WriteLine();
                BasicMenus.EndGameMenu(menuActionService, textService, creatures);
            }
            else if (choice == '0')
            {
                Helpers.Helpers.ClearLine();
                PickOppMenu(menuActionService, textService, creatures);
            }
            else
            {
                int chosenFightLength = Helpers.Helpers.CharDigitToInt(choice);
                FightSimulation(menuActionService, chosenOppId, chosenFightLength, combatTurn, textService, creatures);
            }
        }

        private static void FightSimulation(IMenuActionService menuActionService, int chosenOppId,
            int chosenFightLength, int combatTurn, ITextService textService, List<Creature> creatures)
        {
            if (chosenFightLength == 0)
            {
                Helpers.Helpers.ClearLine();
                FightSubMenu(menuActionService, chosenOppId, combatTurn, textService, creatures);
            }
            else
            {
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
                        var playersHP = creatures[creatureId].CurrentHP;
                        if (playersHP <= oppsStrike)
                        {
                            creatures[creatureId].CurrentHP = 0;
                            playerDied = true;
                        }
                        else
                        {
                            creatures[creatureId].CurrentHP -= oppsStrike;
                        }
                    }
                    else if (creatures[creatureId].CurrentHP == 0)
                    {
                        deadOppsCount++;
                    }

                    if (creatureId == chosenOppId)
                    {
                        var oppsHP = creatures[creatureId].CurrentHP;
                        if (oppsHP <= playersStrike)
                        {
                            creatures[creatureId].CurrentHP = 0;
                            deadOppsCount++;
                            oppDied = true;
                            if (creatures[creatureId] is Ally)
                            {
                                playerDied = true;
                            }
                        }
                        else
                        {
                            creatures[creatureId].CurrentHP -= playersStrike;
                        }
                    }
                }

                if (playerDied)
                {
                    Console.WriteLine();
                    BasicMenus.EndGameMenu(menuActionService, textService, creatures);
                }
                else if (oppDied)
                {
                    if (deadOppsCount + 1 == DisplaySettings.NumberOfOpps)
                    {
                        Console.WriteLine();
                        BasicMenus.EndGameMenu(menuActionService, textService, creatures);
                    }
                    else
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        float previousAllysHPPercent = creatures.Find(cr => cr is Ally).CurrentHP
                                                       // ReSharper disable once PossibleNullReferenceException
                                                       / ((float) (creatures.Find(cr => cr is Ally).MaxHP));
                        bool leftOldAlly = false, assumedNewShape = false;
                        for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; creatureId++)
                        {
                            if (!leftOldAlly && creatures[creatureId] is Ally)
                            {
                                Opponent oldAlly = (Ally) creatures[creatureId];
                                creatures[creatureId] = oldAlly;
                                leftOldAlly = true;
                            }

                            if (!assumedNewShape && creatureId == chosenOppId)
                            {
                                Ally newAlly = (Opponent) creatures[creatureId];
                                newAlly.CurrentHP = (byte) Math.Ceiling(newAlly.MaxHP * previousAllysHPPercent);
                                creatures[creatureId] = newAlly;
                                assumedNewShape = true;
                            }

                            if (assumedNewShape && leftOldAlly)
                            {
                                break;
                            }
                        }

                        Helpers.Helpers.ClearLine();
                        PickOppMenu(menuActionService, textService, creatures);
                    }
                }
                else
                {
                    if (chosenFightLength == 1)
                    {
                        Helpers.Helpers.ClearLine();
                        FightSubMenu(menuActionService, chosenOppId, combatTurn, textService, creatures);
                    }
                    else
                    {
                        chosenFightLength--;
                        FightSimulation(menuActionService, chosenOppId, chosenFightLength, combatTurn, textService,
                            creatures);
                    }
                }
            }
        }
    }
}