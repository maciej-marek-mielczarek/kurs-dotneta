using System;
using System.Collections.Generic;
using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;
using Doppelganger.Domain.Entity.Settings;
using Doppelganger.Domain.Entity.Texts;

namespace Doppelganger.App.Managers
{
    public class MenuManager
    {//move all from this class to GameManager; control will flow through it
        private readonly IMenuActionService menuActionService;
        private readonly ITextService textService;

        public MenuManager(IMenuActionService menuActionService, ITextService textService)
        {
            this.menuActionService = menuActionService;
            this.textService = textService;
        }

        public void MainMenu()
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
                    NewGame(creatures);
                    break;
                case 'i':
                    InstructionsManager.InstructionsMenu();
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

            FightManager.FightMenu(menuActionService, textService, creatures);
        }

        public static void EndGameMenu(IMenuActionService menuActionService, ITextService textService,
            List<Creature> creatures)
        {
            Console.WriteLine(textService.YourScoreIs() + Helpers.Helpers.CalculateScore(creatures) + "%");
            Console.WriteLine();
            creatures = new List<Creature>();
            MainMenu(menuActionService, textService, creatures);
        }
    }
}