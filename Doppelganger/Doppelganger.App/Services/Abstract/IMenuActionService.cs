using System.Collections.Generic;
using Doppelganger.Domain.Common;

namespace Doppelganger.App.Services.Abstract
{
    public interface IMenuActionService
    {
        List<MenuAction> GetActionsForMenu(string menuName);
        void Initialize(ITextService textService);
    }
}