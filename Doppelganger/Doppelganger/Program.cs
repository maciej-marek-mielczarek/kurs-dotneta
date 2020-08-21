using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.App.Concrete;
using Doppelganger.App.Helpers;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger
{
    internal static class Program
    {
        private const byte NumberOfOpps = 10;
        private const byte FirstColumnWidth = 14;
        private const int OtherColumnsWidth = 5;

        private static void Main()
        {
            //Initialize, display title and welcome message
            IMenuActionService menuActionService = new MenuActionService();
            Language languageChoice = LanguageMenu(menuActionService);
            ITextService textService = new TextService(languageChoice);
            menuActionService.Initialize(textService);
            List<Creature> creatures = new List<Creature>();
            Console.Write(textService.Welcome());
            //Start game
            MainMenu(menuActionService, textService, creatures);
        }

        private static void InstructionsMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            //Instructions Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Instructions");
            string possibleChoices = "";
            Console.Write(textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'a':
                    ActionsInfo(menuActionService, textService, creatures);
                    break;
                case 's':
                    StatsInfo(menuActionService, textService, creatures);
                    break;
                case 'b':
                    MainMenu(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void StatsInfo(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            //Stats Info Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("StatsInfo");
            string possibleChoices = "";
            Console.Write(textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'a':
                    AttackInfo(menuActionService, textService, creatures);
                    break;
                case 'h':
                    HpInfo(menuActionService, textService, creatures);
                    break;
                case 's':
                    SpeedInfo(menuActionService, textService, creatures);
                    break;
                case 'b':
                    InstructionsMenu(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void SpeedInfo(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.SpeedInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void HpInfo(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.HPInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void AttackInfo(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.AttackInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void ActionsInfo(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            //Actions Info Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionsInfo");
            string possibleChoices = "";
            Console.Write(textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'a':
                    PickAllyInfo(menuActionService, textService, creatures);
                    break;
                case 'o':
                    PickOpponentInfo(menuActionService, textService, creatures);
                    break;
                case 'f':
                    FightInfo(menuActionService, textService, creatures);
                    break;
                case 'b':
                    InstructionsMenu(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void FightInfo(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.FightInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void PickOpponentInfo(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.PickOpponentInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void PickAllyInfo(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.PickAllyInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService, textService, creatures);
                    break;
            }
        }

        private static void MainMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            //Main Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Main");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'n':
                    NewGame(menuActionService, textService, creatures);
                    break;
                case 'i':
                    InstructionsMenu(menuActionService, textService, creatures);
                    break;
                case 'x':
                    break;
            }
        }

        private static void NewGame(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            for (int i = 0; i < NumberOfOpps; i++)
            {
                creatures.Add(new Creature());
            }
            FightMenu(menuActionService, textService, creatures);
        }

        private static void FightMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.WriteLine(textService.WelcomeToFight());

            Console.Write(textService.Id().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; i++)
            {
                Console.Write(("|" + i).PadRight(OtherColumnsWidth));
            }
            Console.WriteLine();

            Console.Write(textService.Attack().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].Attack).PadRight(OtherColumnsWidth));
            }
            Console.WriteLine();

            Console.Write(textService.Speed().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].Speed).PadRight(OtherColumnsWidth));
            }
            Console.WriteLine();

            Console.Write(textService.MaxHP().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; i++)
            {
                Console.Write(("|" + creatures[i].MaxHP).PadRight(OtherColumnsWidth));
            }
            Console.WriteLine();

            PickAllyMenu(menuActionService, textService, creatures);
        }

        private static void PickAllyMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.PickAlly());
            string possibleChoices = "x";
            for (int i = 0; i < NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            if (choice != 'x')
            {
                int chosenAlly = Helpers.CharDigitToInt(choice);
                for (int i = 0; i < NumberOfOpps; i++)
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
                EndGameMenu(menuActionService, textService, creatures);
            }
        }

        private static void EndGameMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.WriteLine(textService.YourScoreIs() + Helpers.CalculateScore(creatures) + "%");
            Console.WriteLine();
            creatures = new List<Creature>();
            MainMenu(menuActionService, textService, creatures);
        }

        private static void PickOppMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.Write(textService.HP().PadRight(FirstColumnWidth));
            foreach (var creature in creatures)
            {
                Console.Write(("|" + creature.CurrentHP + (creature is Ally ? "*" : "")).PadRight(OtherColumnsWidth));
            }

            Console.Write(textService.FightWhom());
            string possibleChoices = "x";
            for (int i = 0; i < NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.GetChar(possibleChoices);
            if (choice != 'x')
            {
                Helpers.ClearLine();
                int chosenOppId = Helpers.CharDigitToInt(choice);
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
                EndGameMenu(menuActionService, textService, creatures);
            }
        }

        private static void FightSubMenu(IMenuActionService menuActionService, int chosenOppId, int combatTurn,
            ITextService textService, List<Creature> creatures)
        {
            Console.Write(textService.HP().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; ++i)
            {
                Console.Write(("|"
                + creatures[i].CurrentHP
                + (creatures[i] is Ally ? "*" : "")
                + (i == chosenOppId ? "x" : ""))
                .PadRight(OtherColumnsWidth));
            }
            Console.Write(textService.StayHowLong());
            string possibleChoices = "x";
            for (int i = 0; i < NumberOfOpps; i++)
            {
                possibleChoices += i;
            }
            char choice = Helpers.GetChar(possibleChoices);
            if (choice == 'x')
            {
                Console.WriteLine();
                EndGameMenu(menuActionService, textService, creatures);
            }
            else if (choice == '0')
            {
                Helpers.ClearLine();
                PickOppMenu(menuActionService, textService, creatures);
            }
            else
            {
                int chosenFightLength = Helpers.CharDigitToInt(choice);
                FightSimulation(menuActionService, chosenOppId, chosenFightLength, combatTurn, textService, creatures);
            }
        }

        private static void FightSimulation(IMenuActionService menuActionService, int chosenOppId,
            int chosenFightLength, int combatTurn, ITextService textService, List<Creature> creatures)
        {
            if (chosenFightLength == 0)
            {
                Helpers.ClearLine();
                FightSubMenu(menuActionService, chosenOppId, combatTurn, textService, creatures);
            }
            else
            {
                ++combatTurn;
                byte playersStrike = 0, oppsStrike = 0;
                for (int creatureId = 0; creatureId < NumberOfOpps; ++creatureId)
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
                for (int creatureId = 0; creatureId < NumberOfOpps; ++creatureId)
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
                            if(creatures[creatureId] is Ally)
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
                    EndGameMenu(menuActionService, textService, creatures);
                }
                else if (oppDied)
                {
                    if (deadOppsCount + 1 == NumberOfOpps)
                    {
                        Console.WriteLine();
                        EndGameMenu(menuActionService, textService, creatures);
                    }
                    else
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        float previousAllysHPPercent = creatures.Find(cr => cr is Ally).CurrentHP
                                                       // ReSharper disable once PossibleNullReferenceException
                                                       / ((float)(creatures.Find(cr => cr is Ally).MaxHP));
                        bool leftOldAlly = false, assumedNewShape = false;
                        for (int creatureId = 0; creatureId < NumberOfOpps; creatureId++)
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
                        Helpers.ClearLine();
                        PickOppMenu(menuActionService, textService, creatures);
                    }
                }
                else
                {
                    if (chosenFightLength == 1)
                    {
                        Helpers.ClearLine();
                        FightSubMenu(menuActionService, chosenOppId, combatTurn, textService, creatures);
                    }
                    else
                    {
                        chosenFightLength--;
                        FightSimulation(menuActionService, chosenOppId, chosenFightLength, combatTurn, textService, creatures);
                    }
                }
            }
        }

        private static Language LanguageMenu(IMenuActionService menuActionService)
        {
            //Language Choice Menu
            Console.Write(ChooseLanguageText.Text);
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Lang");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char languageCode = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            return languageCode == 'p' ? Language.Polish : Language.English;
        }
    }
}
