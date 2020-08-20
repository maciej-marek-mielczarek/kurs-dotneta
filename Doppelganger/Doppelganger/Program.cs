using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.App.Concrete;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;

namespace Doppelganger
{
    internal static class Program
    {
        private const byte NumberOfOpps = 10;
        private const byte FirstColumnWidth = 14;
        private static List<Creature> _creatures;
        private const int OtherColumnsWidth = 5;

        private static ITextService _textService;

        private static void Main()
        {
            var menuActionService = new MenuActionService();
            InitializeLang(menuActionService);

            Console.WriteLine("Doppelgänger, a puzzle/rpg game.");
            Console.WriteLine();
            LanguageMenu(menuActionService);
            Console.WriteLine(_textService.Welcome());
            Console.WriteLine();
            MainMenu(menuActionService);
        }

        private static void InstructionsMenu(MenuActionService menuActionService)
        {
            //Instructions Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Instructions");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
            }
        }

        private static void StatsInfo(MenuActionService menuActionService)
        {
            //Stats Info Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("StatsInfo");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
            }
        }

        private static void SpeedInfo(MenuActionService menuActionService)
        {
            Console.Write(_textService.SpeedInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService);
                    break;
            }
        }

        private static void HpInfo(MenuActionService menuActionService)
        {
            Console.Write(_textService.HPInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService);
                    break;
            }
        }

        private static void AttackInfo(MenuActionService menuActionService)
        {
            Console.Write(_textService.AttackInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo(menuActionService);
                    break;
            }
        }

        private static void ActionsInfo(MenuActionService menuActionService)
        {
            //Actions Info Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionsInfo");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
            }
        }

        private static void FightInfo(MenuActionService menuActionService)
        {
            Console.Write(_textService.FightInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService);
                    break;
            }
        }

        private static void PickOpponentInfo(MenuActionService menuActionService)
        {
            Console.Write(_textService.PickOpponentInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService);
                    break;
            }
        }

        private static void PickAllyInfo(MenuActionService menuActionService)
        {
            Console.Write(_textService.PickAllyInfo());
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService);
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'n':
                    NewGame(menuActionService);
                    break;
                case 'i':
                    InstructionsMenu(menuActionService);
                    break;
                case 'x':
                    break;
            }
        }

        private static void NewGame(MenuActionService menuActionService)
        {
            for (int i = 0; i < NumberOfOpps; i++)
            {
                _creatures.Add(new Creature());
            }
            FightMenu(menuActionService);
        }

        private static void FightMenu(MenuActionService menuActionService)
        {
            Console.WriteLine(_textService.WelcomeToFight());

            Console.Write(_textService.Id().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; i++)
            {
                Console.Write(("|" + i).PadRight(OtherColumnsWidth));
            }
            Console.WriteLine();

            Console.Write(_textService.Attack().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; i++)
            {
                Console.Write(("|" + _creatures[i].Attack).PadRight(OtherColumnsWidth));
            }
            Console.WriteLine();

            Console.Write(_textService.Speed().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; i++)
            {
                Console.Write(("|" + _creatures[i].Speed).PadRight(OtherColumnsWidth));
            }
            Console.WriteLine();

            Console.Write(_textService.MaxHP().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; i++)
            {
                Console.Write(("|" + _creatures[i].MaxHP).PadRight(OtherColumnsWidth));
            }
            Console.WriteLine();

            PickAllyMenu(menuActionService);
        }

        private static void PickAllyMenu(MenuActionService menuActionService)
        {
            Console.Write(_textService.PickAlly());
            string possibleChoices = "x";
            for (int i = 0; i < NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            if (choice != 'x')
            {
                int chosenAlly = Helpers.Helpers.CharDigitToInt(choice);
                for (int i = 0; i < NumberOfOpps; i++)
                {
                    if (i == chosenAlly)
                    {
                        _creatures[i] = new Ally(_creatures[i]);
                    }
                    else
                    {
                        _creatures[i] = new Opponent(_creatures[i]);
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
            Console.WriteLine(_textService.YourScoreIs() + Helpers.Helpers.CalculateScore(_creatures) + "%");
            Console.WriteLine();
            _creatures = new List<Creature>();
            MainMenu(menuActionService);
        }

        private static void PickOppMenu(MenuActionService menuActionService)
        {
            Console.Write(_textService.HP().PadRight(FirstColumnWidth));
            foreach (var creature in _creatures)
            {
                Console.Write(("|" + creature.CurrentHP + (creature is Ally ? "*" : "")).PadRight(OtherColumnsWidth));
            }

            Console.Write(_textService.FightWhom());
            string possibleChoices = "x";
            for (int i = 0; i < NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = Helpers.Helpers.GetChar(possibleChoices);
            if (choice != 'x')
            {
                Helpers.Helpers.ClearLine();
                int chosenOppId = Helpers.Helpers.CharDigitToInt(choice);
                if (_creatures[chosenOppId].CurrentHP == 0)
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
            Console.Write(_textService.HP().PadRight(FirstColumnWidth));
            for (int i = 0; i < NumberOfOpps; ++i)
            {
                Console.Write(("|"
                + _creatures[i].CurrentHP
                + (_creatures[i] is Ally ? "*" : "")
                + (i == chosenOppId ? "x" : ""))
                .PadRight(OtherColumnsWidth));
            }
            Console.Write(_textService.StayHowLong());
            string possibleChoices = "x";
            for (int i = 0; i < NumberOfOpps; i++)
            {
                possibleChoices += i;
            }
            char choice = Helpers.Helpers.GetChar(possibleChoices);
            if (choice == 'x')
            {
                Console.WriteLine();
                EndGameMenu(menuActionService);
            }
            else if (choice == '0')
            {
                Helpers.Helpers.ClearLine();
                PickOppMenu(menuActionService);
            }
            else
            {
                int chosenFightLength = Helpers.Helpers.CharDigitToInt(choice);
                FightSimulation(menuActionService, chosenOppId, chosenFightLength, combatTurn);
            }
        }

        private static void FightSimulation(MenuActionService menuActionService, int chosenOppId, int chosenFightLength, int combatTurn)
        {
            if (chosenFightLength == 0)
            {
                Helpers.Helpers.ClearLine();
                FightSubMenu(menuActionService, chosenOppId, combatTurn);
            }
            else
            {
                ++combatTurn;
                byte playersStrike = 0, oppsStrike = 0;
                for (int creatureId = 0; creatureId < NumberOfOpps; ++creatureId)
                {
                    if (_creatures[creatureId] is Ally)
                    {
                        if (combatTurn % _creatures[creatureId].Speed == 0)
                        {
                            playersStrike = _creatures[creatureId].Attack;
                        }
                    }
                    else if (creatureId == chosenOppId && combatTurn % _creatures[creatureId].Speed == 0)
                    {
                        oppsStrike = _creatures[creatureId].Attack;
                    }
                }
                bool playerDied = false, oppDied = false;
                byte deadOppsCount = 0;
                for (int creatureId = 0; creatureId < NumberOfOpps; ++creatureId)
                {
                    if (_creatures[creatureId] is Ally)
                    {
                        var playersHP = _creatures[creatureId].CurrentHP;
                        if (playersHP <= oppsStrike)
                        {
                            _creatures[creatureId].CurrentHP = 0;
                            playerDied = true;
                        }
                        else
                        {
                            _creatures[creatureId].CurrentHP -= oppsStrike;
                        }
                    }
                    else if (_creatures[creatureId].CurrentHP == 0)
                    {
                        deadOppsCount++;
                    }
                    if (creatureId == chosenOppId)
                    {
                        var oppsHP = _creatures[creatureId].CurrentHP;
                        if (oppsHP <= playersStrike)
                        {
                            _creatures[creatureId].CurrentHP = 0;
                            deadOppsCount++;
                            oppDied = true;
                            if(_creatures[creatureId] is Ally)
                            {
                                playerDied = true;
                            }
                        }
                        else
                        {
                            _creatures[creatureId].CurrentHP -= playersStrike;
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
                    if (deadOppsCount + 1 == NumberOfOpps)
                    {
                        Console.WriteLine();
                        EndGameMenu(menuActionService);
                    }
                    else
                    {
                        float previousAllysHPPercent = _creatures.Find(cr => cr is Ally).CurrentHP
                                                       / ((float)(_creatures.Find(cr => cr is Ally).MaxHP));
                        bool leftOldAlly = false, assumedNewShape = false;
                        for (int creatureId = 0; creatureId < NumberOfOpps; creatureId++)
                        {
                            if (!leftOldAlly && _creatures[creatureId] is Ally)
                            {
                                Opponent oldAlly = (Ally)_creatures[creatureId];
                                _creatures[creatureId] = oldAlly;
                                leftOldAlly = true;
                            }
                            if (!assumedNewShape && creatureId == chosenOppId)
                            {
                                Ally newAlly = (Opponent)_creatures[creatureId];
                                newAlly.CurrentHP = (byte)Math.Ceiling(newAlly.MaxHP * previousAllysHPPercent);
                                _creatures[creatureId] = newAlly;
                                assumedNewShape = true;
                            }
                            if (assumedNewShape && leftOldAlly)
                            {
                                break;
                            }
                        }
                        Helpers.Helpers.ClearLine();
                        PickOppMenu(menuActionService);
                    }
                }
                else
                {
                    if (chosenFightLength == 1)
                    {
                        Helpers.Helpers.ClearLine();
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName,action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }
            char languageCode = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            _textService = new TextService(languageCode == 'p' ? Language.Polish : Language.English);
            Initialize(menuActionService);
        }

        private static void InitializeLang(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction('p', "pl", "Lang");
            menuActionService.AddNewAction('e', "eng", "Lang");
        }

        private static void Initialize(MenuActionService menuActionService)
        {
            menuActionService.AddNewAction('n', _textService.NewGame(), "Main");
            menuActionService.AddNewAction('i', _textService.Instructions(), "Main");
            menuActionService.AddNewAction('x', _textService.Exit(), "Main");

            menuActionService.AddNewAction('s', _textService.Stats(), "Instructions");
            menuActionService.AddNewAction('a', _textService.Actions(), "Instructions");
            menuActionService.AddNewAction('b', _textService.Back(), "Instructions");

            menuActionService.AddNewAction('a', _textService.Attack(), "StatsInfo");
            menuActionService.AddNewAction('h', _textService.HP(), "StatsInfo");
            menuActionService.AddNewAction('s', _textService.Speed(), "StatsInfo");
            menuActionService.AddNewAction('b', _textService.Back(), "StatsInfo");

            menuActionService.AddNewAction('b', _textService.Back(), "StatInfo");

            menuActionService.AddNewAction('a', _textService.AboutAlly(), "ActionsInfo");
            menuActionService.AddNewAction('o', _textService.AboutOpponent(), "ActionsInfo");
            menuActionService.AddNewAction('f', _textService.Fight(), "ActionsInfo");
            menuActionService.AddNewAction('b', _textService.Back(), "ActionsInfo");

            menuActionService.AddNewAction('b', _textService.Back(), "ActionInfo");

            _creatures = new List<Creature>();
        }
    }
}
