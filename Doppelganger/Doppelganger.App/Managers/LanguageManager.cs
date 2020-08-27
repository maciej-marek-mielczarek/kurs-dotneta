using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Entity.Texts;
using System;
using System.Collections.Generic;
using Doppelganger.App.Helpers;

namespace Doppelganger.App.Managers
{
    public class LanguageManager
    {
        private readonly IMenuActionService _menuActionService;

        public LanguageManager(IMenuActionService menuActionService)
        {
            this._menuActionService = menuActionService;
        }
        public Language ChooseLanguage()
        {
            //Language Choice Menu
            Console.Write(ChooseLanguageText.Text);
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("Lang");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(HelperMethods.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char languageCode = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
            return languageCode == 'p' ? Language.Polish : Language.English;
        }
    }
}
