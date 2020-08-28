using Doppelganger.App.Services.Abstract.Abstract;

namespace Doppelganger.App.Managers.Abstract
{
    public interface IFightManager
    {
        void FightMenu();
        void Initialize();
        int CalculateScore();
    }
}