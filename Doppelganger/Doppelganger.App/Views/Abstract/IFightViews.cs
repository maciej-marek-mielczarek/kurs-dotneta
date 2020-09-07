using Doppelganger.App.Services.Abstract;

namespace Doppelganger.App.Views.Abstract
{
    public interface IFightViews
    {
        void PickAllyView(ICreatureService creatureService);
        void PickOppView(ICreatureService creatureService);
        void FightView(ICreatureService creatureService, int chosenOppId);
        void DisplayCurrentHPs(ICreatureService creatureService, int chosenOppId = -1);
    }
}