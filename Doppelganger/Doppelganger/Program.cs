using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.App.Concrete;
using Doppelganger.App.Helpers;
using Doppelganger.App.Managers;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Creatures;
using Doppelganger.Domain.Entity.Settings;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger
{
    internal static class Program
    {
        private static void Main()
        {
            //Display title
            Console.Write(TitleText.Text);
            //Create Menu Action Service and partly initialize it (further initialization equireslanuage choice)
            IMenuActionService menuActionService = new MenuActionService();
            //Create Language Manager and ask it to pick a language
            LanguageManager languageManager = new LanguageManager(menuActionService);
            Language languageChoice = languageManager.ChooseLanguage();
            //Use the language choice to initialize Text and Menu Action Services
            ITextService textService = new TextService(languageChoice);
            menuActionService.Initialize(textService);
            //Write a one-time welcome message in the chosen language
            Console.Write(textService.Welcome());
            //Use services to initiaize Game Manager
            GameManager gameManager = new GameManager(textService, menuActionService);
            //Start game
            gameManager.Launch();
        }
    }
}
