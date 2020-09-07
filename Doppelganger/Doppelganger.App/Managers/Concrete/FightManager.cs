using System;
using Doppelganger.App.Helpers;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Doppelganger.App.Views.Abstract;
using Doppelganger.App.Views.Concrete;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Managers.Concrete
{
    public class FightManager : IFightManager
    {
        private readonly IDamageService _damageService;
        private readonly IFightService _fightService;
        private readonly IFightViews _fightViews;
        private ICreatureService CreatureService { get; }

        public FightManager(ITextService textService, ICreatureService creatureService)
        {
            CreatureService = creatureService;
            _damageService = new DamageService();
            _fightService = new FightService();
            _fightViews = new FightViews(textService);
        }

        public void PickAllyMenu()
        {
            _fightViews.PickAllyView(CreatureService);
            
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
            if (choice != 'x')
            {
                int chosenAlly = HelperMethods.CharDigitToInt(choice);
                CreatureService.MakeGivenCreatureFriendly(chosenAlly);
                PickOppMenu();
            }
            else
            {
                _fightViews.DisplayCurrentHPs(CreatureService);
                //now return control upwards
            }
        }

        private void PickOppMenu()
        {
            _fightViews.PickOppView(CreatureService);
            string possibleChoices = "x" + HelperMethods.ValidNewOppNumbers(CreatureService);

            char choice = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
            while (choice != 'x')
            {
                int chosenOppId = HelperMethods.CharDigitToInt(choice);
                bool continueGame = FightSubMenu(chosenOppId, 0);
                if (!continueGame)
                {
                    break;
                }

                _fightViews.PickOppView(CreatureService);
                possibleChoices = "x" + HelperMethods.ValidNewOppNumbers(CreatureService);
                choice = HelperMethods.GetChar(possibleChoices);
                HelperMethods.ClearLine();
            }

            _fightViews.DisplayCurrentHPs(CreatureService);
            //now return control upwards
        }

        private bool FightSubMenu(int chosenOppId, int turnNumber)
        {
            _fightViews.FightView(CreatureService, chosenOppId);
            
            string possibleChoices = "x";
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                possibleChoices += i;
            }

            char choice = HelperMethods.GetChar(possibleChoices);
            HelperMethods.ClearLine();
            bool gameIsOver = false;
            while (choice != '0' && choice != 'x')
            {
                int chosenFightLength = HelperMethods.CharDigitToInt(choice);
                int allysId = CreatureService.GetAllysId();
                turnNumber = _fightService.FightSimulation(chosenOppId, allysId, chosenFightLength, turnNumber, _damageService, CreatureService);
                HelperMethods.ClearLine();
                //Player dies - game over.
                bool playerIsDead = CreatureService.IsCreatureDead(allysId);
                //No hostile creatures left to hit - also game over.
                bool allOppsAreDead = CreatureService.CountDeadOpps() + 1 == DisplaySettings.NumberOfOpps;
                gameIsOver = playerIsDead || allOppsAreDead;
                if (gameIsOver)
                {
                    break;
                }

                bool oppIsDead = CreatureService.IsCreatureDead(chosenOppId);
                if (oppIsDead)
                {
                    CreatureService.SwitchBodiesWith(chosenOppId);
                    break;
                }

                _fightViews.FightView(CreatureService, chosenOppId);
                
                choice = HelperMethods.GetChar(possibleChoices);
                HelperMethods.ClearLine();
            }

            return !(choice == 'x' || gameIsOver);
        }

        public void Initialize()
        {
            CreatureService.GenerateNewCrts();
        }

        public int CalculateScore()
        {
            int score = 0;
            for (int creatureId = 0; creatureId < DisplaySettings.NumberOfOpps; ++creatureId)
            {
                int creatureScore = (int) Math.Floor(10m - 10m * CreatureService.GetCreatureCurrentHPById(creatureId) /
                    CreatureService.GetCreatureMaxHPById(creatureId));
                score += creatureScore;
            }

            return score;
        }
    }
}