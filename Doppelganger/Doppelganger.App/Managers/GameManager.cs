﻿using Doppelganger.App.Abstract;
using Doppelganger.Domain.Common;
using System;
using System.Collections.Generic;
using Doppelganger.App.Helpers;

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
                Console.Write(HelperMethods.Buttonize(action.ActionName, action.KeyToChoose));
                possibleChoices += action.KeyToChoose;
            }

            char menuChoice = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
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
            _fightManager.Initialize();
            _fightManager.FightMenu();
            EndGame();
        }

        private void EndGame()
        {
            Console.WriteLine();
            Console.WriteLine(_textService.YourScoreIs() + HelperMethods.CalculateScore(_fightManager.CreatureService.GetCrts()) + "%");
            Console.WriteLine();
            _fightManager.CreatureService.ClearCrts();
            MainMenu();
        }
    }
}
