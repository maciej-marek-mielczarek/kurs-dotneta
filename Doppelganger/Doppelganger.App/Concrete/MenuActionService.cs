﻿using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger.App.Concrete
{
    public class MenuActionService: IMenuActionService
    {
        private readonly List<MenuAction> _menuActions;

        public MenuActionService()
        {
            _menuActions = new List<MenuAction>();

            Console.Write(TitleText.Text);
            
            InitializeLang();
        }

        private void AddNewAction(char keyToChoose, string actionName, string menuName)
        {
            MenuAction menuAction = new MenuAction() { KeyToChoose = keyToChoose, ActionName = actionName, MenuName = menuName };
            _menuActions.Add(menuAction);
        }

        public List<MenuAction> GetActionsForMenu(string menuName)
        {
            return _menuActions.FindAll(action => action.MenuName == menuName);
        }

        public void Initialize(ITextService textService)
        {
            AddNewAction('n', textService.NewGame(), "Main");
            AddNewAction('i', textService.Instructions(), "Main");
            AddNewAction('x', textService.Exit(), "Main");

            AddNewAction('s', textService.Stats(), "Instructions");
            AddNewAction('a', textService.Actions(), "Instructions");
            AddNewAction('b', textService.Back(), "Instructions");

            AddNewAction('a', textService.Attack(), "StatsInfo");
            AddNewAction('h', textService.HP(), "StatsInfo");
            AddNewAction('s', textService.Speed(), "StatsInfo");
            AddNewAction('b', textService.Back(), "StatsInfo");

            AddNewAction('b', textService.Back(), "StatInfo");

            AddNewAction('a', textService.AboutAlly(), "ActionsInfo");
            AddNewAction('o', textService.AboutOpponent(), "ActionsInfo");
            AddNewAction('f', textService.Fight(), "ActionsInfo");
            AddNewAction('b', textService.Back(), "ActionsInfo");

            AddNewAction('b', textService.Back(), "ActionInfo");
        }

        private void InitializeLang()
        {
            AddNewAction('p', "pl", "Lang");
            AddNewAction('e', "eng", "Lang");
        }
    }
}
