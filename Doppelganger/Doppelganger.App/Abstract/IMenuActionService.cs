using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.App.Abstract
{
    public interface IMenuActionService
    {
        void AddNewAction(char keyToChoose, string actionName, string menuName);
        List<MenuAction> GetActionsForMenu(string menuName);
    }
}