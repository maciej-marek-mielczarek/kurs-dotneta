using System;
using System.Collections.Generic;
using Doppelganger.App.Helpers;
using Doppelganger.App.Helpers.Abstract;
using Doppelganger.App.Helpers.Concrete;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Services.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger.App.Managers.Concrete
{
    public class LanguageManager : ILanguageManager
    {
        private readonly IMenuActionService _menuActionService;
        private readonly IUserInput _userInput;
        

        public LanguageManager(IMenuActionService menuActionService)
        {
            _menuActionService = menuActionService;
            _userInput = new UserInput();
        }
        public Language ChooseLanguage()
        {
            //Language Choice Menu
            Console.Write(ChooseLanguageText.Text);
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("Lang");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(MiscOutput.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char languageCode = _userInput.GetChar(possibleChoices);
            MiscOutput.ClearLine();
            return languageCode == 'p' ? Language.Polish : Language.English;
        }
    }
}
