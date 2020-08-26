using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Entity.Texts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doppelganger.App.Managers
{
    public class LanguageManager
    {
        private readonly IMenuActionService menuActionService;

        public LanguageManager(IMenuActionService menuActionService)
        {
            this.menuActionService = menuActionService;
        }
        public Language ChooseLanguage()
        {
            //Language Choice Menu
            Console.Write(ChooseLanguageText.Text);
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Lang");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char languageCode = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            return languageCode == 'p' ? Language.Polish : Language.English;
        }
    }
}
