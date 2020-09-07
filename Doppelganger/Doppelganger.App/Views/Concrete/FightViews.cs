using System;
using Doppelganger.App.Services.Abstract;
using Doppelganger.App.Views.Abstract;
using Doppelganger.Domain.Entity.Settings;

namespace Doppelganger.App.Views.Concrete
{
    public class FightViews : IFightViews
    {
        private readonly ITextService _textService;
        public FightViews(ITextService textService)
        {
            _textService = textService;
        }

        public void PickAllyView(ICreatureService creatureService)
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
                    ("|" + creatureService.GetCreatureAttackById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.Speed().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(
                    ("|" + creatureService.GetCreatureSpeedById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.MaxHP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; i++)
            {
                Console.Write(
                    ("|" + creatureService.GetCreatureMaxHPById(i)).PadRight(DisplaySettings.OtherColumnsWidth));
            }

            Console.WriteLine();

            Console.Write(_textService.PickAlly());
        }

        public void PickOppView(ICreatureService creatureService)
        {
            DisplayCurrentHPs(creatureService);
            Console.Write(_textService.FightWhom());

        }

        public void FightView(ICreatureService creatureService, int chosenOppId)
        {
            DisplayCurrentHPs(creatureService, chosenOppId);
            Console.Write(_textService.StayHowLong());
        }

        public void DisplayCurrentHPs(ICreatureService creatureService, int chosenOppId = -1)
        {
            Console.Write(_textService.HP().PadRight(DisplaySettings.FirstColumnWidth));
            for (int i = 0; i < DisplaySettings.NumberOfOpps; ++i)
            {
                Console.Write(("|"
                               + creatureService.GetCreatureCurrentHPById(i)
                               + (creatureService.IsCreatureFriendly(i) ? "*" : "")
                               + (i == chosenOppId ? "x" : ""))
                    .PadRight(DisplaySettings.OtherColumnsWidth));
            }
        }
    }
}