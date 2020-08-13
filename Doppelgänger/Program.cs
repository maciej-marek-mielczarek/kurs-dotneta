using System;
using System.Collections.Generic;
using Translations;

namespace Doppelgänger
{
    class Program
    {
        private static Texts texts;
        private const byte NUMBER_OF_OPPS = 10;
        private const byte FIRST_COLUMN_WIDTH = 14;
        private static List<Creature> creatures;
        private const int OTHER_COLUMNS_WIDTH = 5;

        static void Main(string[] args)
        {
            MenuActionService menuActionService = new MenuActionService();
            InitializeLang(menuActionService);

            Console.WriteLine("Doppelgänger, a puzzle/rpg game.");
            Console.WriteLine();
            LanguageMenu(menuActionService);
            texts.Welcome();
            Console.WriteLine();
            MainMenu(menuActionService);
        }

        private static void InstructionsMenu(MenuActionService menuActionService)
        {
            //Instructions Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Instructions");
            string possibleChoices = "";
            Console.Write(texts.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'a':
                    ActionsInfo(menuActionService);
                    break;
                case 's':
                    StatsInfo(menuActionService);
                    break;
                case 'b':
                    MainMenu(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void StatsInfo(MenuActionService menuActionService)
        {
            //Stats Info Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("StatsInfo");
            string possibleChoices = "";
            Console.Write(texts.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'a':
                    AttackInfo(menuActionService);
                    break;
                case 'h':
                    HpInfo(menuActionService);
                    break;
                case 's':
                    SpeedInfo(menuActionService);
                    break;
                case 'b':
                    InstructionsMenu(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void SpeedInfo(MenuActionService menuActionService)
        {
            Console.Write(texts.SpeedInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void HpInfo(MenuActionService menuActionService)
        {
            Console.Write(texts.HPInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void AttackInfo(MenuActionService menuActionService)
        {
            Console.Write(texts.AttackInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void ActionsInfo(MenuActionService menuActionService)
        {
            //Actions Info Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionsInfo");
            string possibleChoices = "";
            Console.Write(texts.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'a':
                    PickAllyInfo(menuActionService);
                    break;
                case 'o':
                    PickOpponentInfo(menuActionService);
                    break;
                case 'f':
                    FightInfo(menuActionService);
                    break;
                case 'b':
                    InstructionsMenu(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void FightInfo(MenuActionService menuActionService)
        {
            Console.Write(texts.FightInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void PickOpponentInfo(MenuActionService menuActionService)
        {
            Console.Write(texts.PickOpponentInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void PickAllyInfo(MenuActionService menuActionService)
        {
            Console.Write(texts.PickAllyInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService);
                    break;
                default:
                    break;
            }
        }

        private static void MainMenu(MenuActionService menuActionService)
        {
            //Main Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Main");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'n':
                    NewGame(menuActionService);
                    break;
                case 'i':
                    InstructionsMenu(menuActionService);
                    break;
                case 'x':
                default:
                    break;
            }
        }

        private static void NewGame(MenuActionService menuActionService)
        {
            for (int i = 0; i < NUMBER_OF_OPPS; i++)
            {
                creatures.Add(new Creature());
            }
            FightMenu(menuActionService);
        }

        private static void FightMenu(MenuActionService menuActionService)
        {
            Console.WriteLine(texts.WelcomeToFight());

            Console.Write(texts.Id().PadRight(FIRST_COLUMN_WIDTH));
            for (int i = 0; i < NUMBER_OF_OPPS; i++)
            {
                Console.Write(("|" + i).PadRight(OTHER_COLUMNS_WIDTH));
            }
            Console.WriteLine();

            Console.Write(texts.Attack().PadRight(FIRST_COLUMN_WIDTH));
            for (int i = 0; i < NUMBER_OF_OPPS; i++)
            {
                Console.Write(("|" + creatures[i].Attack).PadRight(OTHER_COLUMNS_WIDTH));
            }
            Console.WriteLine();

            Console.Write(texts.Speed().PadRight(FIRST_COLUMN_WIDTH));
            for (int i = 0; i < NUMBER_OF_OPPS; i++)
            {
                Console.Write(("|" + creatures[i].Speed).PadRight(OTHER_COLUMNS_WIDTH));
            }
            Console.WriteLine();

            Console.Write(texts.MaxHP().PadRight(FIRST_COLUMN_WIDTH));
            for (int i = 0; i < NUMBER_OF_OPPS; i++)
            {
                Console.Write(("|" + creatures[i].MaxHP).PadRight(OTHER_COLUMNS_WIDTH));
            }
            Console.WriteLine();

            PickAllyMenu(menuActionService);
        }

        private static void PickAllyMenu(MenuActionService menuActionService)
        {
            Console.Write(texts.PickAlly());
            string possibleChoices = "x";
            for (int i = 0; i < NUMBER_OF_OPPS; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            if (choice != 'x')
            {
                int chosenAlly = Helpers.CharDigitToInt(choice);
                for (int i = 0; i < NUMBER_OF_OPPS; i++)
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
                PickOppMenu(menuActionService);
            }
            else
            {
                EndGameMenu(menuActionService);
            }
        }

        private static void EndGameMenu(MenuActionService menuActionService)
        {
            Console.WriteLine(texts.YourScoreIs() + Helpers.CalculateScore(creatures) + "%");
            Console.WriteLine();
            creatures = new List<Creature>();
            MainMenu(menuActionService);
        }

        private static void PickOppMenu(MenuActionService menuActionService)
        {
            Console.Write(texts.HP().PadRight(FIRST_COLUMN_WIDTH));
            foreach (var creature in creatures)
            {
                Console.Write(("|" + creature.CurrentHP + (creature is Ally ? "*" : "")).PadRight(OTHER_COLUMNS_WIDTH));
            }

            Console.Write(texts.FightWhom());
            string possibleChoices = "x";
            for (int i = 0; i < NUMBER_OF_OPPS; i++)
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
                    PickOppMenu(menuActionService);
                }
                else
                {
                    FightSubMenu(menuActionService, chosenOppId, 0);
                }
            }
            else
            {
                Console.WriteLine();
                EndGameMenu(menuActionService);
            }
        }

        private static void FightSubMenu(MenuActionService menuActionService, int chosenOppId, int combatTurn)
        {
            Console.Write(texts.HP().PadRight(FIRST_COLUMN_WIDTH));
            for (int i = 0; i < NUMBER_OF_OPPS; ++i)
            {
                Console.Write(("|"
                + creatures[i].CurrentHP
                + (creatures[i] is Ally ? "*" : "")
                + (i == chosenOppId ? "x" : ""))
                .PadRight(OTHER_COLUMNS_WIDTH));
            }
            Console.Write(texts.StayHowLong());
            string possibleChoices = "x";
            for (int i = 0; i < NUMBER_OF_OPPS; i++)
            {
                possibleChoices += i;
            }
            char choice = Helpers.GetChar(possibleChoices);
            if (choice == 'x')
            {
                Console.WriteLine();
                EndGameMenu(menuActionService);
            }
            else if (choice == '0')
            {
                Helpers.ClearLine();
                PickOppMenu(menuActionService);
            }
            else
            {
                int chosenFightLength = Helpers.CharDigitToInt(choice);
                FightSimulation(menuActionService, chosenOppId, chosenFightLength, combatTurn);
            }
        }

        private static void FightSimulation(MenuActionService menuActionService, int chosenOppId, int chosenFightLength, int combatTurn)
        {
            if (chosenFightLength == 0)
            {
                Helpers.ClearLine();
                FightSubMenu(menuActionService, chosenOppId, combatTurn);
            }
            else
            {
                ++combatTurn;
                byte playersStrike = 0, oppsStrike = 0;
                for (int creatureId = 0; creatureId < NUMBER_OF_OPPS; ++creatureId)
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
                for (int creatureId = 0; creatureId < NUMBER_OF_OPPS; ++creatureId)
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
                    EndGameMenu(menuActionService);
                }
                else if (oppDied)
                {
                    if (deadOppsCount + 1 == NUMBER_OF_OPPS)
                    {
                        Console.WriteLine();
                        EndGameMenu(menuActionService);
                    }
                    else
                    {
                        float previousAllysHPPercent = ((float)(creatures.Find(cr => cr is Ally).CurrentHP)) / ((float)(creatures.Find(cr => cr is Ally).MaxHP));
                        bool leftOldAlly = false, assumedNewShape = false;
                        for (int creatureId = 0; creatureId < NUMBER_OF_OPPS; creatureId++)
                        {
                            if (!leftOldAlly && creatures[creatureId] is Ally)
                            {
                                Opponent oldAlly = (Ally)creatures[creatureId];
                                creatures[creatureId] = oldAlly;
                            }
                            if (!assumedNewShape && creatureId == chosenOppId)
                            {
                                Ally newAlly = (Opponent)creatures[creatureId];
                                newAlly.CurrentHP = (byte)Math.Ceiling(newAlly.MaxHP * previousAllysHPPercent);
                                creatures[creatureId] = newAlly;
                            }
                            if (assumedNewShape && leftOldAlly)
                            {
                                break;
                            }
                        }
                        Helpers.ClearLine();
                        PickOppMenu(menuActionService);
                    }
                }
                else
                {
                    if (chosenFightLength == 1)
                    {
                        Helpers.ClearLine();
                        FightSubMenu(menuActionService, chosenOppId, combatTurn);
                    }
                    else
                    {
                        chosenFightLength--;
                        FightSimulation(menuActionService, chosenOppId, chosenFightLength, combatTurn);
                    }
                }
            }
        }

        private static void LanguageMenu(MenuActionService menuActionService)
        {
            //Language Choice Menu
            Console.Write("Please choose your language: ");
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Lang");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(" [" + action.ActionName + "] ");
                possibleChoices += action.KeyToChoose;
            }
            char languageCode = Helpers.GetChar(possibleChoices);
            Helpers.ClearLine();
            texts = new Texts(languageCode);
            Initialize(menuActionService);
        }

        private static void InitializeLang(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction('p', "(p)l", "Lang");
            menuActionService.AddNewAction('e', "(e)ng", "Lang");
        }

        private static void Initialize(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction('n', texts.NewGame(), "Main");
            menuActionService.AddNewAction('i', texts.Instructions(), "Main");
            menuActionService.AddNewAction('x', texts.Exit(), "Main");

            menuActionService.AddNewAction('s', texts.Stats(), "Instructions");
            menuActionService.AddNewAction('a', texts.Actions(), "Instructions");
            menuActionService.AddNewAction('b', texts.Back(), "Instructions");

            menuActionService.AddNewAction('a', texts.AttackButton(), "StatsInfo");
            menuActionService.AddNewAction('h', texts.HPButton(), "StatsInfo");
            menuActionService.AddNewAction('s', texts.SpeedButton(), "StatsInfo");
            menuActionService.AddNewAction('b', texts.Back(), "StatsInfo");

            menuActionService.AddNewAction('b', texts.Back(), "StatInfo");

            menuActionService.AddNewAction('a', texts.PickAllyButton(), "ActionsInfo");
            menuActionService.AddNewAction('o', texts.PickOpponentButton(), "ActionsInfo");
            menuActionService.AddNewAction('f', texts.FightButton(), "ActionsInfo");
            menuActionService.AddNewAction('b', texts.Back(), "ActionsInfo");

            menuActionService.AddNewAction('b', texts.Back(), "ActionInfo");

            creatures = new List<Creature>();
        }
    }
}
