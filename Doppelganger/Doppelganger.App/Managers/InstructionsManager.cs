using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;

namespace Doppelganger.App.Managers
{
    public static class InstructionsManager
    {
        public static void InstructionsMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            //Instructions Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Instructions");
            string possibleChoices = "";
            Console.Write(textService.GetInfoOn());
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
                    ActionsInfo(menuActionService, textService, creatures);
                    break;
                case 's':
                    StatsInfo(menuActionService, textService, creatures);
                    break;
                case 'b':
                    MenuManager.MainMenu(menuActionService, textService, creatures);
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
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
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo(menuActionService, textService, creatures);
                    break;
            }
        }
    }
}