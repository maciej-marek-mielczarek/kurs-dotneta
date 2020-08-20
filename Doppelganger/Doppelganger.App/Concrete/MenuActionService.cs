using System;
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

        public void AddNewAction(char keyToChoose, string actionName, string menuName)
        {
            MenuAction menuAction = new MenuAction() { KeyToChoose = keyToChoose, ActionName = actionName, MenuName = menuName };
            _menuActions.Add(menuAction);
        }

        public List<MenuAction> GetActionsForMenu(string menuName)
        {
            return _menuActions.FindAll(action => action.MenuName == menuName);
        }

        private void InitializeLang()
        {
            AddNewAction('p', "pl", "Lang");
            AddNewAction('e', "eng", "Lang");
        }
    }
}
