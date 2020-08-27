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
        private FightManager fightManager;
        private InstructionsManager instructionsManager;
        private MenuManager menuManager;
        
        public GameManager(ITextService textService, IMenuActionService menuActionService, ICreatureService creatureService)
        {
            List<Creature> creatures = new List<Creature>();
            menuManager = new MenuManager(menuActionService, textService);
            instructionsManager = new InstructionsManager(menuActionService, textService);
            fightManager = new FightManager(menuActionService, textService, creatureService);
        }

        public void Launch()
        {
            menuManager.MainMenu();
        }
    }
}
