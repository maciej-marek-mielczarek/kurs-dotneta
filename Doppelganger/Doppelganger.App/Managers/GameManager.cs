using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;
using System;
using System.Collections.Generic;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Managers
{
    public class GameManager
    {
        private readonly IMenuActionService _menuActionService;
        private readonly ITextService _textService;
        
        private readonly FightManager _fightManager;
        private readonly InstructionsManager _instructionsManager;

        public GameManager(ITextService textService, IMenuActionService menuActionService, ICreatureService creatureService)
        {
            this._menuActionService = menuActionService;
            this._textService = textService;
            
            _instructionsManager = new InstructionsManager(menuActionService, textService);
            _fightManager = new FightManager(textService, creatureService);
        }
        public void MainMenu()
        {
            //Main Menu
            List<MenuAction> actions = _menuActionService.GetActionsForMenu("Main");
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
                    NewGame();
                    break;
                case 'i':
                    _instructionsManager.InstructionsMenu();
                    MainMenu();
                    break;
                case 'x':
                    break;
            }
        }

        private void NewGame()
        {
            List<Creature> creatures = _fightManager.CreatureService.GetCrts();
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                creatures.Add(new Creature());
            }
            _fightManager.CreatureService.SetCrts(creatures);
            _fightManager.FightMenu();
            EndGame();
        }

        private void EndGame()
        {
            Console.WriteLine(_textService.YourScoreIs() + Helpers.Helpers.CalculateScore(_fightManager.CreatureService.GetCrts()) + "%");
            Console.WriteLine();
            _fightManager.CreatureService.SetCrts(new List<Creature>());
            MainMenu();
        }
    }
}
