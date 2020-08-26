using Doppelganger.App.Abstract;
using Doppelganger.App.Concrete;
using Doppelganger.Domain.Common;
using Doppelganger.Domain.Common.Creatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doppelganger.App.Managers
{
    public class GameManager
    {
        /*private FightManager _fightManager;
        private InstructionsManager _instructionsManager;
        private MenuManager _menuManager;
        */
        public GameManager(ITextService textService, IMenuActionService menuActionService)
        {
            List<Creature> creatures = new List<Creature>();
            MenuManager.MainMenu(menuActionService, textService, creatures);
        }

        public void Launch()
        {
            
        }
    }
}
