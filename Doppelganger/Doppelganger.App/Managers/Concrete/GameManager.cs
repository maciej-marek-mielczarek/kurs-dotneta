using System;
using System.Collections.Generic;
using Doppelganger.App.Helpers;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Services.Abstract;
using Doppelganger.Domain.Common;

namespace Doppelganger.App.Managers.Concrete
{
    public class GameManager : IGameManager
    {
        private readonly IMenuActionService _menuActionService;
        private readonly ITextService _textService;
        
        private readonly IFightManager _fightManager;
        private readonly IInstructionsManager _instructionsManager;

        public GameManager(ITextService textService, IMenuActionService menuActionService, ICreatureService creatureService)
        {
            _menuActionService = menuActionService;
            _textService = textService;
            
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
            bool allyPicked = _fightManager.PickAlly();
            if (allyPicked)
            {
                bool continueGame = true;
                while (continueGame)
                {
                    int chosenOppId = _fightManager.PickOpp();
                    if (chosenOppId == -1)
                    {
                        break;
                    }
                    continueGame = _fightManager.FightSubMenu(chosenOppId, 0);
                }
            }
            EndGame();
        }

        private void EndGame()
        {
            _fightManager.EndFight();
            Console.WriteLine();
            Console.WriteLine(_textService.YourScoreIs() + _fightManager.CalculateScore() + "%");
            Console.WriteLine();
            MainMenu();
        }
    }
}
