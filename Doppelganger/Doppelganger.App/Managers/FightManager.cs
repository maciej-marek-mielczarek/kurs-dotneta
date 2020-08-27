using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Managers
{
    public class FightManager
    {
        private readonly ITextService _textService;
        public readonly ICreatureService CreatureService;

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

            char choice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            List<Creature> creatures = CreatureService.GetCrts();
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
                CreatureService.SetCrts(creatures);
                PickOppMenu();
            }
            else
            {
                //return control upwards
            }
        }

        private void PickOppMenu()
        {
            Console.Write(_textService.HP().PadRight(DisplaySettings.FirstColumnWidth));
            List<Creature> creatures = CreatureService.GetCrts();
            foreach (var creature in creatures)
            {
                Console.Write(
                    ("|" + creature.CurrentHP + (creature is Ally ? "*" : "")).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.Write(_textService.FightWhom());
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
                    PickOppMenu();
                }
                else
                {
                    FightSubMenu(chosenOppId, 0);
                }
            }
            else
            {
                Console.WriteLine();
                //return control upwards
            }
        }

        private void FightSubMenu(int chosenOppId, int combatTurn)
        {
            List<Creature> creatures = CreatureService.GetCrts();
            Console.Write(_textService.HP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; ++i)
            {
                Console.Write(("|"
                               + creatures[i].CurrentHP
                               + (creatures[i] is Ally ? "*" : "")
                               + (i == chosenOppId ? "x" : ""))
                    .PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.Write(_textService.StayHowLong());
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.Helpers.GetChar(possibleChoices);
            if (choice == 'x')
            {
                Console.WriteLine();
                //return control upwards
            }
            else if (choice == '0')
            {
                Helpers.Helpers.ClearLine();
                PickOppMenu();
            }
            else
            {
                int chosenFightLength = Helpers.Helpers.CharDigitToInt(choice);
                FightSimulation(chosenOppId, chosenFightLength, combatTurn);
            }
        }

        private void FightSimulation(int chosenOppId, int chosenFightLength, int combatTurn)
        {
            if (chosenFightLength == 0)
            {
                Helpers.Helpers.ClearLine();
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
                CreatureService.SetCrts(creatures);
                if (playerDied)
                {
                    Console.WriteLine();
                    //return control upwards
                }
                else if (oppDied)
                {
                    if (deadOppsCount + 1 == DisplaySettings.NumberOfOpps)
                    {
                        Console.WriteLine();
                        //return control upwards
                    }
                    else
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        float previousAllysHPPercent = creatures.Find(cr => cr is Ally).CurrentHP
                                                       // ReSharper disable once PossibleNullReferenceException
                                                       / (float)creatures.Find(cr => cr is Ally).MaxHP;
                        bool leftOldAlly = false, assumedNewShape = false;
                        for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; creatureId++)
                        {
                            if (!leftOldAlly && creatures[creatureId] is Ally)
                            {
                                Opponent oldAlly = (Ally)creatures[creatureId];
                                creatures[creatureId] = oldAlly;
                                leftOldAlly = true;
                            }
                            if (!assumedNewShape && creatureId == chosenOppId)
                            {
                                Ally newAlly = (Opponent)creatures[creatureId];
                                newAlly.CurrentHP = (byte)Math.Ceiling(newAlly.MaxHP * previousAllysHPPercent);
                                creatures[creatureId] = newAlly;
                                assumedNewShape = true;
                            }
                            if (assumedNewShape && leftOldAlly)
                            {
                                break;
                            }
                        }
                        Helpers.Helpers.ClearLine();
                        CreatureService.SetCrts(creatures);
                        PickOppMenu();
                    }
                }
                else
                {
                    if (chosenFightLength == 1)
                    {
                        Helpers.Helpers.ClearLine();
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
    }
}