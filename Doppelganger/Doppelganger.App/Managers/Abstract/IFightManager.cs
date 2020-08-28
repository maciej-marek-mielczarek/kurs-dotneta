using Doppelganger.App.Services.Abstract.Abstract;

namespace Doppelganger.App.Managers.Abstract
{
    public interface IFightManager
    {
        public void FightMenu();
        public void Initialize();
        ICreatureService CreatureService { get; }
    }
}