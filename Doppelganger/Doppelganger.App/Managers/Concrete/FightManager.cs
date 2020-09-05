using System;
using Doppelganger.App.Helpers;
using Doppelganger.App.Managers.Abstract;
using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Services.Concrete;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Managers.Concrete
{
    public class FightManager : IFightManager
    {
        private readonly ITextService _textService;
        private readonly IDamageService _damageService;
        private readonly IFightService _fightService;
        private ICreatureService CreatureService { get; }

        public FightManager(ITextService textService, ICreatureService creatureService)
        {
            _textService = textService;
            CreatureService = creatureService;
            _damageService = new DamageService();
            _fightService = new FightService();
        }

        public void FightMenu()
        {
            Console.WriteLine(_textService.WelcomeToFight());

            Console.Write(_textService.Id().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(("|" + i).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.Attack().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(
                    ("|" + CreatureService.GetCreatureAttackById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.Speed().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(
                    ("|" + CreatureService.GetCreatureSpeedById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.MaxHP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(
                    ("|" + CreatureService.GetCreatureMaxHPById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            PickAllyMenu();
        }

        private void PickAllyMenu()
        {
            Console.Write(_textService.PickAlly());
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
                HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
                //now return control upwards
            }
        }

        private void PickOppMenu()
        {
            HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
            Console.Write(_textService.FightWhom());
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

                HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
                Console.Write(_textService.FightWhom());
                possibleChoices = "x" + HelperMethods.ValidNewOppNumbers(CreatureService);
                choice = HelperMethods.GetChar(possibleChoices);
                HelperMethods.ClearLine();
            }

            HelperMethods.DisplayCurrentHPs(_textService, CreatureService);
            //now return control upwards
        }

        private bool FightSubMenu(int chosenOppId, int turnNumber)
        {
            HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
            Console.Write(_textService.StayHowLong());
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

                HelperMethods.DisplayCurrentHPs(_textService, CreatureService, chosenOppId);
                Console.Write(_textService.StayHowLong());
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