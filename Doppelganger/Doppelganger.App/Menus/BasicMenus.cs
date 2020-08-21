using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Settings;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger.App.Menus
{
    public static class BasicMenus
    {
        public static void MainMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            //Main Menu
            List<MenuAction> actions = menuActionService.GetActionsForMenu("Main");
            string possibleChoices = "";
            foreach (var action in actions)
            {
                Console.Write(Helpers.Helpers.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = Helpers.Helpers.GetChar(possibleChoices);
            Helpers.Helpers.ClearLine();
            switch (menuChoice)
            {
                case 'n':
                    NewGame(menuActionService, textService, creatures);
                    break;
                case 'i':
                    InstructionMenus.InstructionsMenu(menuActionService, textService, creatures);
                    break;
                case 'x':
                    break;
            }
        }

        private static void NewGame(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                creatures.Add(new Creature());
            }

            FightMenus.FightMenu(menuActionService, textService, creatures);
        }

        public static void EndGameMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.WriteLine(textService.YourScoreIs() + Helpers.Helpers.CalculateScore(creatures) + "%");
            Console.WriteLine();
            creatures = new List<Creature>();
            MainMenu(menuActionService, textService, creatures);
        }

        public static Language LanguageMenu(IMenuActionService menuActionService)
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