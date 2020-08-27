using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;

namespace Doppelganger.App.Managers
{
    public class InstructionsManager
    {
        private readonly IMenuActionService menuActionService;
        private readonly ITextService textService;

        public InstructionsManager(IMenuActionService menuActionService, ITextService textService)
        {
            this.menuActionService = menuActionService;
            this.textService = textService;
        }

        public void InstructionsMenu()
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
                    ActionsInfo();
                    break;
                case 's':
                    StatsInfo();
                    break;
                case 'b':
                    MenuManager.MainMenu();
                    break;
            }
        }

        private void StatsInfo()
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
                    AttackInfo();
                    break;
                case 'h':
                    HpInfo();
                    break;
                case 's':
                    SpeedInfo();
                    break;
                case 'b':
                    InstructionsMenu();
                    break;
            }
        }

        private void SpeedInfo()
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
                    StatsInfo();
                    break;
            }
        }

        private void HpInfo()
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
                    StatsInfo();
                    break;
            }
        }

        private void AttackInfo()
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
                    StatsInfo();
                    break;
            }
        }

        private void ActionsInfo()
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
                    PickAllyInfo();
                    break;
                case 'o':
                    PickOpponentInfo();
                    break;
                case 'f':
                    FightInfo();
                    break;
                case 'b':
                    InstructionsMenu();
                    break;
            }
        }

        private void FightInfo()
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
                    ActionsInfo();
                    break;
            }
        }

        private void PickOpponentInfo()
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
                    ActionsInfo();
                    break;
            }
        }

        private void PickAllyInfo()
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
                    ActionsInfo();
                    break;
            }
        }
    }
}