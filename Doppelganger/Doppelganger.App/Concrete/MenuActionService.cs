using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;

namespace Doppelganger.App.Concrete
{
    public class MenuActionService: IMenuActionService
    {
        private readonly List<MenuAction> _menuActions;

        public MenuActionService()
        {
            _menuActions = new List<MenuAction>();
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
    }
}
