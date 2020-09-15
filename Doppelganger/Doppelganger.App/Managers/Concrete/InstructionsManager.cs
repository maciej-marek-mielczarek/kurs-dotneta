using System;
using System.Collections.Generic;
using Doppelganger.App.Helpers.Abstract;
using Doppelganger.App.Helpers.Concrete;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Services.Abstract;
using Doppelganger.Domain.Common;

namespace Doppelganger.App.Managers.Concrete
{
    public class InstructionsManager : IInstructionsManager
    {
        private readonly IMenuActionService _menuActionService;
        private readonly ITextService _textService;
        private readonly IUserInput _userInput;

        public InstructionsManager(IMenuActionService menuActionService, ITextService textService)
        {
            _menuActionService = menuActionService;
            _textService = textService;
            _userInput = new UserInput();
        }

        public void InstructionsMenu()
        {
            //Instructions Menu
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("Instructions");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
            switch (menuChoice)
            {
                case 'a':
                    ActionsInfo();
                    break;
                case 's':
                    StatsInfo();
                    break;
                case 'b':
                    //return control upwards
                    break;
            }
        }

        private void StatsInfo()
        {
            //Stats Info Menu
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("StatsInfo");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
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
            Console.Write(_textService.SpeedInfo());
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo();
                    break;
            }
        }

        private void HpInfo()
        {
            Console.Write(_textService.HPInfo());
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    StatsInfo();
                    break;
            }
        }

        private void AttackInfo()
        {
            Console.Write(_textService.AttackInfo());
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
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
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("ActionsInfo");
            string possibleChoices = "";
            Console.Write(_textService.GetInfoOn());
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
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
            Console.Write(_textService.FightInfo());
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo();
                    break;
            }
        }

        private void PickOpponentInfo()
        {
            Console.Write(_textService.PickOpponentInfo());
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo();
                    break;
            }
        }

        private void PickAllyInfo()
        {
            Console.Write(_textService.PickAllyInfo());
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("ActionInfo");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
            switch (menuChoice)
            {
                case 'b':
                    ActionsInfo();
                    break;
            }
        }
    }
}