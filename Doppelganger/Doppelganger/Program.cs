using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.App.Concrete;
using Doppelganger.App.Helpers;
using Doppelganger.App.Menus;
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
            //Initialize, display title and welcome message
            IMenuActionService menuActionService = new MenuActionService();
            Language languageChoice = BasicMenus.LanguageMenu(menuActionService);
            ITextService textService = new TextService(languageChoice);
            menuActionService.Initialize(textService);
            List<Creature> creatures = new List<Creature>();
            Console.Write(textService.Welcome());
            //Start game
            BasicMenus.MainMenu(menuActionService, textService, creatures);
        }
    }
}
