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
        
        private static List<Creature> _creatures;
        private static ITextService _textService;

        private static void Main()
        {
            IMenuActionService menuActionService = new MenuActionService();
            LanguageMenu(menuActionService);
            menuActionService.Initialize(_textService);
            _creatures = new List<Creature>();
            Console.Write(_textService.Welcome());

            MainMenu(menuActionService);
        }

        private static void InstructionsMenu(IMenuActionService menuActionService)
        {
            //Instructions Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Instructions");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
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

        private static void StatsInfo(IMenuActionService menuActionService)
        {
            //Stats Info Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("StatsInfo");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
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

        private static void SpeedInfo(IMenuActionService menuActionService)
        {
            Console.Write(_textService.SpeedInfo());
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
                    StatsInfo(menuActionService);
                    break;
            }
        }

        private static void HpInfo(IMenuActionService menuActionService)
        {
            Console.Write(_textService.HPInfo());
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
                    StatsInfo(menuActionService);
                    break;
            }
        }

        private static void AttackInfo(IMenuActionService menuActionService)
        {
            Console.Write(_textService.AttackInfo());
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
                    StatsInfo(menuActionService);
                    break;
            }
        }

        private static void ActionsInfo(IMenuActionService menuActionService)
        {
            //Actions Info Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("ActionsInfo");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
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

        private static void FightInfo(IMenuActionService menuActionService)
        {
            Console.Write(_textService.FightInfo());
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
                    ActionsInfo(menuActionService);
                    break;
            }
        }

        private static void PickOpponentInfo(IMenuActionService menuActionService)
        {
            Console.Write(_textService.PickOpponentInfo());
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
                    ActionsInfo(menuActionService);
                    break;
            }
        }

        private static void PickAllyInfo(IMenuActionService menuActionService)
        {
            Console.Write(_textService.PickAllyInfo());
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
                    ActionsInfo(menuActionService);
                    break;
            }
        }

        private static void MainMenu(IMenuActionService menuActionService)
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
                    NewGame(menuActionService);
                    break;
                case 'i':
                    InstructionsMenu(menuActionService);
                    break;
                case 'x':
                    break;
            }
        }

        private static void NewGame(IMenuActionService menuActionService)
        {
            for (int i = 0; i < NumberOfOpps; i++)
            {
                _creatures.Add(new Creature());
            }
            FightMenu(menuActionService);
        }

        private static void FightMenu(IMenuActionService menuActionService)
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

        private static void PickAllyMenu(IMenuActionService menuActionService)
        {
            Console.Write(_textService.PickAlly());
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

        private static void EndGameMenu(IMenuActionService menuActionService)
        {
            Console.WriteLine(_textService.YourScoreIs() + Helpers.CalculateScore(_creatures) + "%");
            Console.WriteLine();
            _creatures = new List<Creature>();
            MainMenu(menuActionService);
        }

        private static void PickOppMenu(IMenuActionService menuActionService)
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

            char choice = Helpers.GetChar(possibleChoices);
            if (choice != 'x')
            {
                Helpers.ClearLine();
                int chosenOppId = Helpers.CharDigitToInt(choice);
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

        private static void FightSubMenu(IMenuActionService menuActionService, int chosenOppId, int combatTurn)
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

        private static void FightSimulation(IMenuActionService menuActionService, int chosenOppId, int chosenFightLength, int combatTurn)
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
                        // ReSharper disable once PossibleNullReferenceException
                        float previousAllysHPPercent = _creatures.Find(cr => cr is Ally).CurrentHP
                                                       // ReSharper disable once PossibleNullReferenceException
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

        private static void LanguageMenu(IMenuActionService menuActionService)
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
            _textService = new TextService(languageCode == 'p' ? Language.Polish : Language.English);
        }
    }
}
