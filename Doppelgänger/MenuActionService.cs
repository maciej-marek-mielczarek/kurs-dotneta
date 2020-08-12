using System;
using System.Collections.Generic;

namespace Doppelgänger
{
    internal class MenuActionService
    {
        private List<MenuAction> menuActions;

        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }

        internal void AddNewAction(char keyToChoose, string actionName, string menuName)
        {
            MenuAction menuAction = new MenuAction() { KeyToChoose = keyToChoose, ActionName = actionName, MenuName = menuName };
            menuActions.Add(menuAction);
        }

        internal List<MenuAction> GetActionsForMenu(string menuName)
        {
            return menuActions.FindAll(action => action.MenuName == menuName);
        }
    }
}